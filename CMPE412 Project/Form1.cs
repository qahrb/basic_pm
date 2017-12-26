using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPE412_Project
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        
        //create a graph object 
        
        //create a viewer object 
        Microsoft.Glee.GraphViewerGdi.GViewer viewer = new Microsoft.Glee.GraphViewerGdi.GViewer();
        //create a form 
        System.Windows.Forms.Form form = new System.Windows.Forms.Form();

       

        void fill_data_grid()
        {
            ////////////////////////////////////////
            ///////////////////////////////////////creating the resource table
            
            ////////////////////////////////////////adding the resource table to the dataset
            
            ////////////////////////////////////////
            ///////////////////////////////////////creating datagridviewcomboboxcolumn
            DataGridViewComboBoxColumn name = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn rabove = new DataGridViewComboBoxColumn();
            ///////////////////////////////////////adding empty items to the comboboxcolumn
            name.Items.Add("");
            rabove.Items.Add("");
            ///////////////////////////////////////adding resource names from the resource table to the combo boxes
            for (int i = 0; i < Program.ods.Tables[1].Rows.Count; i++)
            {
                name.Items.Add(Program.ods.Tables[1].Rows[i][0]);
                rabove.Items.Add(Program.ods.Tables[1].Rows[i][0]);
            }
            ///////////////////////////////////////connecting the comboboxes to the datagrid
            ((DataGridViewComboBoxColumn)gridorg.Columns["res"]).DataSource = name.Items;
            ((DataGridViewComboBoxColumn)gridorg.Columns["rank_above"]).DataSource = rabove.Items;
            ////////////////////////////////////////
            ///////////////////////////////////////adding the resources names to the datagrid automatically
            for (int i = 0; i < Program.ods.Tables[1].Rows.Count; i++)
            {
                gridorg.Rows.Add();
                gridorg.Rows[i].Cells[0].Value = Program.ods.Tables[1].Rows[i][0];
                gridorg.Rows[i].Cells[2].Value = "";
                gridorg.Rows[i].Cells[1].Value = "exp:software engineer";
            }
            ////////////////////////////////////////
            ///////////////////////////////////////

        }


        public Form1()
        {
            InitializeComponent();
            
            fill_data_grid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void draw_button_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////////
            ///////////////////////////////////////
            for (int z = 0; z < gridorg.RowCount - 1; z++)
            {
                if (gridorg.Rows[z].Cells[2].Value == null) gridorg.Rows[z].Cells[2].Value = "";
            }
            ///////////////////////////////////////
            for (int z = 0; z < gridorg.RowCount - 1; z++)
            {
                if (gridorg.Rows[z].Cells[1].Value == null) gridorg.Rows[z].Cells[1].Value = "";
            }
            ///////////////////////////////////////
            for (int z = 0; z < gridorg.RowCount - 1; z++)
            {
                if (gridorg.Rows[z].Cells[0].Value == null) gridorg.Rows[z].Cells[0].Value = "";
            }
            ///////////////////////////////////////
            int x =0;
            
            Microsoft.Glee.Drawing.Graph graph = new Microsoft.Glee.Drawing.Graph("graph");
            ////////////////////////////////////////
            ///////////////////////////////////////
            for (int i=0;i<gridorg.Rows.Count-1;i++)
            {
                /* x = gridorg.Rows[i].Cells[0].Value.ToString();
                 Console.WriteLine("{0}", x);
                 graph.AddEdge("hellow","hello");*/
                if (gridorg.Rows[i].Cells[2].Value.ToString() == "")
                {
                    graph.AddNode(gridorg.Rows[i].Cells[0].Value.ToString()+"\n"+ gridorg.Rows[i].Cells[1].Value.ToString());
                    graph.FindNode(gridorg.Rows[i].Cells[0].Value.ToString() + "\n" + gridorg.Rows[i].Cells[1].Value.ToString()).Attr.Shape = Microsoft.Glee.Drawing.Shape.Ellipse;
                    graph.FindNode(gridorg.Rows[i].Cells[0].Value.ToString() + "\n" + gridorg.Rows[i].Cells[1].Value.ToString()).Attr.Fillcolor = Microsoft.Glee.Drawing.Color.AliceBlue;
                    graph.FindNode(gridorg.Rows[i].Cells[0].Value.ToString() + "\n" + gridorg.Rows[i].Cells[1].Value.ToString()).Attr.FontName = "Tahoma";
                    continue;
                }
                for(int j = 0; j < gridorg.RowCount - 1; j++)//looks for the description of the rankabove
                {
                    if (gridorg.Rows[i].Cells[2].Value.ToString() == gridorg.Rows[j].Cells[0].Value.ToString())x=j ;
                }
                graph.AddEdge(gridorg.Rows[i].Cells[2].Value.ToString() + "\n" + gridorg.Rows[x].Cells[1].Value.ToString(), gridorg.Rows[i].Cells[0].Value.ToString() + "\n" + gridorg.Rows[i].Cells[1].Value.ToString()).Attr.Color = Microsoft.Glee.Drawing.Color.Black;
                graph.FindNode(gridorg.Rows[i].Cells[2].Value.ToString() + "\n" + gridorg.Rows[x].Cells[1].Value.ToString()).Attr.Shape = Microsoft.Glee.Drawing.Shape.Box;
                graph.FindNode(gridorg.Rows[i].Cells[2].Value.ToString() + "\n" + gridorg.Rows[x].Cells[1].Value.ToString()).Attr.Color = Microsoft.Glee.Drawing.Color.Black;
                graph.FindNode(gridorg.Rows[i].Cells[2].Value.ToString() + "\n" + gridorg.Rows[x].Cells[1].Value.ToString()).Attr.Fillcolor = Microsoft.Glee.Drawing.Color.AliceBlue;
                graph.FindNode(gridorg.Rows[i].Cells[0].Value.ToString() + "\n" + gridorg.Rows[i].Cells[1].Value.ToString()).Attr.Shape = Microsoft.Glee.Drawing.Shape.Box;
                graph.FindNode(gridorg.Rows[i].Cells[0].Value.ToString() + "\n" + gridorg.Rows[i].Cells[1].Value.ToString()).Attr.Color = Microsoft.Glee.Drawing.Color.Black;
                graph.FindNode(gridorg.Rows[i].Cells[0].Value.ToString() + "\n" + gridorg.Rows[i].Cells[1].Value.ToString()).Attr.Fillcolor = Microsoft.Glee.Drawing.Color.AliceBlue;

            }
            //graph.FindNode("Mohamed Bahaa" + "hello world");
            ////////////////////////////////////////
            ///////////////////////////////////////bind the graph to the viewer
            graph.GraphAttr.Orientation = Microsoft.Glee.Drawing.Orientation.Portrait;
            graph.GraphAttr.Border = 2;

            graph.GraphAttr.AspectRatio = 1;

            graph.GraphAttr.NodeAttr.FontName = "Tahoma";
            graph.GraphAttr.NodeAttr.Fontsize = 5;
            graph.GraphAttr.NodeAttr.Shape = Microsoft.Glee.Drawing.Shape.Box;

            graph.GraphAttr.EdgeAttr.FontName = "Tahoma";
            graph.GraphAttr.EdgeAttr.Fontsize = 50;
            graph.GraphAttr.EdgeAttr.Separation = 1000;
            graph.GraphAttr.EdgeAttr.ArrowHeadAtTarget = Microsoft.Glee.Drawing.ArrowStyle.Tee;

            viewer.Graph = graph;
           
            //associate the viewer with the form 
            form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            //viewer.Size = new Size(1000, 1000);
            //viewer.MinimumSize = new Size(Screen.PrimaryScreen.Bounds.Height, Screen.PrimaryScreen.Bounds.Width);
            //viewer.AutoScroll = true;
            form.Controls.Add(viewer);
            
            form.ResumeLayout();
            //show the form 
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
