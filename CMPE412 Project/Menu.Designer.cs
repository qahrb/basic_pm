namespace CMPE412_Project
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.Title_2 = new MetroFramework.Controls.MetroTile();
            this.lblTextTransition1 = new MetroFramework.Controls.MetroLabel();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTile1
            // 
            resources.ApplyResources(this.metroTile1, "metroTile1");
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.UseSelectable = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // Title_2
            // 
            resources.ApplyResources(this.Title_2, "Title_2");
            this.Title_2.ActiveControl = null;
            this.Title_2.Name = "Title_2";
            this.Title_2.Style = MetroFramework.MetroColorStyle.Pink;
            this.Title_2.UseSelectable = true;
            this.Title_2.Click += new System.EventHandler(this.Title_2_Click);
            // 
            // lblTextTransition1
            // 
            resources.ApplyResources(this.lblTextTransition1, "lblTextTransition1");
            this.lblTextTransition1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTextTransition1.Name = "lblTextTransition1";
            this.lblTextTransition1.Click += new System.EventHandler(this.asasù_Click);
            // 
            // metroTile2
            // 
            resources.ApplyResources(this.metroTile2, "metroTile2");
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // metroTile3
            // 
            resources.ApplyResources(this.metroTile3, "metroTile3");
            this.metroTile3.ActiveControl = null;
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTile3.UseSelectable = true;
            this.metroTile3.Click += new System.EventHandler(this.metroTile3_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.Name = "metroLabel1";
            // 
            // metroPanel1
            // 
            resources.ApplyResources(this.metroPanel1, "metroPanel1");
            this.metroPanel1.Controls.Add(this.metroTile2);
            this.metroPanel1.Controls.Add(this.Title_2);
            this.metroPanel1.Controls.Add(this.metroTile1);
            this.metroPanel1.Controls.Add(this.metroTile3);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroPanel2
            // 
            resources.ApplyResources(this.metroPanel2, "metroPanel2");
            this.metroPanel2.Controls.Add(this.lblTextTransition1);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroPanel3
            // 
            resources.ApplyResources(this.metroPanel3, "metroPanel3");
            this.metroPanel3.Controls.Add(this.metroLabel2);
            this.metroPanel3.Controls.Add(this.metroLabel1);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // metroLabel2
            // 
            resources.ApplyResources(this.metroLabel2, "metroLabel2");
            this.metroLabel2.Name = "metroLabel2";
            // 
            // Menu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel3);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Menu";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile Title_2;
        private MetroFramework.Controls.MetroLabel lblTextTransition1;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile metroTile3;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}

