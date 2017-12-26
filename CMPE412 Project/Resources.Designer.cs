namespace CMPE412_Project
{
    partial class Resources
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            this.myGrid = new MetroFramework.Controls.MetroGrid();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._added = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._pos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.myGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // myGrid
            // 
            this.myGrid.AllowUserToResizeRows = false;
            this.myGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.myGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.myGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.myGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.myGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Salary,
            this.Email,
            this._added,
            this._pos});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.myGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.myGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGrid.EnableHeadersVisualStyles = false;
            this.myGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.myGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myGrid.Location = new System.Drawing.Point(20, 60);
            this.myGrid.Name = "myGrid";
            this.myGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.myGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.myGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.myGrid.RowTemplate.Height = 24;
            this.myGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.myGrid.Size = new System.Drawing.Size(903, 445);
            this.myGrid.TabIndex = 0;
            this.myGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_CellContentClick);
            this.myGrid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.myGrid_CellLeave);
            this.myGrid.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.myGrid_CellValidated);
            this.myGrid.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.myGrid_RowLeave);
            this.myGrid.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.myGrid_RowValidated);
            this.myGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.myGrid_UserAddedRow);
            this.myGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.myGrid_UserDeletingRow);
            // 
            // Name
            // 
            this.Name.FillWeight = 300F;
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.Width = 300;
            // 
            // Salary
            // 
            this.Salary.HeaderText = "Salary per hour";
            this.Salary.Name = "Salary";
            this.Salary.Width = 200;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.Width = 300;
            // 
            // _added
            // 
            this._added.HeaderText = "Added";
            this._added.Name = "_added";
            this._added.Visible = false;
            // 
            // _pos
            // 
            this._pos.HeaderText = "pos";
            this._pos.Name = "_pos";
            this._pos.Visible = false;
            // 
            // Resources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 525);
            this.Controls.Add(this.myGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         
            this.Text = "Resources";
            this.Load += new System.EventHandler(this.Resources_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroGrid myGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn _added;
        private System.Windows.Forms.DataGridViewTextBoxColumn _pos;
    }
}