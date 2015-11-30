namespace PharmInventory.CustomControl
{
    partial class ScannerInput
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScanProgress = new System.Windows.Forms.ProgressBar();
            this.scanTextInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ScanProgress
            // 
            this.ScanProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ScanProgress.Location = new System.Drawing.Point(0, 26);
            this.ScanProgress.Name = "ScanProgress";
            this.ScanProgress.Size = new System.Drawing.Size(400, 124);
            this.ScanProgress.TabIndex = 0;
            // 
            // scanTextInput
            // 
            this.scanTextInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.scanTextInput.ForeColor = System.Drawing.Color.Gray;
            this.scanTextInput.Location = new System.Drawing.Point(0, 0);
            this.scanTextInput.Name = "scanTextInput";
            this.scanTextInput.Size = new System.Drawing.Size(400, 20);
            this.scanTextInput.TabIndex = 1;
            // 
            // ScannerInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scanTextInput);
            this.Controls.Add(this.ScanProgress);
            this.Name = "ScannerInput";
            this.Size = new System.Drawing.Size(400, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ScanProgress;
        private System.Windows.Forms.TextBox scanTextInput;
    }
}
