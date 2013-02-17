namespace PharmInventory.Forms.Modals
{
    partial class EditLossAndAdjustment
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
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.refNotextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dtLossDate = new CalendarLib.DateTimePickerEx();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refNotextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dtLossDate);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnUpdate);
            this.layoutControl1.Controls.Add(this.refNotextEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(753, 249, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(354, 190);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::PharmInventory.Properties.Resources.cross;
            this.btnClose.Location = new System.Drawing.Point(263, 156);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 22);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::PharmInventory.Properties.Resources.disk;
            this.btnUpdate.Location = new System.Drawing.Point(181, 156);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(78, 22);
            this.btnUpdate.StyleController = this.layoutControl1;
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // refNotextEdit
            // 
            this.refNotextEdit.Location = new System.Drawing.Point(76, 12);
            this.refNotextEdit.Name = "refNotextEdit";
            this.refNotextEdit.Size = new System.Drawing.Size(266, 20);
            this.refNotextEdit.StyleController = this.layoutControl1;
            this.refNotextEdit.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(354, 190);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.refNotextEdit;
            this.layoutControlItem1.CustomizationFormText = "Refrence No";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(334, 24);
            this.layoutControlItem1.Text = "Refrence No";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnUpdate;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(169, 144);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(82, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(82, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(82, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnClose;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(251, 144);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(82, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(82, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(83, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 144);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(169, 26);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(169, 26);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(169, 26);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(334, 96);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.CustomizationFormText = "Date";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(302, 24);
            this.layoutControlItem5.Text = "Date";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 13);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.CustomizationFormText = "Date";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem5";
            this.layoutControlItem6.Size = new System.Drawing.Size(302, 24);
            this.layoutControlItem6.Text = "Date";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 13);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // dtLossDate
            // 
            this.dtLossDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtLossDate.CalendarFont = new System.Drawing.Font("Nyala", 10.75F);
            this.dtLossDate.CalendarForeColor = System.Drawing.Color.Black;
            this.dtLossDate.DayOfWeekCharacters = 2;
            this.dtLossDate.ForeColor = System.Drawing.Color.Black;
            this.dtLossDate.Location = new System.Drawing.Point(76, 36);
            this.dtLossDate.Name = "dtLossDate";
            this.dtLossDate.PopUpFontSize = 9.75F;
            this.dtLossDate.Size = new System.Drawing.Size(266, 20);
            this.dtLossDate.TabIndex = 11;
            this.dtLossDate.TextSelect = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtLossDate.Value = new System.DateTime(2010, 10, 13, 0, 0, 0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.dtLossDate;
            this.layoutControlItem7.CustomizationFormText = "Date";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(334, 24);
            this.layoutControlItem7.Text = "Date";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(60, 13);
            // 
            // EditLossAndAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 190);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditLossAndAdjustment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Loss and Adjustment Refrence No";
            this.Load += new System.EventHandler(this.EditLossAndAdjustment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.refNotextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        public DevExpress.XtraEditors.TextEdit refNotextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private CalendarLib.DateTimePickerEx dtLossDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}