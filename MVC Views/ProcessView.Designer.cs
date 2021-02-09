namespace MVC_Views
{
    partial class ProcessView
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
            this.lvwProcesses = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvwProcesses
            // 
            this.lvwProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProcesses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwProcesses.FullRowSelect = true;
            this.lvwProcesses.Location = new System.Drawing.Point(413, 140);
            this.lvwProcesses.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lvwProcesses.MultiSelect = false;
            this.lvwProcesses.Name = "lvwProcesses";
            this.lvwProcesses.Size = new System.Drawing.Size(830, 619);
            this.lvwProcesses.TabIndex = 41;
            this.lvwProcesses.UseCompatibleStateImageBehavior = false;
            this.lvwProcesses.View = System.Windows.Forms.View.Details;
            // 
            // ProcessView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 899);
            this.Controls.Add(this.lvwProcesses);
            this.Name = "ProcessView";
            this.Text = "ProcessView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwProcesses;
    }
}