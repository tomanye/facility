namespace PharmInventory.Forms.SummaryReports
{
    partial class ActivityLogReports
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.xtraTabActivityLog = new DevExpress.XtraTab.XtraTabControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.receiveLog = new DevExpress.XtraTab.XtraTabPage();
            this.issueLog = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabActivityLog)).BeginInit();
            this.xtraTabActivityLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.xtraTabActivityLog);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(953, 427);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(953, 427);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // xtraTabActivityLog
            // 
            this.xtraTabActivityLog.Location = new System.Drawing.Point(12, 12);
            this.xtraTabActivityLog.Name = "xtraTabActivityLog";
            this.xtraTabActivityLog.SelectedTabPage = this.receiveLog;
            this.xtraTabActivityLog.Size = new System.Drawing.Size(929, 403);
            this.xtraTabActivityLog.TabIndex = 4;
            this.xtraTabActivityLog.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.receiveLog,
            this.issueLog});
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.xtraTabActivityLog;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(933, 407);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // receiveLog
            // 
            this.receiveLog.Name = "receiveLog";
            this.receiveLog.Size = new System.Drawing.Size(923, 375);
            this.receiveLog.Text = "Receive Log";
            // 
            // issueLog
            // 
            this.issueLog.Name = "issueLog";
            this.issueLog.Size = new System.Drawing.Size(923, 375);
            this.issueLog.Text = "Issue Log";
            // 
            // ActivityLogReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 427);
            this.Controls.Add(this.layoutControl1);
            this.Name = "ActivityLogReports";
            this.Tag = "Activity Log Reports";
            this.Text = "Activity Log Reports";
            this.Load += new System.EventHandler(this.ActivityLogReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabActivityLog)).EndInit();
            this.xtraTabActivityLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraTab.XtraTabControl xtraTabActivityLog;
        private DevExpress.XtraTab.XtraTabPage receiveLog;
        private DevExpress.XtraTab.XtraTabPage issueLog;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}