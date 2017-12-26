namespace CMPE412_Project
{
    partial class Project
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Project));
            this.nameText = new MetroFramework.Controls.MetroTextBox();
            this.directoryText = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.nmb = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.currencyText = new MetroFramework.Controls.MetroTextBox();
            this.countryCmbox = new MetroFramework.Controls.MetroComboBox();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.descriptionText = new MetroFramework.Controls.MetroTextBox();
            this.startDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.typeText = new MetroFramework.Controls.MetroTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameText
            // 
            // 
            // 
            // 
            this.nameText.CustomButton.Image = null;
            this.nameText.CustomButton.Location = new System.Drawing.Point(291, 1);
            this.nameText.CustomButton.Name = "";
            this.nameText.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.nameText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nameText.CustomButton.TabIndex = 1;
            this.nameText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nameText.CustomButton.UseSelectable = true;
            this.nameText.CustomButton.Visible = false;
            this.nameText.Lines = new string[0];
            this.nameText.Location = new System.Drawing.Point(395, 104);
            this.nameText.MaxLength = 32767;
            this.nameText.Name = "nameText";
            this.nameText.PasswordChar = '\0';
            this.nameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nameText.SelectedText = "";
            this.nameText.SelectionLength = 0;
            this.nameText.SelectionStart = 0;
            this.nameText.ShortcutsEnabled = true;
            this.nameText.Size = new System.Drawing.Size(313, 23);
            this.nameText.TabIndex = 2;
            this.nameText.UseSelectable = true;
            this.nameText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nameText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.nameText.TextChanged += new System.EventHandler(this.nameText_TextChanged);
            this.nameText.Leave += new System.EventHandler(this.nameText_Leave);
            // 
            // directoryText
            // 
            // 
            // 
            // 
            this.directoryText.CustomButton.Image = null;
            this.directoryText.CustomButton.Location = new System.Drawing.Point(209, 1);
            this.directoryText.CustomButton.Name = "";
            this.directoryText.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.directoryText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.directoryText.CustomButton.TabIndex = 1;
            this.directoryText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.directoryText.CustomButton.UseSelectable = true;
            this.directoryText.CustomButton.Visible = false;
            this.directoryText.Lines = new string[0];
            this.directoryText.Location = new System.Drawing.Point(395, 206);
            this.directoryText.MaxLength = 32767;
            this.directoryText.Name = "directoryText";
            this.directoryText.PasswordChar = '\0';
            this.directoryText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.directoryText.SelectedText = "";
            this.directoryText.SelectionLength = 0;
            this.directoryText.SelectionStart = 0;
            this.directoryText.ShortcutsEnabled = true;
            this.directoryText.Size = new System.Drawing.Size(231, 23);
            this.directoryText.TabIndex = 3;
            this.directoryText.UseSelectable = true;
            this.directoryText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.directoryText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(15, 13);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(443, 25);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Step 1: Fill in the information about your project";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(295, 107);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(50, 20);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Name:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(275, 209);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(70, 20);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Directory:";
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(632, 206);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(76, 23);
            this.metroButton1.TabIndex = 7;
            this.metroButton1.Text = "Select";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.metroLabel10);
            this.panel1.Controls.Add(this.nmb);
            this.panel1.Controls.Add(this.metroLabel9);
            this.panel1.Controls.Add(this.metroLabel8);
            this.panel1.Controls.Add(this.currencyText);
            this.panel1.Controls.Add(this.countryCmbox);
            this.panel1.Controls.Add(this.metroButton3);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.metroButton5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.metroButton2);
            this.panel1.Controls.Add(this.metroLabel7);
            this.panel1.Controls.Add(this.descriptionText);
            this.panel1.Controls.Add(this.startDate);
            this.panel1.Controls.Add(this.metroLabel5);
            this.panel1.Controls.Add(this.metroLabel4);
            this.panel1.Controls.Add(this.typeText);
            this.panel1.Controls.Add(this.metroButton1);
            this.panel1.Controls.Add(this.metroLabel3);
            this.panel1.Controls.Add(this.metroLabel2);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Controls.Add(this.nameText);
            this.panel1.Controls.Add(this.directoryText);
            this.panel1.Location = new System.Drawing.Point(8, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 561);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(172, 439);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(217, 20);
            this.metroLabel10.TabIndex = 24;
            this.metroLabel10.Text = "Number of working hour per day:";
            // 
            // nmb
            // 
            // 
            // 
            // 
            this.nmb.CustomButton.Image = null;
            this.nmb.CustomButton.Location = new System.Drawing.Point(291, 1);
            this.nmb.CustomButton.Name = "";
            this.nmb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.nmb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nmb.CustomButton.TabIndex = 1;
            this.nmb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nmb.CustomButton.UseSelectable = true;
            this.nmb.CustomButton.Visible = false;
            this.nmb.ForeColor = System.Drawing.Color.Green;
            this.nmb.Lines = new string[0];
            this.nmb.Location = new System.Drawing.Point(395, 439);
            this.nmb.MaxLength = 32767;
            this.nmb.Name = "nmb";
            this.nmb.PasswordChar = '\0';
            this.nmb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nmb.SelectedText = "";
            this.nmb.SelectionLength = 0;
            this.nmb.SelectionStart = 0;
            this.nmb.ShortcutsEnabled = true;
            this.nmb.Size = new System.Drawing.Size(313, 23);
            this.nmb.TabIndex = 23;
            this.nmb.UseSelectable = true;
            this.nmb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nmb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(268, 410);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(69, 20);
            this.metroLabel9.TabIndex = 22;
            this.metroLabel9.Text = "Currency:";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(275, 374);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(62, 20);
            this.metroLabel8.TabIndex = 21;
            this.metroLabel8.Text = "Country:";
            // 
            // currencyText
            // 
            // 
            // 
            // 
            this.currencyText.CustomButton.Image = null;
            this.currencyText.CustomButton.Location = new System.Drawing.Point(291, 1);
            this.currencyText.CustomButton.Name = "";
            this.currencyText.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.currencyText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.currencyText.CustomButton.TabIndex = 1;
            this.currencyText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.currencyText.CustomButton.UseSelectable = true;
            this.currencyText.CustomButton.Visible = false;
            this.currencyText.Lines = new string[0];
            this.currencyText.Location = new System.Drawing.Point(395, 410);
            this.currencyText.MaxLength = 32767;
            this.currencyText.Name = "currencyText";
            this.currencyText.PasswordChar = '\0';
            this.currencyText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.currencyText.SelectedText = "";
            this.currencyText.SelectionLength = 0;
            this.currencyText.SelectionStart = 0;
            this.currencyText.ShortcutsEnabled = true;
            this.currencyText.Size = new System.Drawing.Size(313, 23);
            this.currencyText.TabIndex = 20;
            this.currencyText.UseSelectable = true;
            this.currencyText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.currencyText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // countryCmbox
            // 
            this.countryCmbox.FormattingEnabled = true;
            this.countryCmbox.ItemHeight = 24;
            this.countryCmbox.Location = new System.Drawing.Point(395, 374);
            this.countryCmbox.MaxLength = 4;
            this.countryCmbox.Name = "countryCmbox";
            this.countryCmbox.Size = new System.Drawing.Size(313, 30);
            this.countryCmbox.TabIndex = 19;
            this.countryCmbox.UseSelectable = true;
            this.countryCmbox.SelectedIndexChanged += new System.EventHandler(this.countryCmbox_SelectedIndexChanged);
            this.countryCmbox.TextChanged += new System.EventHandler(this.countryCmbox_TextChanged);
            // 
            // metroButton3
            // 
            this.metroButton3.BackColor = System.Drawing.Color.Red;
            this.metroButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroButton3.Location = new System.Drawing.Point(446, 512);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(121, 42);
            this.metroButton3.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton3.TabIndex = 14;
            this.metroButton3.Text = "Clear";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.UseStyleColors = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel3.Location = new System.Drawing.Point(178, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(658, 3);
            this.panel3.TabIndex = 18;
            // 
            // metroButton5
            // 
            this.metroButton5.BackColor = System.Drawing.Color.Red;
            this.metroButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroButton5.Enabled = false;
            this.metroButton5.Location = new System.Drawing.Point(573, 512);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(121, 42);
            this.metroButton5.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton5.TabIndex = 13;
            this.metroButton5.Text = "Next";
            this.metroButton5.UseSelectable = true;
            this.metroButton5.UseStyleColors = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Location = new System.Drawing.Point(178, 494);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(658, 3);
            this.panel2.TabIndex = 15;
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.Color.Red;
            this.metroButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroButton2.Location = new System.Drawing.Point(319, 512);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(121, 42);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton2.TabIndex = 12;
            this.metroButton2.Text = "Previous";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.UseStyleColors = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(263, 235);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(82, 20);
            this.metroLabel7.TabIndex = 17;
            this.metroLabel7.Text = "Description:";
            // 
            // descriptionText
            // 
            // 
            // 
            // 
            this.descriptionText.CustomButton.Image = null;
            this.descriptionText.CustomButton.Location = new System.Drawing.Point(181, 1);
            this.descriptionText.CustomButton.Name = "";
            this.descriptionText.CustomButton.Size = new System.Drawing.Size(131, 131);
            this.descriptionText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.descriptionText.CustomButton.TabIndex = 1;
            this.descriptionText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.descriptionText.CustomButton.UseSelectable = true;
            this.descriptionText.CustomButton.Visible = false;
            this.descriptionText.Lines = new string[0];
            this.descriptionText.Location = new System.Drawing.Point(395, 235);
            this.descriptionText.MaxLength = 32767;
            this.descriptionText.Multiline = true;
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.PasswordChar = '\0';
            this.descriptionText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.descriptionText.SelectedText = "";
            this.descriptionText.SelectionLength = 0;
            this.descriptionText.SelectionStart = 0;
            this.descriptionText.ShortcutsEnabled = true;
            this.descriptionText.Size = new System.Drawing.Size(313, 133);
            this.descriptionText.TabIndex = 16;
            this.descriptionText.UseSelectable = true;
            this.descriptionText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.descriptionText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(395, 162);
            this.startDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(313, 30);
            this.startDate.TabIndex = 15;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(255, 172);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(90, 20);
            this.metroLabel5.TabIndex = 11;
            this.metroLabel5.Text = "Starting date:";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(303, 136);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(42, 20);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "Type:";
            // 
            // typeText
            // 
            // 
            // 
            // 
            this.typeText.CustomButton.Image = null;
            this.typeText.CustomButton.Location = new System.Drawing.Point(291, 1);
            this.typeText.CustomButton.Name = "";
            this.typeText.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.typeText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.typeText.CustomButton.TabIndex = 1;
            this.typeText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.typeText.CustomButton.UseSelectable = true;
            this.typeText.CustomButton.Visible = false;
            this.typeText.Lines = new string[0];
            this.typeText.Location = new System.Drawing.Point(395, 133);
            this.typeText.MaxLength = 32767;
            this.typeText.Name = "typeText";
            this.typeText.PasswordChar = '\0';
            this.typeText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.typeText.SelectedText = "";
            this.typeText.SelectionLength = 0;
            this.typeText.SelectionStart = 0;
            this.typeText.ShortcutsEnabled = true;
            this.typeText.Size = new System.Drawing.Size(313, 23);
            this.typeText.TabIndex = 8;
            this.typeText.UseSelectable = true;
            this.typeText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.typeText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.typeText.TextChanged += new System.EventHandler(this.typeText_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 666);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Project";
            this.Text = "Project Creation";
            this.Load += new System.EventHandler(this.Project_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox directoryText;
        private MetroFramework.Controls.MetroTextBox nameText;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox typeText;
        private MetroFramework.Controls.MetroDateTime startDate;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox descriptionText;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroComboBox countryCmbox;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox currencyText;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox nmb;
        private System.Windows.Forms.Timer timer1;
    }
}