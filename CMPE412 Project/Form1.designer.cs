namespace CMPE412_Project
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gridorg = new System.Windows.Forms.DataGridView();
            this.res = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rank_above = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.draw_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridorg)).BeginInit();
            this.SuspendLayout();
            // 
            // gridorg
            // 
            this.gridorg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridorg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.res,
            this.description,
            this.rank_above});
            this.gridorg.Location = new System.Drawing.Point(16, 31);
            this.gridorg.Margin = new System.Windows.Forms.Padding(4);
            this.gridorg.Name = "gridorg";
            this.gridorg.Size = new System.Drawing.Size(832, 444);
            this.gridorg.TabIndex = 0;
            this.gridorg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // res
            // 
            this.res.HeaderText = "Name";
            this.res.Name = "res";
            this.res.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.res.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.res.Width = 211;
            // 
            // description
            // 
            this.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            // 
            // rank_above
            // 
            this.rank_above.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rank_above.HeaderText = "Rank Above";
            this.rank_above.Name = "rank_above";
            this.rank_above.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rank_above.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // draw_button
            // 
            this.draw_button.Location = new System.Drawing.Point(364, 482);
            this.draw_button.Margin = new System.Windows.Forms.Padding(4);
            this.draw_button.Name = "draw_button";
            this.draw_button.Size = new System.Drawing.Size(121, 28);
            this.draw_button.TabIndex = 1;
            this.draw_button.Text = "Draw";
            this.draw_button.UseVisualStyleBackColor = true;
            this.draw_button.Click += new System.EventHandler(this.draw_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(633, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please enter the resources descriptions to the following boxes and then edit the " +
    "rank above section";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 528);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.draw_button);
            this.Controls.Add(this.gridorg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridorg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridorg;
        private System.Windows.Forms.Button draw_button;
        private System.Windows.Forms.DataGridViewComboBoxColumn res;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewComboBoxColumn rank_above;
        private System.Windows.Forms.Label label1;
    }
}

