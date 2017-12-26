using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

namespace CMPE412_Project
{
    public partial class Menu : MetroFramework.Forms.MetroForm
    {
        private const string STRING_ENGLISH = "Welcome to BASIC PM";
        private const string STRING_FRENCH = "Bienvenue au BASIC PM";
        private const string STRING_ARABIC = "BASIC PM مرحبا بكم في";
        private const string STRING_TURKISH = "BASIC PM Projesine Hoş Geldiniz";
        private const string STRING_GREEK = "Καλώς ήρθατε στο CMPE412 Έργου";
        public Menu()
        {
            InitializeComponent();
        }

        private void metroUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         Label_location=lblTextTransition1.Location.X;
         timer1.Start();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            MetroFramework.Forms.MetroForm f = new Project();
            f.Show();
            this.Hide();            
            
        }

        private void Title_2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            //op.Filter = "Ale Files (.ale) | *.ale | Text Files (.txt)|*.txt";
          

            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Program.path = op.FileName;
            }
            if(Program.path!="")
            {
                MetroFramework.Forms.MetroForm f = new Basic_PM();
                f.Show();
                this.Hide();
            }
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Title_2.Style = MetroFramework.MetroColorStyle.Pink;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void asasù_Click(object sender, EventArgs e)
        {

        }
        public int Label_location;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            string strText1;
            if (lblTextTransition1.Text == STRING_ENGLISH)
                strText1 = STRING_FRENCH;
            else
                if (lblTextTransition1.Text == STRING_FRENCH)
            {
                strText1 = STRING_ARABIC;
                Label_location += 9;
                lblTextTransition1.Location = new Point(Label_location, lblTextTransition1.Location.Y);
                Label_location -= 9;
            }
                  else
                    if (lblTextTransition1.Text == STRING_ARABIC)
                     {
                        strText1 = STRING_TURKISH;
                        Label_location -= 15;
                        lblTextTransition1.Location = new Point(Label_location, lblTextTransition1.Location.Y);
                        Label_location += 15;
                      }
                     else
                        //if (lblTextTransition1.Text == STRING_TURKISH)
                        //{
                        //    strText1 = STRING_GREEK;
                        //    Label_location -= 24;
                        //    lblTextTransition1.Location = new Point(Label_location, lblTextTransition1.Location.Y);
                        //    Label_location += 24;
                        //}
                        //else
                        {
                            strText1 = STRING_ENGLISH;
                            lblTextTransition1.Location = new Point(Label_location, lblTextTransition1.Location.Y);
                        }




            // We create a transition to animate all four properties at the same time...
            Transition t = new Transition(new TransitionType_Linear(2000));
            t.add(lblTextTransition1, "Text", strText1);
            // t.add(lblTextTransition2, "Text", strText2);
            t.run();

        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure that you want to exit ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                timer1.Stop();
                Application.Exit();
            }
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EMU STUDENTS", "About team", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
