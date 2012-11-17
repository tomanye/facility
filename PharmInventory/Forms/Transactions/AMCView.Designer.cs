namespace PharmInventory.Forms.Transactions
{
    partial class AMCView
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnBuild = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.amcbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.storebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.colFullItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmcRange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIssueInAmcRange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysOutOfStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmcWithDOS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmcWithOutDOS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFullItemName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmcRange1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIssueInAmcRange1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysOutOfStock1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmcWithDOS1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmcWithOutDOS1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastIndexedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amcbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnBuild);
            this.layoutControl1.Controls.Add(this.progressBar1);
            this.layoutControl1.Controls.Add(this.lookUpEdit1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(456, 198, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(964, 419);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(847, 385);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(105, 22);
            this.btnBuild.TabIndex = 6;
            this.btnBuild.Text = "Build AMC";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 385);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(817, 22);
            this.progressBar1.TabIndex = 5;
            // 
            // amcbindingSource
            // 
            this.amcbindingSource.DataSource = typeof(StockoutIndexBuilder.Models.AmcReport);
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(42, 12);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreName", "Store Name", 66, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpEdit1.Properties.DataSource = this.storebindingSource;
            this.lookUpEdit1.Properties.DisplayMember = "StoreName";
            this.lookUpEdit1.Properties.NullText = "[Select Store]";
            this.lookUpEdit1.Properties.ValueMember = "ID";
            this.lookUpEdit1.Size = new System.Drawing.Size(167, 20);
            this.lookUpEdit1.StyleController = this.layoutControl1;
            this.lookUpEdit1.TabIndex = 4;
            this.lookUpEdit1.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // storebindingSource
            // 
            this.storebindingSource.DataSource = typeof(StockoutIndexBuilder.Models.Store);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(964, 419);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lookUpEdit1;
            this.layoutControlItem1.CustomizationFormText = "Store";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(201, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(201, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(201, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Store";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(26, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(201, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(743, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.progressBar1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 373);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(821, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnBuild;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(835, 373);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(109, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // colFullItemName
            // 
            this.colFullItemName.FieldName = "FullItemName";
            this.colFullItemName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colFullItemName.Name = "colFullItemName";
            this.colFullItemName.OptionsColumn.AllowEdit = false;
            this.colFullItemName.Visible = true;
            this.colFullItemName.VisibleIndex = 1;
            this.colFullItemName.Width = 304;
            // 
            // colAmcRange
            // 
            this.colAmcRange.Caption = "AMC Range";
            this.colAmcRange.FieldName = "AmcRange";
            this.colAmcRange.Name = "colAmcRange";
            this.colAmcRange.OptionsColumn.AllowEdit = false;
            this.colAmcRange.Visible = true;
            this.colAmcRange.VisibleIndex = 2;
            this.colAmcRange.Width = 20;
            // 
            // colIssueInAmcRange
            // 
            this.colIssueInAmcRange.Caption = "Issue In AMC Range";
            this.colIssueInAmcRange.FieldName = "IssueInAmcRange";
            this.colIssueInAmcRange.Name = "colIssueInAmcRange";
            this.colIssueInAmcRange.OptionsColumn.AllowEdit = false;
            this.colIssueInAmcRange.Visible = true;
            this.colIssueInAmcRange.VisibleIndex = 3;
            this.colIssueInAmcRange.Width = 20;
            // 
            // colDaysOutOfStock
            // 
            this.colDaysOutOfStock.FieldName = "DaysOutOfStock";
            this.colDaysOutOfStock.Name = "colDaysOutOfStock";
            this.colDaysOutOfStock.OptionsColumn.AllowEdit = false;
            this.colDaysOutOfStock.Visible = true;
            this.colDaysOutOfStock.VisibleIndex = 4;
            this.colDaysOutOfStock.Width = 20;
            // 
            // colAmcWithDOS
            // 
            this.colAmcWithDOS.Caption = "AMC With DOS";
            this.colAmcWithDOS.DisplayFormat.FormatString = "#,##0.#0";
            this.colAmcWithDOS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmcWithDOS.FieldName = "AmcWithDOS";
            this.colAmcWithDOS.Name = "colAmcWithDOS";
            this.colAmcWithDOS.OptionsColumn.AllowEdit = false;
            this.colAmcWithDOS.Visible = true;
            this.colAmcWithDOS.VisibleIndex = 5;
            this.colAmcWithDOS.Width = 37;
            // 
            // colAmcWithOutDOS
            // 
            this.colAmcWithOutDOS.Caption = "AMC Without DOS";
            this.colAmcWithOutDOS.DisplayFormat.FormatString = "#,##0.#0";
            this.colAmcWithOutDOS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmcWithOutDOS.FieldName = "AmcWithOutDOS";
            this.colAmcWithOutDOS.Name = "colAmcWithOutDOS";
            this.colAmcWithOutDOS.OptionsColumn.AllowEdit = false;
            this.colAmcWithOutDOS.Visible = true;
            this.colAmcWithOutDOS.VisibleIndex = 6;
            this.colAmcWithOutDOS.Width = 124;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 51;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Last Indexed Time";
            this.gridColumn2.FieldName = "LastIndexedTime";
            this.gridColumn2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 138;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(821, 373);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(14, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(944, 349);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullItemName1,
            this.colAmcRange1,
            this.colIssueInAmcRange1,
            this.colDaysOutOfStock1,
            this.colAmcWithDOS1,
            this.colAmcWithOutDOS1,
            this.colLastIndexedTime,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // colFullItemName1
            // 
            this.colFullItemName1.FieldName = "FullItemName";
            this.colFullItemName1.Name = "colFullItemName1";
            this.colFullItemName1.Visible = true;
            this.colFullItemName1.VisibleIndex = 1;
            this.colFullItemName1.Width = 241;
            // 
            // colAmcRange1
            // 
            this.colAmcRange1.Caption = "AMC Range";
            this.colAmcRange1.FieldName = "AmcRange";
            this.colAmcRange1.Name = "colAmcRange1";
            this.colAmcRange1.OptionsColumn.AllowEdit = false;
            this.colAmcRange1.Visible = true;
            this.colAmcRange1.VisibleIndex = 2;
            this.colAmcRange1.Width = 78;
            // 
            // colIssueInAmcRange1
            // 
            this.colIssueInAmcRange1.Caption = "Issue In AMC Range";
            this.colIssueInAmcRange1.FieldName = "IssueInAmcRange";
            this.colIssueInAmcRange1.Name = "colIssueInAmcRange1";
            this.colIssueInAmcRange1.OptionsColumn.AllowEdit = false;
            this.colIssueInAmcRange1.Visible = true;
            this.colIssueInAmcRange1.VisibleIndex = 3;
            this.colIssueInAmcRange1.Width = 126;
            // 
            // colDaysOutOfStock1
            // 
            this.colDaysOutOfStock1.FieldName = "DaysOutOfStock";
            this.colDaysOutOfStock1.Name = "colDaysOutOfStock1";
            this.colDaysOutOfStock1.OptionsColumn.AllowEdit = false;
            this.colDaysOutOfStock1.Visible = true;
            this.colDaysOutOfStock1.VisibleIndex = 4;
            this.colDaysOutOfStock1.Width = 106;
            // 
            // colAmcWithDOS1
            // 
            this.colAmcWithDOS1.Caption = "AMC With DOS";
            this.colAmcWithDOS1.FieldName = "AmcWithDOS";
            this.colAmcWithDOS1.Name = "colAmcWithDOS1";
            this.colAmcWithDOS1.OptionsColumn.AllowEdit = false;
            this.colAmcWithDOS1.Visible = true;
            this.colAmcWithDOS1.VisibleIndex = 5;
            this.colAmcWithDOS1.Width = 87;
            // 
            // colAmcWithOutDOS1
            // 
            this.colAmcWithOutDOS1.Caption = "AMC Without DOS";
            this.colAmcWithOutDOS1.FieldName = "AmcWithOutDOS";
            this.colAmcWithOutDOS1.Name = "colAmcWithOutDOS1";
            this.colAmcWithOutDOS1.OptionsColumn.AllowEdit = false;
            this.colAmcWithOutDOS1.Visible = true;
            this.colAmcWithOutDOS1.VisibleIndex = 6;
            this.colAmcWithOutDOS1.Width = 102;
            // 
            // colLastIndexedTime
            // 
            this.colLastIndexedTime.Caption = "Last Indexed Time";
            this.colLastIndexedTime.FieldName = "LastIndexedTime";
            this.colLastIndexedTime.Name = "colLastIndexedTime";
            this.colLastIndexedTime.OptionsColumn.AllowEdit = false;
            this.colLastIndexedTime.Visible = true;
            this.colLastIndexedTime.VisibleIndex = 7;
            this.colLastIndexedTime.Width = 142;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "No.";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 40;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.amcbindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 36);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(940, 345);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // AMCView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 419);
            this.Controls.Add(this.layoutControl1);
            this.Name = "AMCView";
            this.Text = "AMC Report";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.amcbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource amcbindingSource;
        private System.Windows.Forms.BindingSource storebindingSource;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.Button btnBuild;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colFullItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colAmcRange;
        private DevExpress.XtraGrid.Columns.GridColumn colIssueInAmcRange;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysOutOfStock;
        private DevExpress.XtraGrid.Columns.GridColumn colAmcWithDOS;
        private DevExpress.XtraGrid.Columns.GridColumn colAmcWithOutDOS;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFullItemName1;
        private DevExpress.XtraGrid.Columns.GridColumn colAmcRange1;
        private DevExpress.XtraGrid.Columns.GridColumn colIssueInAmcRange1;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysOutOfStock1;
        private DevExpress.XtraGrid.Columns.GridColumn colAmcWithDOS1;
        private DevExpress.XtraGrid.Columns.GridColumn colAmcWithOutDOS1;
        private DevExpress.XtraGrid.Columns.GridColumn colLastIndexedTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
      

    }
}