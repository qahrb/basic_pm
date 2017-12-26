using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO;
using System.Reflection;

namespace CMPE412_Project
{
    
    public partial class Project : MetroFramework.Forms.MetroForm
    {
        string Succes_icon, failure_icon,countries;
        ErrorProvider err = new ErrorProvider();
        ErrorProvider err1 = new ErrorProvider();
        ErrorProvider err2 = new ErrorProvider();
        int count_filled = 0;

        public Project()
        {
            InitializeComponent();
        }

        private void Project_Load(object sender, EventArgs e)
        {
            currencyText.Enabled = false;
            directoryText.Enabled = false;
            string line;
            string executableLocation = Path.GetDirectoryName(
               Assembly.GetExecutingAssembly().Location);
                Succes_icon = Path.Combine(executableLocation, "suc.ico");
               failure_icon = Path.Combine(executableLocation, "fail.ico");
               countries = Path.Combine(executableLocation, "Countries.txt");
                    StreamReader file =
                    new StreamReader(countries);
            while (true)
            {
                 line = file.ReadLine();
                if (line == null)
                    break;
                String[] t = line.Split(';');
                countryCmbox.Items.Add(t[0]);

            }
            countryCmbox.DropDownHeight = countryCmbox.Font.Height * 6;
            file.Close();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(nameText.Text=="Name" && nameText.Focused==true)
            {
                nameText.Text = "";
            }
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            metroButton5.Enabled = false;
            timer1.Start();
        }
        
        private void metroButton5_Click(object sender, EventArgs e)
        {
            try
            {
                Program.path = directoryText.Text + @"\" + nameText.Text + ".ale";
                FileStream fs = File.Create(Program.path);
                fs.Close();
                Program.number_of_working_hours = int.Parse(nmb.Text);
                Program.start = startDate.Value;
                Program.country = countryCmbox.Text;
                Program.currency = currencyText.Text;
                if (typeText.Text != null || typeText.Text != "")
                {
                    Program.type = typeText.Text;
                }
                if (descriptionText.Text != null || descriptionText.Text != "")
                {
                    Program.type = descriptionText.Text;
                }
                MetroFramework.Forms.MetroForm f = new Interface();
                f.Show();
                this.Hide();
            }catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }


        }

   
        private void nameText_Leave(object sender, EventArgs e)
        {
     

        }

        private void typeText_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog op = new FolderBrowserDialog();
            
            
            if (op.ShowDialog() == DialogResult.OK)
            {
                string path = op.SelectedPath;
                directoryText.Text = path;
            }
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if(nameText.Text=="" || startDate.Text == "" || countryCmbox.Text == "" ||
                currencyText.Text == "" || nmb.Text == "" || directoryText.Text=="")
            {
                metroButton5.Enabled = false;
            }
            else
            {
                metroButton5.Enabled = true;
            }
        }

        private void countryCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string executableLocation = Path.GetDirectoryName(
               Assembly.GetExecutingAssembly().Location);
            countries = Path.Combine(executableLocation, "Countries.txt");
            StreamReader file =
            new StreamReader(countries);
            String country = countryCmbox.Text ;

            while (true)
            {
                String line = file.ReadLine();
                String[] t = line.Split(';');
                if (t[0] == country)
                {
                    currencyText.Text = t[1];
                    break;
                }

            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            MetroFramework.Forms.MetroForm f = new Menu();
            f.Show();
            this.Hide();

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            nameText.Clear();
            typeText.Clear();
            startDate.Value = DateTime.Now;
            descriptionText.Clear();
            countryCmbox.Text = "";
            currencyText.Clear();
            nmb.Clear();
            directoryText.Clear();
        }

        private void countryCmbox_TextChanged(object sender, EventArgs e)
        {
            if (countryCmbox.Text == "" || countryCmbox.Text == null)
            {

                err2.SetError(countryCmbox, "Missing");
                err2.Icon = new Icon(failure_icon, new Size(8, 8));
                err2.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                count_filled--;

            }
            else
            {
                err2.Clear();
                err2.SetError(countryCmbox, "This field had been filled successfully");
                err2.Icon = new Icon(Succes_icon);
                err2.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                count_filled++;
            }
        }

        private void nameText_TextChanged(object sender, EventArgs e)
        {

            if (nameText.Text == "" || nameText.Text == null){

                err.SetError(nameText, "working");
                err.Icon = new Icon(failure_icon, new Size(8, 8));
                err.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                count_filled--;
                
            }
            else
            {
                err.Clear();
                err.SetError(nameText, "This field had been filled successfully");
                err.Icon = new Icon(Succes_icon);
                err.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                count_filled++;
            }
        }
    }
}