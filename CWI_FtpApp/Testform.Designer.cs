namespace ICW_FtpApp
{
    partial class Testform
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tpStatic = new System.Windows.Forms.TabPage();
            this.lvwTables = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdOk = new System.Windows.Forms.Button();
            this.pnlLeft.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tpStatic.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlLeft.Controls.Add(this.tabMain);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(1603, 1264);
            this.pnlLeft.TabIndex = 3;
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tpStatic);
            this.tabMain.Location = new System.Drawing.Point(16, 11);
            this.tabMain.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1582, 1246);
            this.tabMain.TabIndex = 0;
            // 
            // tpStatic
            // 
            this.tpStatic.Controls.Add(this.lvwTables);
            this.tpStatic.Location = new System.Drawing.Point(10, 47);
            this.tpStatic.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tpStatic.Name = "tpStatic";
            this.tpStatic.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tpStatic.Size = new System.Drawing.Size(1562, 1189);
            this.tpStatic.TabIndex = 1;
            this.tpStatic.Text = "Some Data";
            this.tpStatic.UseVisualStyleBackColor = true;
            // 
            // lvwTables
            // 
            this.lvwTables.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvwTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvwTables.FullRowSelect = true;
            this.lvwTables.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwTables.Location = new System.Drawing.Point(28, 34);
            this.lvwTables.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lvwTables.Name = "lvwTables";
            this.lvwTables.Size = new System.Drawing.Size(1510, 1126);
            this.lvwTables.TabIndex = 19;
            this.lvwTables.UseCompatibleStateImageBehavior = false;
            this.lvwTables.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 200;
            // 
            // cmdOk
            // 
            this.cmdOk.BackColor = System.Drawing.SystemColors.Control;
            this.cmdOk.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdOk.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOk.Location = new System.Drawing.Point(1801, 174);
            this.cmdOk.Margin = new System.Windows.Forms.Padding(7);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdOk.Size = new System.Drawing.Size(178, 61);
            this.cmdOk.TabIndex = 21;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseVisualStyleBackColor = false;
            // 
            // Testform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2044, 1264);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.pnlLeft);
            this.Name = "Testform";
            this.Text = "Testform";
            this.pnlLeft.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tpStatic.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tpStatic;
        private System.Windows.Forms.ListView lvwTables;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.Button cmdOk;

    }
}