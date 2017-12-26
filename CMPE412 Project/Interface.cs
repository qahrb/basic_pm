using Braincase.GanttChart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;


namespace CMPE412_Project
{

    public partial class Interface : MetroFramework.Forms.MetroForm

    {

        MyTask[] Tasks = new MyTask[10000];

        int count_task = 0;

        OverlayPainter _mOverlay = new OverlayPainter();

        ProjectManager _mManager = null;

        /// <summary>
        /// Example starts here
        /// </summary>
        public Interface()
        {
            InitializeComponent();

            // Create a Project
            _mManager = new ProjectManager();


            // Initialize the Chart with our ProjectManager and CreateTaskDelegate
            _mChart.Init(_mManager);
            _mChart.CreateTaskDelegate = delegate () { return new MyTask(_mManager); };

        }

        void _mChart_TaskSelected(object sender, TaskMouseEventArgs e)
        {
            _mTaskGrid.SelectedObjects = _mChart.SelectedTasks.Select(x => _mManager.IsPart(x) ? _mManager.SplitTaskOf(x) : x).ToArray();
            _mResourceGrid.Items.Clear();
            _mResourceGrid.Items.AddRange(_mManager.ResourcesOf(e.Task).Select(x => new ListViewItem(((MyResource)x).Name)).ToArray());
        }

        void _mChart_TaskMouseOut(object sender, TaskMouseEventArgs e)
        {
            lblStatus.Text = "";
            _mChart.Invalidate();
        }

        void _mChart_TaskMouseOver(object sender, TaskMouseEventArgs e)
        {
            lblStatus.Text = string.Format("{0} to {1}", _mManager.GetDateTime(e.Task.Start).ToLongDateString(), _mManager.GetDateTime(e.Task.End).ToLongDateString());
            _mChart.Invalidate();
        }



        #region Main Menu

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (var fs = System.IO.File.OpenWrite(dialog.FileName))
                    {
                        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        bf.Serialize(fs, _mManager);
                    }
                }
            }
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (var fs = System.IO.File.OpenRead(dialog.FileName))
                    {
                        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        _mManager = bf.Deserialize(fs) as ProjectManager;
                        if (_mManager == null)
                        {
                            MessageBox.Show("Unable to load ProjectManager. Data structure might have changed from previous verions", "Gantt Chart", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            _mChart.Init(_mManager);
                            _mChart.Invalidate();
                        }
                    }
                }
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuViewDaysDayOfWeek_Click(object sender, EventArgs e)
        {
            _mManager.TimeScale = TimeScale.Day;
            _mChart.TimeScaleDisplay = TimeScaleDisplay.DayOfWeek;
            _mChart.Invalidate();
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            // start a new Project and init the chart with the project
            _mManager = new ProjectManager();
            _mManager.Add(new Braincase.GanttChart.Task() { Name = "New Task" });
            _mChart.Init(_mManager);
            _mChart.Invalidate();
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please visit http://www.jakesee.com/net-c-winforms-gantt-chart-control/ for more help and details", "Braincase Solutions - Gantt Chart", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                System.Diagnostics.Process.Start("http://www.jakesee.com/net-c-winforms-gantt-chart-control/");
            }
        }

        private void mnuViewRelationships_Click(object sender, EventArgs e)
        {
            _mChart.ShowRelations = mnuViewRelationships.Checked = !mnuViewRelationships.Checked;
            _mChart.Invalidate();
        }

        private void mnuViewSlack_Click(object sender, EventArgs e)
        {
            _mChart.ShowSlack = mnuViewSlack.Checked = !mnuViewSlack.Checked;
            _mChart.Invalidate();
        }

        private void mnuViewIntructions_Click(object sender, EventArgs e)
        {
            _mOverlay.PrintMode = !(mnuViewIntructions.Checked = !mnuViewIntructions.Checked);
            _mChart.Invalidate();
        }

        #region Timescale Views
        private void mnuViewDays_Click(object sender, EventArgs e)
        {
            _mManager.TimeScale = TimeScale.Day;
            mnuViewDays.Checked = true;
            mnuViewWeek.Checked = false;
            _mChart.Invalidate();
        }

        private void mnuViewWeek_Click(object sender, EventArgs e)
        {
            _mManager.TimeScale = TimeScale.Week;
            mnuViewDays.Checked = false;
            mnuViewWeek.Checked = true;
            _mChart.Invalidate();
        }

        private void mnuViewDayOfWeek_Click(object sender, EventArgs e)
        {
            _mChart.TimeScaleDisplay = TimeScaleDisplay.DayOfWeek;
            mnuViewDayOfWeek.Checked = true;
            mnuViewDayOfMonth.Checked = false;
            mnuViewWeekOfYear.Checked = false;
            _mChart.Invalidate();
        }

        private void mnuViewDayOfMonth_Click(object sender, EventArgs e)
        {
            _mChart.TimeScaleDisplay = TimeScaleDisplay.DayOfMonth;
            mnuViewDayOfWeek.Checked = false;
            mnuViewDayOfMonth.Checked = true;
            mnuViewWeekOfYear.Checked = false;
            _mChart.Invalidate();
        }

        private void mnuViewWeekOfYear_Click(object sender, EventArgs e)
        {
            _mChart.TimeScaleDisplay = TimeScaleDisplay.WeekOfYear;
            mnuViewDayOfWeek.Checked = false;
            mnuViewDayOfMonth.Checked = false;
            mnuViewWeekOfYear.Checked = true;
            _mChart.Invalidate();
        }
        #endregion Timescale Views

        #endregion Main Menu

        #region Sidebar

        private void _mDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _mManager.Start = _mStartDatePicker.Value;
            var span = DateTime.Today - _mManager.Start;
            _mManager.Now = (int)Math.Round(span.TotalDays);
            if (_mManager.TimeScale == TimeScale.Week) _mManager.Now = (_mManager.Now % 7) * 7;
            _mChart.Invalidate();
        }

        private void _mPropertyGrid_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            _mChart.Invalidate();
        }

        private void _mNowDatePicker_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan span = _mNowDatePicker.Value - _mStartDatePicker.Value;
            _mManager.Now = span.Days + 1;
            if (_mManager.TimeScale == TimeScale.Week) _mManager.Now = _mManager.Now / 7 + (_mManager.Now % 7 > 0 ? 1 : 0);
            _mChart.Invalidate();
        }

        private void _mScrollDatePicker_ValueChanged(object sender, EventArgs e)
        {
            _mChart.ScrollTo(_mScrollDatePicker.Value);
            _mChart.Invalidate();
        }

        private void _mTaskGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (TaskGridView.SelectedRows.Count > 0)
            {
                var task = TaskGridView.SelectedRows[0].DataBoundItem as Braincase.GanttChart.Task;
                _mChart.ScrollTo(task);
            }
        }

        #endregion Sidebar

        #region Print

        private void _PrintDocument(float scale)
        {
            using (var dialog = new PrintDialog())
            {
                dialog.Document = new System.Drawing.Printing.PrintDocument();
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // set the print mode for the custom overlay painter so that we skip printing instructions
                    dialog.Document.BeginPrint += (s, arg) => _mOverlay.PrintMode = true;
                    dialog.Document.EndPrint += (s, arg) => _mOverlay.PrintMode = false;

                    // tell chart to print to the document at the specified scale
                    _mChart.Print(dialog.Document, scale);
                }
            }
        }

        private void _PrintImage(float scale)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Bitmap (*.bmp) | *.bmp";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // set the print mode for the custom overlay painter so that we skip printing instructions
                    _mOverlay.PrintMode = true;
                    // tell chart to print to the document at the specified scale

                    var bitmap = _mChart.Print(scale);
                    _mOverlay.PrintMode = false; // restore printing overlays

                    bitmap.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
        }


        #endregion Print        

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void Interface_Load(object sender, EventArgs e)
        {
             metroPanel4.Visible = false;
            _mChart.Enabled = true;
            _mChart.AllowTaskDragDrop = false;
            panel3.Focus();

            for (int i = 0; i < 100; i++)
            {
                myGrid.Rows.Add();

                myGrid.Rows[i].Cells["_added"].Value = "false";

            }
            myGrid.Refresh();
            myGrid.Rows[0].Selected = true;
            _mManager.Start = Program.start.Date;

            _mChart.Refresh();
            timer1.Enabled = true;
            timer1.Start();
            for (int i = 0; i < 10000; i++)
            {
                Tasks[i] = new MyTask(_mManager);
            }
        }

       

        private void myGrid_SelectionChanged(object sender, EventArgs e)
        {
            myGrid.Rows[myGrid.CurrentCell.RowIndex].Selected = true;
        }

        private void _Save_Click(object sender, EventArgs e)
        {
            try
            {
                panel3.Focus();
                
                // Delete the file if it exists.
                if (File.Exists(Program.path))
                {
                    File.Delete(Program.path);
                }

                // Create the file.
                using (StreamWriter st = new StreamWriter(Program.path))
                {
                    st.WriteLine(Program.start);
                    st.WriteLine(Program.country);
                    st.WriteLine(Program.currency);
                    st.WriteLine(Program.number_of_working_hours);
                    st.WriteLine("Table1");
                    for (int i = 0; i < Program.ods.Tables[0].Rows.Count; i++)
                    {
                        st.WriteLine(Program.ods.Tables[0].Rows[i][0].ToString() + ";" + Program.ods.Tables[0].Rows[i][1].ToString() + ";" + Program.ods.Tables[0].Rows[i][2].ToString() + ";" + Program.ods.Tables[0].Rows[i][3].ToString());

                    }
                    st.WriteLine("Table2");
                    for (int i = 0; i < Program.ods.Tables[1].Rows.Count; i++)
                    {
                        st.WriteLine(Program.ods.Tables[1].Rows[i][0].ToString() + ";" + Program.ods.Tables[1].Rows[i][1].ToString() + ";" + Program.ods.Tables[1].Rows[i][2].ToString());

                    }
                    st.WriteLine("Table3");
                    for (int i = 0; i < Program.ods.Tables[2].Rows.Count; i++)
                    {
                        st.WriteLine(Program.ods.Tables[2].Rows[i][0].ToString() + ";" + Program.ods.Tables[2].Rows[i][1].ToString());

                    }
                    st.WriteLine("Table4");
                    for (int i = 0; i < Program.ods.Tables[3].Rows.Count; i++)
                    {
                        st.WriteLine(Program.ods.Tables[3].Rows[i][0].ToString() + ";" + Program.ods.Tables[3].Rows[i][1].ToString());

                    }
                    st.WriteLine("Tasks");

                    for (int i = 0; i < count_task; i++)
                    {
                        st.WriteLine(Tasks[i].Name + ";" + Tasks[i].Duration + ";" + Tasks[i].Start + ";" + Tasks[i].End);

                    }
                    st.WriteLine("Grid");
                    for (int i = 0; i < myGrid.Rows.Count; i++)
                    {
                        string line = "";
                        if (myGrid.Rows[i].Cells[1].Value == null || myGrid.Rows[i].Cells["_added"].Value.ToString() == "false") continue;
                        for (int j = 0; j < myGrid.Columns.Count; j++)
                        {
                            if (j == myGrid.Columns.Count - 1)
                            {
                                if (myGrid.Rows[i].Cells[j].Value == null) line += "";
                                else
                                    line += myGrid.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                if (myGrid.Rows[i].Cells[j].Value == null) line += ";";
                                else
                                    line += myGrid.Rows[i].Cells[j].Value.ToString() + ";";
                            }
                        }
                        st.WriteLine(line);
                    }
                    st.WriteLine("Finish");
                    st.Close();
                    st.Dispose();
                    
                    MessageBox.Show("Saved Successfully");
                    
                }
               
            }
            catch(Exception e1)
            {
                MessageBox.Show("Error Occurs, Try again");
            }
        }

        private void _networkButton_Click(object sender, EventArgs e)
        {
            panel3.Focus();
            Form f = new Form1_();
            f.Show();
        }
        private void Apply_Click(object sender, EventArgs e)
        {
            metroPanel4.Visible = false;
        }

        private void _resourceButton_Click(object sender, EventArgs e)
        {
            panel3.Focus();
            MetroFramework.Forms.MetroForm f = new Resources();
            f.Show();
        }

        private void _ganttButton_Click(object sender, EventArgs e)
        {
            panel3.Focus();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            panel3.Focus();
        }

        private void _help_Click(object sender, EventArgs e)
        {
            _mManager.Unrelate(Tasks[0]);
            _mChart.Refresh();
            panel3.Focus();
        }

        private void myGrid_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string task_name = "0";


                {
                    if (myGrid.Rows[myGrid.CurrentRow.Index].Cells["_added"].Value.ToString() == "false")
                    {
                        if ((string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value != null
                            && (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[2].Value != null
                            && (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[3].Value != null
                            && (DateTime)myGrid.Rows[myGrid.CurrentRow.Index].Cells[4].Value != null
                           //   && (DateTime)myGrid.Rows[myGrid.CurrentRow.Index].Cells[5].Value != null
                           /* && (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[4].Value != null*/)
                        {


                            int duration = int.Parse(myGrid.Rows[myGrid.CurrentRow.Index].Cells["_Duration"].Value.ToString());
                            Tasks[count_task] = new MyTask(_mManager) { Name = myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value.ToString() };
                            DateTime Start = (DateTime)myGrid.Rows[myGrid.CurrentRow.Index].Cells[4].Value;
                            int starting_place = int.Parse((Start.Date - Program.start.Date).TotalDays.ToString());
                            DateTime Finish = (DateTime)myGrid.Rows[myGrid.CurrentRow.Index].Cells[5].Value;
                            int dur = int.Parse((Finish - Start).TotalDays.ToString());
                            int finishing_place = int.Parse((Finish.Date - Program.start.Date).TotalDays.ToString());
                            _mManager.Add(Tasks[count_task]);
                            // _mManager.SetEnd(Tasks[count_task],finishing_place );
                            _mManager.SetStart(Tasks[count_task], starting_place);
                            _mManager.SetDuration(Tasks[count_task], dur);
                            task_name = (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value;
                            string type_dur = (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[3].Value;
                            Program.ods.Tables["task"].Rows.Add(task_name, duration, type_dur, Start, Finish);
                            myGrid.Rows[myGrid.CurrentRow.Index].Cells["_added"].Value = "true";
                            int pos = -1;
                            int posintask = -1;
                            for (int i = 0; i < Program.ods.Tables[0].Rows.Count; i++)
                            {
                                if (Program.ods.Tables[0].Rows[i][0].ToString() == task_name) pos = i;
                                if (Tasks[i].Name == task_name) posintask = i;
                            }
                            myGrid.Rows[myGrid.CurrentRow.Index].Cells["_pos"].Value = pos.ToString();
                            myGrid.Rows[myGrid.CurrentRow.Index].Cells["_posintask"].Value = posintask.ToString();
                            _mChart.Refresh();
                            count_task++;
                        }

                    }
                    else
                    {
                        if ((string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value != null
                        && (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[2].Value != null
                        && (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[3].Value != null
                        && (DateTime)myGrid.Rows[myGrid.CurrentRow.Index].Cells[4].Value != null)
                        {
                            int posintask = int.Parse(myGrid.Rows[myGrid.CurrentRow.Index].Cells["_posintask"].Value.ToString());
                            _mManager.Delete(Tasks[posintask]);
                            int duration = int.Parse(myGrid.Rows[myGrid.CurrentRow.Index].Cells["_Duration"].Value.ToString());
                            DateTime Start = (DateTime)myGrid.Rows[myGrid.CurrentRow.Index].Cells[4].Value;
                            DateTime Finish = (DateTime)myGrid.Rows[myGrid.CurrentRow.Index].Cells[5].Value;
                            int starting_place = int.Parse((Start.Date - Program.start.Date).TotalDays.ToString());
                            int finishing_place = int.Parse((Finish.Date - Program.start.Date).TotalDays.ToString());
                            task_name = (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value;
                            int duration_ = int.Parse(myGrid.Rows[myGrid.CurrentRow.Index].Cells[2].Value.ToString());
                            string type_dur = (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[3].Value;
                            DateTime startingtime = (DateTime)myGrid.Rows[myGrid.CurrentRow.Index].Cells[4].Value;
                            int pos = int.Parse(myGrid.Rows[myGrid.CurrentRow.Index].Cells["_pos"].Value.ToString());

                            Program.ods.Tables["task"].Rows[pos][0] = task_name;
                            Program.ods.Tables["task"].Rows[pos][1] = duration;
                            Program.ods.Tables["task"].Rows[pos][2] = type_dur;
                            Program.ods.Tables["task"].Rows[pos][3] = startingtime;

                            Tasks[posintask].Name = task_name;
                            _mManager.Add(Tasks[posintask]);
                            _mManager.SetDuration(Tasks[posintask], finishing_place - starting_place);
                            _mManager.SetStart(Tasks[posintask], starting_place);
                            _mManager.SetEnd(Tasks[posintask], finishing_place);


                            _mChart.Refresh();

                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error occurs");
            }



        }




        private void myGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            // this code is written to make the date and duration change dynamically.
            DateTime starting_date;
            if ((myGrid.Columns[e.ColumnIndex].Name == "_Duration" && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Start"].Value != null && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Type"].Value != null)
            || (myGrid.Columns[e.ColumnIndex].Name == "_Start" && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Duration"].Value != null && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Type"].Value != null)
            || (myGrid.Columns[e.ColumnIndex].Name == "_Type" && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Start"].Value != null && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Duration"].Value != null)
            )
            {
                starting_date = (DateTime)(myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Start"].Value);
                string type = myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Type"].Value.ToString();
                int duration = Convert.ToInt32(myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Duration"].Value);
                if (duration <= 0)
                {
                    MessageBox.Show("Duration of the task can not be less than or equal 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Duration"].Value = null;
                    myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Finish"].Value = null;
                }
                else
                {
                    switch (type)
                    {

                        case "Month": { duration = duration * 30; } break;
                        case "Hour":
                            {
                                double duration_ = ((double)duration / Program.number_of_working_hours);
                                duration = (int)Math.Ceiling(duration_);
                            }
                            break;
                        case "Week": { duration = duration * 7; } break;

                    }
                    if (starting_date.DayOfWeek == DayOfWeek.Saturday || starting_date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        MessageBox.Show("Be careful, a Task can not start on " + starting_date.DayOfWeek + "\nEither move it to Monday or move it back to Friday", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Start"].Value = null;
                    }
                    else
                    {

                        //  int duration = Convert.ToInt32(myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Duration"].Value);
                        DateTime fn = new DateTime(1995, 1, 18);//this date is nothing, is just an initialization of the variable fn.
                        int i = 0;
                        int count = 0;
                        while (count < duration)
                        {
                            fn = starting_date.AddDays(i);
                            if (fn.DayOfWeek == DayOfWeek.Saturday) i = i + 2;
                            else { i++; count++; }
                        }
                        myGrid.Rows[myGrid.CurrentRow.Index].Cells["_Finish"].Value = fn;
                    }
                }
            }
            // end of the code.

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
     
        }

        private void myGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void myGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            String name = myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value.ToString();
            int pos = -1;
            for (int i = 0; i < Program.ods.Tables[0].Rows.Count; i++)
            {
                if (Program.ods.Tables[0].Rows[i][0].ToString() == name)
                {
                    pos = i;
                }
            }
            for (int i = 0; i < Program.ods.Tables[3].Rows.Count; i++)
            {
                if (Program.ods.Tables[3].Rows[i][0].ToString() == name)
                {
                    Program.ods.Tables[3].Rows[i].Delete();
                }
            }
            Program.ods.Tables[0].Rows.RemoveAt(pos);
            _mManager.Delete(Tasks[pos]);
            _mChart.Refresh();
            count_task--;
        }

        private void myGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void myGrid_Enter(object sender, EventArgs e)
        {

        }

        private void myGrid_MouseEnter(object sender, EventArgs e)
        {

        }

        private void myGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

        }

        private void myGrid_CellValidated_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int c = 0;
                // this code is written to make the date and duration change dynamically.
                if (myGrid.Columns[e.ColumnIndex].Name == "_TaskName" && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_TaskName"].Value != null)
                {
                    c = 0;
                    string name = myGrid.Rows[myGrid.CurrentRow.Index].Cells["_TaskName"].Value.ToString();
                    for (int i = 0; i < myGrid.Rows.Count; i++)
                    {
                        if (myGrid.Rows[i].Cells["_TaskName"].Value != null)
                        {
                            if (myGrid.Rows[i].Cells["_TaskName"].Value.ToString() == name)
                            {
                                c++;

                            }
                        }
                        if (c > 1) break;
                    }
                }
                if (c > 1)
                {
                    MessageBox.Show("Cannot have two task with the same name", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    myGrid.Rows[myGrid.CurrentRow.Index].Cells["_TaskName"].Value = null;
                }
                int test;
                string du = "0";
                if (myGrid.Columns[e.ColumnIndex].Name == "_Duration" && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Duration"].Value != null)
                {
                    du = myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Duration"].Value.ToString();
                }

                if (int.TryParse(du, out test) == true)
                {
                    DateTime starting_date;
                    if ((myGrid.Columns[e.ColumnIndex].Name == "_Duration" && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Start"].Value != null && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Type"].Value != null)
                    || (myGrid.Columns[e.ColumnIndex].Name == "_Start" && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Duration"].Value != null && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Type"].Value != null)
                    || (myGrid.Columns[e.ColumnIndex].Name == "_Type" && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Start"].Value != null && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Duration"].Value != null)
                    )
                    {

                        starting_date = (DateTime)(myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Start"].Value);
                        string type = myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Type"].Value.ToString();
                        int duration = Convert.ToInt32(myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Duration"].Value);
                        if (duration <= 0)
                        {
                            MessageBox.Show("Duration of the task can not be less than or equal 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Duration"].Value = null;
                            myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Finish"].Value = null;
                        }
                        else
                        {
                            switch (type)
                            {

                                case "Month": { duration = duration * 30; } break;
                                case "Hour":
                                    {
                                        double duration_ = ((double)duration / Program.number_of_working_hours);
                                        duration = (int)Math.Ceiling(duration_);
                                    }
                                    break;
                                case "Week": { duration = duration * 7; } break;

                            }
                            if (starting_date.DayOfWeek == DayOfWeek.Saturday || starting_date.DayOfWeek == DayOfWeek.Sunday)
                            {
                                MessageBox.Show("Be careful, a Task can not start on " + starting_date.DayOfWeek + "\nEither move it to Monday or move it back to Friday", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Start"].Value = null;
                            }
                            else
                            {

                                //  int duration = Convert.ToInt32(myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Duration"].Value);
                                DateTime fn = new DateTime(1995, 1, 18);//this date is nothing, is just an initialization of the variable fn.
                                int i = 0;
                                int count = 0;
                                while (count < duration)
                                {
                                    fn = starting_date.AddDays(i);
                                    if (fn.DayOfWeek == DayOfWeek.Saturday) i = i + 2;
                                    else { i++; count++; }
                                }
                                myGrid.Rows[myGrid.CurrentRow.Index].Cells["_Finish"].Value = fn;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The duration must be an integer");
                    myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Duration"].Value = null;
                    myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Start"].Value = null;
                    myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Finish"].Value = null;
                    myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Type"].Value = null;
                    if (myGrid.Rows[myGrid.CurrentRow.Index].Cells["_added"].Value.ToString() == "true")
                    {
                        int pos = int.Parse(myGrid.Rows[myGrid.CurrentRow.Index].Cells["_posintask"].Value.ToString());
                        _mManager.Delete(Tasks[pos]);
                    }
                }

                try
                {
                    if (myGrid.Columns[e.ColumnIndex].Name == "_Predecessors" && (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[8].Value != null)
                    {

                        string task_nm = (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value;
                        int pos0 = -1;
                        for (int i = 0; i < count_task; i++)
                        {
                            if (Tasks[i].Name == task_nm) { pos0 = i; break; }
                        }
                        try
                        {
                            for (int i = 0; i < count_task; i++)
                            {
                                //MessageBox.Show(Tasks[i].Name + " " + Tasks[pos0]);
                                if(i!=pos0)
                                _mManager.Unrelate(Tasks[i], Tasks[pos0]);

                            }
                        }catch(Exception e11)
                        {
                            MessageBox.Show(e11.Message);
                        }
                        for (int i = 0; i < Program.ods.Tables[3].Rows.Count; i++)
                        {
                            if (Program.ods.Tables[3].Rows[i][0].ToString() == task_nm)
                                Program.ods.Tables[3].Rows[i].Delete();
                        }
                        string tasks = (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[8].Value;
                        string[] T = tasks.Split('+');
                        int j = 0, pos = -1, pos1 = -1, pos2 = -1;
                        int lenght = T.Length;
                        DateTime dt_s = (DateTime)myGrid.Rows[myGrid.CurrentRow.Index].Cells[4].Value;
                        while (j < lenght)
                        {
                            for (int i = 0; i < Program.ods.Tables[0].Rows.Count; i++)
                            {
                                if (T[j].ToUpper() == Program.ods.Tables[0].Rows[i][0].ToString().ToUpper())
                                {
                                    if ((DateTime)Program.ods.Tables[0].Rows[i][3] <= dt_s) { pos = i; break; }
                                }
                            }
                            if (pos != -1)
                            {
                                for (int i = 0; i < count_task; i++)
                                {
                                    if (T[j].ToUpper() == Tasks[i].Name.ToUpper())
                                    {
                                        pos1 = i;
                                    }
                                    if (myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value.ToString().ToUpper() == Tasks[i].Name.ToUpper())
                                    {
                                        pos2 = i;
                                    }
                                }
                                Program.ods.Tables[3].Rows.Add(Tasks[pos2].Name, Tasks[pos1].Name);
                                _mManager.Relate(Tasks[pos1], Tasks[pos2]);
                            }
                            j++;
                        }

                    }
                    else
                if ((myGrid.Columns[e.ColumnIndex].Name == "_Predecessors" && (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[8].Value == null) || (myGrid.Columns[e.ColumnIndex].Name == "_Predecessors" && (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[8].Value == ""))
                    {
                        string task_nm = (string)myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value;
                        int pos0 = int.Parse(myGrid.Rows[myGrid.CurrentRow.Index].Cells["_posintask"].Value.ToString());
                        for (int i = 0; i < Program.ods.Tables[3].Rows.Count; i++)
                        {
                            if (Program.ods.Tables[3].Rows[i][0].ToString() == task_nm)
                            {
                                string task_pre = Program.ods.Tables[3].Rows[i][1].ToString();

                                int pos_d = -1;
                                for (int j = 0; j < count_task; j++)
                                {
                                    if (Tasks[j].Name == task_pre) { pos_d = j; break; }
                                }

                                if (pos0 != -1 && pos_d != -1)
                                {
                                    _mManager.Unrelate(Tasks[pos_d], Tasks[pos0]);
                                    _mChart.Refresh();
                                    Program.ods.Tables[3].Rows[i].Delete();
                                }
                            }
                        }
                    }
                    _mChart.Refresh();
                    // end of the code.

                    if (myGrid.Columns[e.ColumnIndex].Name == "_Resource" && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Resource"].Value != null)
                    {
                        if (myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Resource"].Value.ToString() != "")
                        {
                            string name_res = myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Resource"].Value.ToString();
                            int salary = new int();
                            if (myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Start"].Value != null && myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Finish"].Value != null)
                            {
                                DateTime st = (DateTime)myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Start"].Value;
                                DateTime fn = (DateTime)myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_Finish"].Value;
                                int cnt = 0;
                                for (int i = 0; ; i++)
                                {
                                    if (st.AddDays(i).DayOfWeek != DayOfWeek.Saturday && st.AddDays(i).DayOfWeek != DayOfWeek.Sunday)
                                    {
                                        cnt++;
                                    }
                                    if (st.AddDays(i) >= fn) break;
                                }
                                for (int i = 0; i < Program.ods.Tables[1].Rows.Count; i++)
                                {
                                    if (Program.ods.Tables[1].Rows[i][0].ToString() == name_res)
                                    {
                                        salary = int.Parse(Program.ods.Tables[1].Rows[i][1].ToString());
                                        break;
                                    }
                                }
                                myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_cost"].Value = (salary * Program.number_of_working_hours * cnt).ToString();
                            }
                            else
                            {
                                myGrid.Rows[myGrid.CurrentCell.RowIndex].Cells["_cost"].Value = 0.ToString();
                            }
                        }

                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            catch(Exception e1)
            {
                MessageBox.Show("Error occur, Try again");
            }
        }

        private void myGrid_UserDeletingRow_1(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (myGrid.Rows[myGrid.CurrentRow.Index].Cells["_pos"].Value != null && myGrid.Rows[myGrid.CurrentRow.Index].Cells["_posintask"].Value != null)
                {
                    String name = myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value.ToString();
                    int pos = int.Parse(myGrid.Rows[myGrid.CurrentRow.Index].Cells["_posintask"].Value.ToString());
                    int poss = int.Parse(myGrid.Rows[myGrid.CurrentRow.Index].Cells["_pos"].Value.ToString());

                    for (int i = 0; i < Program.ods.Tables[3].Rows.Count; i++)
                    {

                        if (Program.ods.Tables[3].Rows[i][1].ToString() == name || Program.ods.Tables[3].Rows[i][0].ToString() == name)
                        {
                            Program.ods.Tables[3].Rows[i].Delete();
                        }
                    }
                    Program.ods.Tables[0].Rows.RemoveAt(poss);
                    _mManager.Delete(Tasks[pos]);
                    for (int k = pos; k < count_task; k++)
                    {
                        Tasks[k] = Tasks[k + 1];
                    }

                    for (int i = 0; i < myGrid.Rows.Count; i++)
                    {
                        if (myGrid.Rows[i].Cells[1].Value != null)
                        {
                            int pos1 = -1;
                            int posintask = -1;
                            for (int j = 0; j < Program.ods.Tables[0].Rows.Count; j++)
                            {

                                if (Program.ods.Tables[0].Rows[j][0].ToString() == myGrid.Rows[i].Cells[1].Value.ToString())
                                {
                                    pos1 = j;
                                    break;
                                }

                            }
                            for (int j = 0; j < count_task; j++)
                            {
                                if (Tasks[j].Name == null) continue;
                                string name1 = Tasks[j].Name.ToString();
                                if (name1 == myGrid.Rows[i].Cells[1].Value.ToString())
                                {
                                    posintask = j;
                                    break;
                                }
                            }
                            if (pos1 != -1 && posintask != -1)
                            {
                                myGrid.Rows[i].Cells["_pos"].Value = pos1.ToString();
                                myGrid.Rows[i].Cells["_posintask"].Value = posintask.ToString();
                            }
                        }
                    }
                }
                _mChart.Refresh();
                count_task--;
            }
            catch(Exception e1)
            {
                MessageBox.Show("Error occurs, Try again");
            }
        }



        private void myGrid_UserDeletedRow_1(object sender, DataGridViewRowEventArgs e)
        {

        }

        #region overlay painter
        /// <summary>
        /// An example of how to encapsulate a helper painter for painter additional features on Chart
        /// </summary>
        public class OverlayPainter
        {
            /// <summary>
            /// Hook such a method to the chart paint event listeners
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void ChartOverlayPainter(object sender, ChartPaintEventArgs e)
            {
                // Don't want to print instructions to file
                if (this.PrintMode) return;

                var g = e.Graphics;
                var chart = e.Chart;

                // Demo: Static billboards begin -----------------------------------
                // Demonstrate how to draw static billboards
                // "push matrix" -- save our transformation matrix
                e.Chart.BeginBillboardMode(e.Graphics);

                // draw mouse command instructions
                int margin = 300;
                int left = 20;
                var color = chart.HeaderFormat.Color;
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("THIS IS DRAWN BY A CUSTOM OVERLAY PAINTER TO SHOW DEFAULT MOUSE COMMANDS.");
                builder.AppendLine("*******************************************************************************************************");
                builder.AppendLine("Left Click - Select task and display properties in PropertyGrid");
                builder.AppendLine("Left Mouse Drag - Change task starting point");
                builder.AppendLine("Right Mouse Drag - Change task duration");
                builder.AppendLine("Middle Mouse Drag - Change task complete percentage");
                builder.AppendLine("Left Doubleclick - Toggle collaspe on task group");
                builder.AppendLine("Right Doubleclick - Split task into task parts");
                builder.AppendLine("Left Mouse Dragdrop onto another task - Group drag task under drop task");
                builder.AppendLine("Right Mouse Dragdrop onto another task part - Join task parts");
                builder.AppendLine("SHIFT + Left Mouse Dragdrop onto another task - Make drop task precedent of drag task");
                builder.AppendLine("ALT + Left Dragdrop onto another task - Ungroup drag task from drop task / Remove drop task from drag task precedent list");
                builder.AppendLine("SHIFT + Left Mouse Dragdrop - Order tasks");
                builder.AppendLine("SHIFT + Middle Click - Create new task");
                builder.AppendLine("ALT + Middle Click - Delete task");
                builder.AppendLine("Left Doubleclick - Toggle collaspe on task group");
                var size = g.MeasureString(builder.ToString(), e.Chart.Font);
                var background = new Rectangle(left, chart.Height - margin, (int)size.Width, (int)size.Height);
                background.Inflate(10, 10);
                g.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(background, Color.LightYellow, Color.Transparent, System.Drawing.Drawing2D.LinearGradientMode.Vertical), background);
                g.DrawRectangle(Pens.Brown, background);
                g.DrawString(builder.ToString(), chart.Font, color, new PointF(left, chart.Height - margin));


                // "pop matrix" -- restore the previous matrix
                e.Chart.EndBillboardMode(e.Graphics);
                // Demo: Static billboards end -----------------------------------
            }

            public bool PrintMode { get; set; }
        }
        #endregion overlay painter

        #region custom task and resource
        /// <summary>
        /// A custom resource of your own type (optional)
        /// </summary>
        [Serializable]
        public class MyResource
        {
            public string Name { get; set; }
        }
        /// <summary>
        /// A custom task of your own type deriving from the Task interface (optional)
        /// </summary>
        [Serializable]
        public class MyTask : Braincase.GanttChart.Task
        {
            public MyTask(ProjectManager manager)
                : base()
            {
                Manager = manager;
            }

            private ProjectManager Manager { get; set; }

            public new int Start { get { return base.Start; } set { Manager.SetStart(this, value); } }
            public new int End { get { return base.End; } set { Manager.SetEnd(this, value); } }
            public new int Duration { get { return base.Duration; } set { Manager.SetDuration(this, value); } }
            public new float Complete { get { return base.Complete; } set { Manager.SetComplete(this, value); } }
        }
        #endregion custom task and resource

        private void myGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (myGrid.Rows[myGrid.CurrentRow.Index].Cells["_Resource"].Selected==true)
            {
                DataGridViewComboBoxColumn cb = new DataGridViewComboBoxColumn();
                cb.Items.Add("");
                for(int i=0;i<Program.ods.Tables[1].Rows.Count;i++)
                {
                    cb.Items.Add(Program.ods.Tables[1].Rows[i][0]);
                }
             ((DataGridViewComboBoxColumn) myGrid.Columns["_Resource"]).DataSource = cb.Items;
            }
        }

        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            double total_cost=new double();
            for(int i=0;i<myGrid.Rows.Count;i++)
            {
                if (myGrid.Rows[i].Cells["_cost"].Value == null) continue;
                else total_cost += double.Parse(myGrid.Rows[i].Cells["_cost"].Value.ToString());

            }
            MessageBox.Show("The total Cost of the Project is:\t" + total_cost.ToString()+"\t"+Program.currency,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            panel3.Focus();
            if (Program.ods.Tables[1].Rows.Count <= 1)
            {
                MessageBox.Show("You don't have enough recourses to draw the chart");
            }
            else
            {
                MetroFramework.Forms.MetroForm a = new Form1();
                a.Show();
            }
        }
    }
}