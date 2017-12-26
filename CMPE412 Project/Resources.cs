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
    public partial class Resources : MetroFramework.Forms.MetroForm
    {
        public Resources()
        {
            InitializeComponent();
        }

        private void Resources_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.ods.Tables[1].Rows.Count; i++)
            {
                
                myGrid.Rows.Add();
                myGrid.Rows[i].Cells[0].Value = Program.ods.Tables[1].Rows[i][0].ToString();
                myGrid.Rows[i].Cells[1].Value = Program.ods.Tables[1].Rows[i][1].ToString();
                myGrid.Rows[i].Cells[2].Value = Program.ods.Tables[1].Rows[i][2].ToString();
                myGrid.Rows[i].Cells[3].Value = "true";
                myGrid.Rows[i].Cells[4].Value = i.ToString();
                
            }
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void myGrid_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            
            if (myGrid.Rows[myGrid.CurrentRow.Index].Cells[3].Value != null && myGrid.Rows[myGrid.CurrentRow.Index].Cells[3].Value.ToString() == "true")
            {
                    if (myGrid.Rows[myGrid.CurrentRow.Index].Cells[0].Value != null &&
                    myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value != null
                    && myGrid.Rows[myGrid.CurrentRow.Index].Cells[2].Value != null)
                    {

                            String name = myGrid.Rows[myGrid.CurrentRow.Index].Cells[0].Value.ToString();
                            Double salary;
                        if (Double.TryParse(myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value.ToString(), out salary) == false)
                        {
                            MessageBox.Show("please type an appropriate value for the salary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value = "";
                        }
                        else
                        {
                            int pos = int.Parse(myGrid.Rows[myGrid.CurrentRow.Index].Cells[4].Value.ToString());
                            salary = Double.Parse(myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value.ToString());
                            String email = myGrid.Rows[myGrid.CurrentRow.Index].Cells[2].Value.ToString();
                        Program.ods.Tables[1].Rows[pos][0] = name;
                        Program.ods.Tables[1].Rows[pos][1] = salary;
                        Program.ods.Tables[1].Rows[pos][2] = email;
                        
                    }
                        
                    }
             }
            else
            {
                if (myGrid.Rows[myGrid.CurrentRow.Index].Cells[0].Value != null &&
                   myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value != null
                   && myGrid.Rows[myGrid.CurrentRow.Index].Cells[2].Value != null)
                {
                    int pos = -1;
                    String name = myGrid.Rows[myGrid.CurrentRow.Index].Cells[0].Value.ToString();
                    Double salary;
                    if (Double.TryParse(myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value.ToString(), out salary) == false)
                    {
                        MessageBox.Show("please type an appropriate value for the salary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value = "";
                    }
                    else
                    {
                       
                        salary = Double.Parse(myGrid.Rows[myGrid.CurrentRow.Index].Cells[1].Value.ToString());
                        String email = myGrid.Rows[myGrid.CurrentRow.Index].Cells[2].Value.ToString();
                        Program.ods.Tables[1].Rows.Add( name,salary,email);
                        for (int k = 0; k < Program.ods.Tables[1].Rows.Count; k++)
                        {
                            if (name == Program.ods.Tables[1].Rows[k][0].ToString())
                            { pos = k; break; }
                        }
                        myGrid.Rows[myGrid.CurrentRow.Index].Cells[4].Value = pos.ToString();
                        myGrid.Rows[myGrid.CurrentRow.Index].Cells[3].Value = "true";

                    }

                }
            }
            
        }

        private void myGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            String name = myGrid.Rows[myGrid.CurrentRow.Index].Cells[0].Value.ToString();
            int pos = -1;
            for (int i = 0; i < Program.ods.Tables[1].Rows.Count; i++)
            {
                if (Program.ods.Tables[1].Rows[i][0].ToString() == name)
                {
                    pos = i;
                }
            }
            Program.ods.Tables[1].Rows.RemoveAt(pos);
            MessageBox.Show(Program.ods.Tables[1].Rows.Count.ToString());
        }

        private void myGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
           
        }

        private void myGrid_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void myGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void myGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if ((myGrid.Columns[e.ColumnIndex].Name == "Name") && (myGrid.Rows[myGrid.CurrentRow.Index].Cells[0].Value != null))
            {
                int count = 0;
                String name = myGrid.Rows[myGrid.CurrentRow.Index].Cells[0].Value.ToString();
                for (int i = 0; i < myGrid.Rows.Count - 1; i++)
                {
                    if (myGrid.Rows[i].Cells[0].Value.ToString() == name)
                    {
                        count++;
                        if (count > 1)
                        {
                            MessageBox.Show("A resource name can't be duplicate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            myGrid.Rows[myGrid.CurrentRow.Index].Cells[0].Value = null;
                            break;
                        }
                    }
                }
            }
        
    }
    }
}




  