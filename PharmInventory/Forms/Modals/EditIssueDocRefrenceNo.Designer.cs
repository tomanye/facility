namespace PharmInventory.Forms.Modals
{
    partial class EditIssueDocRefrenceNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditIssueDocRefrenceNo));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.refnotextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dtRecDate = new CalendarLib.DateTimePickerEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xpButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refnotextEdit.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // txtDate
            // 
            resources.ApplyResources(this.txtDate, "txtDate");
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.AccessibleDescription = resources.GetString("txtDate.Properties.AccessibleDescription");
            this.txtDate.Properties.AccessibleName = resources.GetString("txtDate.Properties.AccessibleName");
            this.txtDate.Properties.AutoHeight = ((bool)(resources.GetObject("txtDate.Properties.AutoHeight")));
            this.txtDate.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtDate.Properties.Mask.AutoComplete")));
            this.txtDate.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtDate.Properties.Mask.BeepOnError")));
            this.txtDate.Properties.Mask.EditMask = resources.GetString("txtDate.Properties.Mask.EditMask");
            this.txtDate.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtDate.Properties.Mask.IgnoreMaskBlank")));
            this.txtDate.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtDate.Properties.Mask.MaskType")));
            this.txtDate.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtDate.Properties.Mask.PlaceHolder")));
            this.txtDate.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtDate.Properties.Mask.SaveLiteral")));
            this.txtDate.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtDate.Properties.Mask.ShowPlaceHolders")));
            this.txtDate.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtDate.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtDate.Properties.NullValuePrompt = resources.GetString("txtDate.Properties.NullValuePrompt");
            this.txtDate.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtDate.Properties.NullValuePromptShowForEmptyValue")));
            this.txtDate.Properties.ReadOnly = true;
            // 
            // refnotextEdit
            // 
            resources.ApplyResources(this.refnotextEdit, "refnotextEdit");
            this.refnotextEdit.Name = "refnotextEdit";
            this.refnotextEdit.Properties.AccessibleDescription = resources.GetString("refnotextEdit.Properties.AccessibleDescription");
            this.refnotextEdit.Properties.AccessibleName = resources.GetString("refnotextEdit.Properties.AccessibleName");
            this.refnotextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("refnotextEdit.Properties.AutoHeight")));
            this.refnotextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("refnotextEdit.Properties.Mask.AutoComplete")));
            this.refnotextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("refnotextEdit.Properties.Mask.BeepOnError")));
            this.refnotextEdit.Properties.Mask.EditMask = resources.GetString("refnotextEdit.Properties.Mask.EditMask");
            this.refnotextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("refnotextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.refnotextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("refnotextEdit.Properties.Mask.MaskType")));
            this.refnotextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("refnotextEdit.Properties.Mask.PlaceHolder")));
            this.refnotextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("refnotextEdit.Properties.Mask.SaveLiteral")));
            this.refnotextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("refnotextEdit.Properties.Mask.ShowPlaceHolders")));
            this.refnotextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("refnotextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.refnotextEdit.Properties.NullValuePrompt = resources.GetString("refnotextEdit.Properties.NullValuePrompt");
            this.refnotextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("refnotextEdit.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // dtRecDate
            // 
            resources.ApplyResources(this.dtRecDate, "dtRecDate");
            this.dtRecDate.CalendarFont = new System.Drawing.Font("Nyala", 11.75F);
            this.dtRecDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtRecDate.DayOfWeekCharacters = 1;
            this.dtRecDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtRecDate.Name = "dtRecDate";
            this.dtRecDate.PopUpFontSize = 9.75F;
            this.dtRecDate.TextSelect = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtRecDate.Value = new System.DateTime(2012, 10, 25, 0, 0, 0, 0);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.dtRecDate);
            this.groupBox1.Controls.Add(this.xpButton1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // xpButton1
            // 
            resources.ApplyResources(this.xpButton1, "xpButton1");
            this.xpButton1.Image = global::PharmInventory.Properties.Resources.icon_accept;
            this.xpButton1.Name = "xpButton1";
            this.xpButton1.Click += new System.EventHandler(this.xpButton1_Click);
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Image = global::PharmInventory.Properties.Resources.disk;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // EditIssueDocRefrenceNo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.refnotextEdit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditIssueDocRefrenceNo";
            this.Load += new System.EventHandler(this.EditIssueDocRefrenceNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refnotextEdit.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private DevExpress.XtraEditors.TextEdit refnotextEdit;
        private CalendarLib.DateTimePickerEx dtRecDate;
        private DevExpress.XtraEditors.SimpleButton xpButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;


    }
}