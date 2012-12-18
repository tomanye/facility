namespace PharmInventory.Forms.Modals
{
    partial class EditLossForm
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
            this.btnCancelLoss = new DevExpress.XtraEditors.SimpleButton();
            this.txtTotalCost = new DevExpress.XtraEditors.TextEdit();
            this.txtPricePerPack = new DevExpress.XtraEditors.TextEdit();
            this.expirydateEdit = new DevExpress.XtraEditors.DateEdit();
            this.txtBatchNo = new DevExpress.XtraEditors.TextEdit();
            this.txtQtyPerPack = new DevExpress.XtraEditors.TextEdit();
            this.txtPackQty = new DevExpress.XtraEditors.TextEdit();
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.btnUpdateLoss = new DevExpress.XtraEditors.SimpleButton();
            this.txtStockCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtUnit = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPricePerPack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expirydateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expirydateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBatchNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyPerPack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtUnit);
            this.layoutControl1.Controls.Add(this.btnCancelLoss);
            this.layoutControl1.Controls.Add(this.txtTotalCost);
            this.layoutControl1.Controls.Add(this.txtPricePerPack);
            this.layoutControl1.Controls.Add(this.expirydateEdit);
            this.layoutControl1.Controls.Add(this.txtBatchNo);
            this.layoutControl1.Controls.Add(this.txtQtyPerPack);
            this.layoutControl1.Controls.Add(this.txtPackQty);
            this.layoutControl1.Controls.Add(this.txtItemName);
            this.layoutControl1.Controls.Add(this.btnUpdateLoss);
            this.layoutControl1.Controls.Add(this.txtStockCode);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(500, 8, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(455, 195);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCancelLoss
            // 
            this.btnCancelLoss.Location = new System.Drawing.Point(365, 156);
            this.btnCancelLoss.Name = "btnCancelLoss";
            this.btnCancelLoss.Size = new System.Drawing.Size(78, 27);
            this.btnCancelLoss.StyleController = this.layoutControl1;
            this.btnCancelLoss.TabIndex = 12;
            this.btnCancelLoss.Text = "Cancel";
            this.btnCancelLoss.Click += new System.EventHandler(this.btnCancelLoss_Click);
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(288, 108);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Properties.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(155, 20);
            this.txtTotalCost.StyleController = this.layoutControl1;
            this.txtTotalCost.TabIndex = 11;
            // 
            // txtPricePerPack
            // 
            this.txtPricePerPack.Location = new System.Drawing.Point(72, 108);
            this.txtPricePerPack.Name = "txtPricePerPack";
            this.txtPricePerPack.Size = new System.Drawing.Size(152, 20);
            this.txtPricePerPack.StyleController = this.layoutControl1;
            this.txtPricePerPack.TabIndex = 10;
            // 
            // expirydateEdit
            // 
            this.expirydateEdit.EditValue = null;
            this.expirydateEdit.Location = new System.Drawing.Point(288, 132);
            this.expirydateEdit.Name = "expirydateEdit";
            this.expirydateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.expirydateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.expirydateEdit.Size = new System.Drawing.Size(155, 20);
            this.expirydateEdit.StyleController = this.layoutControl1;
            this.expirydateEdit.TabIndex = 9;
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Location = new System.Drawing.Point(72, 132);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(152, 20);
            this.txtBatchNo.StyleController = this.layoutControl1;
            this.txtBatchNo.TabIndex = 8;
            // 
            // txtQtyPerPack
            // 
            this.txtQtyPerPack.Location = new System.Drawing.Point(288, 84);
            this.txtQtyPerPack.Name = "txtQtyPerPack";
            this.txtQtyPerPack.Size = new System.Drawing.Size(155, 20);
            this.txtQtyPerPack.StyleController = this.layoutControl1;
            this.txtQtyPerPack.TabIndex = 7;
            // 
            // txtPackQty
            // 
            this.txtPackQty.Location = new System.Drawing.Point(72, 84);
            this.txtPackQty.Name = "txtPackQty";
            this.txtPackQty.Size = new System.Drawing.Size(152, 20);
            this.txtPackQty.StyleController = this.layoutControl1;
            this.txtPackQty.TabIndex = 6;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(72, 36);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Properties.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(371, 20);
            this.txtItemName.StyleController = this.layoutControl1;
            this.txtItemName.TabIndex = 5;
            // 
            // btnUpdateLoss
            // 
            this.btnUpdateLoss.Location = new System.Drawing.Point(293, 156);
            this.btnUpdateLoss.Name = "btnUpdateLoss";
            this.btnUpdateLoss.Size = new System.Drawing.Size(68, 27);
            this.btnUpdateLoss.StyleController = this.layoutControl1;
            this.btnUpdateLoss.TabIndex = 13;
            this.btnUpdateLoss.Text = "Save";
            this.btnUpdateLoss.Click += new System.EventHandler(this.btnUpdateLoss_Click);
            // 
            // txtStockCode
            // 
            this.txtStockCode.Location = new System.Drawing.Point(72, 12);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Properties.ReadOnly = true;
            this.txtStockCode.Size = new System.Drawing.Size(371, 20);
            this.txtStockCode.StyleController = this.layoutControl1;
            this.txtStockCode.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.layoutControlItem4,
            this.layoutControlItem8,
            this.layoutControlItem6,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.emptySpaceItem1,
            this.layoutControlItem11});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(455, 195);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtStockCode;
            this.layoutControlItem1.CustomizationFormText = "Stock Code";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(435, 24);
            this.layoutControlItem1.Text = "Stock Code";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtItemName;
            this.layoutControlItem2.CustomizationFormText = "Item Name";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(435, 24);
            this.layoutControlItem2.Text = "Item Name";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtPackQty;
            this.layoutControlItem3.CustomizationFormText = "Pack Qty";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(216, 24);
            this.layoutControlItem3.Text = "Pack Qty";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtBatchNo;
            this.layoutControlItem5.CustomizationFormText = "Batch No";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(216, 24);
            this.layoutControlItem5.Text = "Batch No";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtPricePerPack;
            this.layoutControlItem7.CustomizationFormText = "Price/Pack";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(216, 24);
            this.layoutControlItem7.Text = "Price/Pack";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtQtyPerPack;
            this.layoutControlItem4.CustomizationFormText = "Qty/Pack";
            this.layoutControlItem4.Location = new System.Drawing.Point(216, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(219, 24);
            this.layoutControlItem4.Text = "Qty/Pack";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtTotalCost;
            this.layoutControlItem8.CustomizationFormText = "Total Cost";
            this.layoutControlItem8.Location = new System.Drawing.Point(216, 96);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(219, 24);
            this.layoutControlItem8.Text = "Total Cost";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.expirydateEdit;
            this.layoutControlItem6.CustomizationFormText = "Expiry Date";
            this.layoutControlItem6.Location = new System.Drawing.Point(216, 120);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(219, 24);
            this.layoutControlItem6.Text = "Expiry Date";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnCancelLoss;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(353, 144);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(82, 31);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(82, 31);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(82, 31);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnUpdateLoss;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new System.Drawing.Point(281, 144);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(72, 31);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(72, 31);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(72, 31);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.Text = "layoutControlItem10";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextToControlDistance = 0;
            this.layoutControlItem10.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 144);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(281, 31);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtUnit;
            this.layoutControlItem11.CustomizationFormText = "Unit";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(435, 24);
            this.layoutControlItem11.Text = "Unit";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(72, 60);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Properties.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(371, 20);
            this.txtUnit.StyleController = this.layoutControl1;
            this.txtUnit.TabIndex = 14;
            // 
            // EditLossForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 195);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditLossForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Loss and Adjustment";
            this.Load += new System.EventHandler(this.EditLossForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPricePerPack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expirydateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expirydateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBatchNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyPerPack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtQtyPerPack;
        private DevExpress.XtraEditors.TextEdit txtPackQty;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private DevExpress.XtraEditors.TextEdit txtStockCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.DateEdit expirydateEdit;
        private DevExpress.XtraEditors.TextEdit txtBatchNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.TextEdit txtTotalCost;
        private DevExpress.XtraEditors.TextEdit txtPricePerPack;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton btnCancelLoss;
        private DevExpress.XtraEditors.SimpleButton btnUpdateLoss;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtUnit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
    }
}