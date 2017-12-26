

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace CMPE412_Project
{
    public partial class Form1_ : MetroFramework.Forms.MetroForm
    {
        public static Microsoft.Glee.Drawing.Graph graph = new Microsoft.Glee.Drawing.Graph("graph");
        DataSet ods = new DataSet();
        


        static class Constants
        {
            public const int N = 1005;
            public const int UNDONE = -1;
            public const int MINNUM = -1;
            public const int MAXNUM = 300000; // km per sec.

        }

        public struct node
        {
            public int flag;
            public int early_start;
            public int early_end;
            public int value;
            public int last_start;
            public int last_end;
            public int[] pre_num;
            public int[] after_num;
            public int len_pre;
            public int len_after;
            public int in_degree;
            public int out_degree;
        }

        node[] net_work = new node[Constants.N];
        // Queue<node> q;
        Queue<node> q = new Queue<node>();

        //  net_work[i].pre_num = new int[1005];


        private void topological_order()
        {

            while (q.Count != 0)
            {
                q.Dequeue();
            }
            node start_node = net_work[0];
            q.Enqueue(start_node);//43
            while (q.Count != 0)
            {
                node cur_node = q.Peek();
                q.Dequeue();
                int i;
                for (i = 0; i < cur_node.len_after; i++)
                {
                    int index = cur_node.after_num[i];
                    net_work[index].in_degree--;
                    if (net_work[index].early_start < cur_node.early_end)
                    {
                        net_work[index].early_start = cur_node.early_end;
                        net_work[index].early_end = net_work[index].early_start + net_work[index].value;
                    }
                    if (net_work[index].in_degree == 0 && net_work[index].flag != 1)
                    {
                        q.Enqueue(net_work[index]);
                    }
                }
                //show_items(i);
            }

            return;
        }

        private void inverse_topological_order(int end_index)
        {
            node end_node = net_work[end_index];
            while (q.Count != 0)
            {
                q.Dequeue();
            }
            q.Enqueue(end_node);
            while (q.Count != 0)
            {
                node cur_node = q.Peek();
                q.Dequeue();
                int i;
                for (i = 0; i < cur_node.len_pre; i++)
                {
                    int index = cur_node.pre_num[i];
                    net_work[index].out_degree--;
                    if (net_work[index].last_end > cur_node.last_start)
                    {
                        net_work[index].last_end = cur_node.last_start;
                        net_work[index].last_start = net_work[index].last_end - net_work[index].value;
                    }
                    if (net_work[index].out_degree == 0 && net_work[index].flag != 1)
                    {
                        q.Enqueue(net_work[index]);
                    }
                }

            }
            return;
        }

        private bool find_critical_path(int index)
        {
            int i;
            if (index != 0 && net_work[index].flag == 1)
                return true;
            node cur_node = net_work[index];
            if (cur_node.early_start != cur_node.last_start)
                return false;
            for (i = 0; i < cur_node.len_after; i++)
            {
                if (find_critical_path(cur_node.after_num[i]))
                {
                    Console.WriteLine("->({0},{1})", cur_node.value, index);
                    richTextBox1.AppendText(cur_node.value.ToString() + "    " + index.ToString() + "  ///   ");
                    /////////////////////////////////////////////////////////////////////
                    /////////////////////////////////////////////////////////////////////
                    //richTextBox1.Text += "("+cur_node.value.ToString() +"   "+ index.ToString()+")";
                    //richTextBox1.Text += index.ToString() + "     ";
                    if (index == 0)
                    {
                        graph.FindNode("start").Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;
                    }
                    if (index == 0)
                    {
                        graph.FindNode("start").Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;
                        graph.FindNode("end").Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;
                        break;
                    }

                    graph.FindNode(ods.Tables[0].Rows[index - 1][0].ToString()).Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;




                    /////////////////////////////////////////////////////////////////////
                    /////////////////////////////////////////////////////////////////////

                    return true;
                }
            }
            return false;
        }

        private void init(int n)
        {
            int i;
            for (i = 0; i <= n + 1; i++)
            {
                net_work[i].flag = 0;
                net_work[i].early_start = Constants.MINNUM;
                net_work[i].early_end = Constants.UNDONE;
                net_work[i].value = 0;
                net_work[i].last_start = Constants.UNDONE;
                net_work[i].last_end = Constants.MAXNUM;
                net_work[i].pre_num = new int[1005];

                net_work[i].after_num = new int[1005];
                for (int j = 0; j < 1005; j++)
                {
                    net_work[i].pre_num[j] = 0;
                }//in place of memset
                for (int j = 0; j < 1005; j++)
                {
                    net_work[i].after_num[j] = 0;
                }//in place of memset
                net_work[i].len_pre = 0;
                net_work[i].len_after = 0;
                net_work[i].in_degree = 0;
                net_work[i].out_degree = 0;
            }


            return;
        }

        private void add_node(int fa, int son)
        {
            net_work[fa].after_num[net_work[fa].len_after++] = son;
            //Console.WriteLine("{0}-{1}",)
            net_work[fa].out_degree++;
            net_work[son].pre_num[net_work[son].len_pre++] = fa;
            net_work[son].in_degree++;


        }
        void show_items(int i)
        {

            Console.WriteLine("{0}-{1}-{2}-{3}-{4}\n", i, net_work[i].early_start, net_work[i].early_end, net_work[i].last_start, net_work[i].last_end);



        }

        void show_item(int n)
        {
            int i;
            for (i = 0; i <= n + 1; i++)
            {
                Console.WriteLine("{0}-{1}-{2}-{3}-{4}\n", i, net_work[i].early_start, net_work[i].early_end, net_work[i].last_start, net_work[i].last_end);


            }
        }

        public Form1_()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            critical_path();
            
         
        }

        private int critical_path()
        {
            ////////////////////////////////////////////////////////////////////////////////////                                                                                    
            graph = new Microsoft.Glee.Drawing.Graph("graph");
            DataTable task = new DataTable("task");

            DataColumn task_name = new DataColumn("task_name");
            task_name.DataType = Type.GetType("System.String");

            DataColumn task_duration = new DataColumn("task_duration");
            task_duration.DataType = Type.GetType("System.Int32");

            DataColumn task_duration_type = new DataColumn("task_duration_type");
            task_duration_type.DataType = Type.GetType("System.String");

            DataColumn task_starting_time = new DataColumn("task_starting_time");
            task_starting_time.DataType = Type.GetType("System.DateTime");

            DataColumn task_finishing_time = new DataColumn("task_finishing_time");
            task_finishing_time.DataType = Type.GetType("System.DateTime");


            task.Columns.Add(task_name);
            task.Columns.Add(task_duration);
            task.Columns.Add(task_duration_type);
            task.Columns.Add(task_starting_time);
            task.Columns.Add(task_finishing_time);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataTable Tas_dep = new DataTable("Tas_dep");

            DataColumn Tas_dep_t = new DataColumn("Tas_dep_t");
            Tas_dep_t.DataType = Type.GetType("System.String");

            DataColumn Tas_dep_tp = new DataColumn("Tas_dep_tp");
            Tas_dep_tp.DataType = Type.GetType("System.String");

            Tas_dep.Columns.Add(Tas_dep_t);
            Tas_dep.Columns.Add(Tas_dep_tp);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataTable flip = new DataTable("flip");

            DataColumn fatherr = new DataColumn("fatherr");
            fatherr.DataType = Type.GetType("System.String");

            DataColumn sonn = new DataColumn("sonn");
            sonn.DataType = Type.GetType("System.String");

            flip.Columns.Add(fatherr);
            flip.Columns.Add(sonn);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataTable dep = new DataTable("dep");

            DataColumn f = new DataColumn("f");
            Tas_dep_t.DataType = Type.GetType("System.String");

            DataColumn s = new DataColumn("s");
            Tas_dep_tp.DataType = Type.GetType("System.String");

            dep.Columns.Add(f);
            dep.Columns.Add(s);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ods.Tables.Add(task);
            ods.Tables.Add(Tas_dep);
            ods.Tables.Add(flip);
            ods.Tables.Add(dep);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            graph.CleanNodes();
            for (int k=0;k<ods.Tables[0].Rows.Count;k++)
            {
                ods.Tables[0].Rows.RemoveAt(k);
            }
            for (int k = 0; k < ods.Tables[1].Rows.Count; k++)
            {
                ods.Tables[1].Rows.RemoveAt(k);
            }
            for (int k=0;k<Program.ods.Tables[0].Rows.Count;k++)
            {
                string name = Program.ods.Tables[0].Rows[k][0].ToString();
                int dur = int.Parse(Program.ods.Tables[0].Rows[k][1].ToString());
                string type= Program.ods.Tables[0].Rows[k][2].ToString();
                switch (type)
                {

                    case "Month": { dur = dur * 30; } break;
                    case "Hour":
                        {
                            double duration_ = ((double)dur / Program.number_of_working_hours);
                            dur = (int)Math.Ceiling(duration_);
                        }
                        break;
                    case "Week": { dur = dur * 7; } break;

                }
                string d1 = Program.ods.Tables[0].Rows[k][3].ToString();
                string d2 = Program.ods.Tables[0].Rows[k][4].ToString();
                string[] d11 = d1.Split(' ');
               
                DateTime st = DateTime.Parse(d11[0]);
                
                //DateTime fn= null;
                ods.Tables["task"].Rows.Add(name,dur,type,st);
            }
            for (int k = 0; k < Program.ods.Tables[3].Rows.Count; k++)
            {
                string col1 = Program.ods.Tables[3].Rows[k][0].ToString();
                string col2= Program.ods.Tables[3].Rows[k][1].ToString();
                ods.Tables[1].Rows.Add(col1, col2);
            }
            
            for (int q = 0; q < Tas_dep.Rows.Count; q++)
            {
                flip.Rows.Add(null, null);
                flip.Rows[q][0] = Tas_dep.Rows[q][1];
                flip.Rows[q][1] = Tas_dep.Rows[q][0];
            }
            
            for (int q = 0; q < flip.Rows.Count; q++)
            {
                dep.Rows.Add(null, null);
                dep.Rows[q][0] = flip.Rows[q][0];
                dep.Rows[q][1] = flip.Rows[q][1];

            }
            
            for (int q = 0; q < task.Rows.Count; q++)//for father
            {
                int y = 0;
                for (int w = 0; w < flip.Rows.Count; w++)//if there is father
                {
                    if (task.Rows[q][0] == flip.Rows[w][1]) y = 1;
                }
                if (y != 1)
                {
                    dep.Rows.Add(null, task.Rows[q][0]);
                }
                y = 0;

            }
            for (int q = 0; q < task.Rows.Count; q++)//for son
            {
                int y = 0;
                for (int w = 0; w < flip.Rows.Count; w++)//if there is son
                {
                    if (task.Rows[q][0] == flip.Rows[w][0]) y = 1;
                }
                if (y != 1)
                {
                    dep.Rows.Add(task.Rows[q][0], null);
                }
                y = 0;

            }
            Console.WriteLine("this is the dep that u are going to use\n");
            for (int q = 0; q < dep.Rows.Count; q++)
            {

                Console.WriteLine("fa:{0}  son:{1}\n", dep.Rows[q][0], dep.Rows[q][1]);
            }

           
            int n;
            n = ods.Tables[0].Rows.Count;
            int i;
            init(n);
            net_work[0].flag = 1;
            net_work[n + 1].flag = 1;
            net_work[0].early_start = 0;
            net_work[0].early_end = 0;
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (i = 1; i < n + 1; i++)
            {
                int x = int.Parse(ods.Tables[0].Rows[i - 1][1].ToString());
                net_work[i].value = x;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            int m;
            m = dep.Rows.Count;
            int fa = new int(), son = new int();
            for (i = 0; i < m; i++)
            {

                string sonName, sonNameToCheck, fatherName, fatherNameToCheck;
                //for the father
                for (int j = 0; j < n; j++)
                {
                    fatherName = dep.Rows[i][0].ToString();
                    fatherNameToCheck = ods.Tables[0].Rows[j][0].ToString();
                    if (fatherName == "")
                    {
                        fa = 0;
                        break;
                    }

                    if (fatherName == fatherNameToCheck)
                    {
                        fa = j + 1;
                        break;
                    }// comparison for parent to find its number from a string
                }

                // for the son
                for (int j = 0; j < n; j++)
                {

                    sonName = dep.Rows[i][1].ToString();
                    sonNameToCheck = ods.Tables[0].Rows[j][0].ToString();
                    if (sonName == "")
                    {
                        son = n + 1;
                        break;
                    }
                    if (sonName == sonNameToCheck)
                    {
                        son = j + 1;
                        break;
                    }
                }

                //fa = int.Parse(ods.Tables[1].Rows[i][0].ToString());
                //son = int.Parse(ods.Tables[1].Rows[i][1].ToString());
                add_node(fa, son);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int z = 0; z < n + 1; z++)
            {
                Console.WriteLine("value:{0}\n", net_work[z].value);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            topological_order();
            show_item(n);
            net_work[n + 1].last_start = net_work[n + 1].early_start;
            net_work[n + 1].last_end = net_work[n + 1].early_end;
            inverse_topological_order(n + 1);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // find_critical_path(0);
            show_item(n);

            //create a form 
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            //create a viewer object 
            Microsoft.Glee.GraphViewerGdi.GViewer viewer = new Microsoft.Glee.GraphViewerGdi.GViewer();
            //create a graph object 
            //create the graph content 
            //graph.AddEdge("Start", "T1");
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            for (i = 0; i < m; i++)
            {
                if (dep.Rows[i][0].ToString() == "")
                {
                    graph.AddEdge("start", dep.Rows[i][1].ToString());
                    continue;
                }
                if (dep.Rows[i][1].ToString() == "")
                {
                    graph.AddEdge(dep.Rows[i][0].ToString(), "end");
                    continue;
                }

                graph.AddEdge(dep.Rows[i][0].ToString(), dep.Rows[i][1].ToString()).Attr.Color = Microsoft.Glee.Drawing.Color.Green;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //graph.AddEdge("Start", "End").Attr.Color = Microsoft.Glee.Drawing.Color.Green;
            //graph.FindNode("start").Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Magenta;

            find_critical_path(0);
            //graph.FindNode("T1").Attr.Fillcolor = Microsoft.Glee.Drawing.Color.MistyRose;
            //Microsoft.Glee.Drawing.Node c = graph.FindNode("End");
            //c.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.PaleGreen;
            //c.Attr.Shape = Microsoft.Glee.Drawing.Shape.Diamond;
            //bind the graph to the viewer 
            viewer.Graph = graph;

            //associate the viewer with the form 
            form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(viewer);
            form.ResumeLayout();
            //show the form 
            form.ShowDialog();

            return 0;
        }

    }
}