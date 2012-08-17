namespace PharmInventory.Forms.Reports
{
    partial class ExpiredProducts
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
            this.rdDrug = new DevExpress.XtraEditors.RadioGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.xpButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.xpButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.dtDate = new CalendarLib.DateTimePickerEx();
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.treeCategory = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gridItemsList = new DevExpress.XtraGrid.GridControl();
            this.gridItemListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn66 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn67 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.cboStores = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rdDrug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // rdDrug
            // 
            this.rdDrug.EditValue = "Drug";
            this.rdDrug.Location = new System.Drawing.Point(12, 12);
            this.rdDrug.Name = "rdDrug";
            this.rdDrug.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rdDrug.Properties.Appearance.Options.UseBackColor = true;
            this.rdDrug.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rdDrug.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Drug", "Drug"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Supplies", "Supplies")});
            this.rdDrug.Size = new System.Drawing.Size(301, 31);
            this.rdDrug.StyleController = this.layoutControl1;
            this.rdDrug.TabIndex = 48;
            this.rdDrug.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.xpButton1);
            this.layoutControl1.Controls.Add(this.xpButton2);
            this.layoutControl1.Controls.Add(this.dtDate);
            this.layoutControl1.Controls.Add(this.txtItemName);
            this.layoutControl1.Controls.Add(this.rdDrug);
            this.layoutControl1.Controls.Add(this.treeCategory);
            this.layoutControl1.Controls.Add(this.gridItemsList);
            this.layoutControl1.Controls.Add(this.cboStores);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(179, 176, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1061, 580);
            this.layoutControl1.TabIndex = 32;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // xpButton1
            // 
            this.xpButton1.Location = new System.Drawing.Point(857, 534);
            this.xpButton1.Name = "xpButton1";
            this.xpButton1.Size = new System.Drawing.Size(88, 22);
            this.xpButton1.StyleController = this.layoutControl1;
            this.xpButton1.TabIndex = 50;
            this.xpButton1.Text = "&Print";
            this.xpButton1.Click += new System.EventHandler(this.xpButton1_Click);
            // 
            // xpButton2
            // 
            this.xpButton2.Location = new System.Drawing.Point(949, 534);
            this.xpButton2.Name = "xpButton2";
            this.xpButton2.Size = new System.Drawing.Size(88, 22);
            this.xpButton2.StyleController = this.layoutControl1;
            this.xpButton2.TabIndex = 49;
            this.xpButton2.Text = "E&xport";
            this.xpButton2.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // dtDate
            // 
            this.dtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDate.CalendarFont = new System.Drawing.Font("Nyala", 10.75F);
            this.dtDate.CalendarForeColor = System.Drawing.Color.Black;
            this.dtDate.CustomFormat = "MM/dd/yyyy";
            this.dtDate.DayOfWeekCharacters = 2;
            this.dtDate.ForeColor = System.Drawing.Color.Black;
            this.dtDate.Location = new System.Drawing.Point(431, 44);
            this.dtDate.Name = "dtDate";
            this.dtDate.PopUpFontSize = 9.75F;
            this.dtDate.Size = new System.Drawing.Size(292, 20);
            this.dtDate.TabIndex = 16;
            this.dtDate.Value = new System.DateTime(2008, 10, 3, 0, 0, 0, 0);
            this.dtDate.Visible = false;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(151, 68);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(337, 20);
            this.txtItemName.StyleController = this.layoutControl1;
            this.txtItemName.TabIndex = 45;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // treeCategory
            // 
            this.treeCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeCategory.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeCategory.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.treeCategory.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeCategory.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeCategory.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeCategory.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeCategory.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeCategory.Location = new System.Drawing.Point(12, 47);
            this.treeCategory.Name = "treeCategory";
            this.treeCategory.BeginUnboundLoad();
            this.treeCategory.AppendNode(new object[] {
            null}, -1);
            this.treeCategory.EndUnboundLoad();
            this.treeCategory.OptionsView.ShowIndicator = false;
            this.treeCategory.ParentFieldName = "Parent";
            this.treeCategory.Size = new System.Drawing.Size(301, 458);
            this.treeCategory.TabIndex = 17;
            this.treeCategory.Click += new System.EventHandler(this.treeCategory_Click);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AllNodesSummary = true;
            this.treeListColumn1.Caption = "Category";
            this.treeListColumn1.FieldName = "Name";
            this.treeListColumn1.MinWidth = 34;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // gridItemsList
            // 
            this.gridItemsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItemsList.Location = new System.Drawing.Point(53, 92);
            this.gridItemsList.MainView = this.gridItemListView;
            this.gridItemsList.Name = "gridItemsList";
            this.gridItemsList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridItemsList.Size = new System.Drawing.Size(984, 438);
            this.gridItemsList.TabIndex = 31;
            this.gridItemsList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemListView});
            // 
            // gridItemListView
            // 
            this.gridItemListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn28,
            this.colItemName,
            this.gridColumn66,
            this.gridColumn67,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridItemListView.GridControl = this.gridItemsList;
            this.gridItemListView.IndicatorWidth = 40;
            this.gridItemListView.Name = "gridItemListView";
            this.gridItemListView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridItemListView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridItemListView.OptionsDetail.EnableDetailToolTip = true;
            this.gridItemListView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled;
            this.gridItemListView.OptionsDetail.SmartDetailHeight = true;
            this.gridItemListView.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridItemListView.OptionsPrint.EnableAppearanceOddRow = true;
            this.gridItemListView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridItemListView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridItemListView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridItemListView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridItemListView.OptionsView.EnableAppearanceOddRow = true;
            this.gridItemListView.OptionsView.ShowFooter = true;
            this.gridItemListView.OptionsView.ShowGroupPanel = false;
            this.gridItemListView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridItemListView.DoubleClick += new System.EventHandler(this.gridItemListView_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.FieldName = "No";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn1.Width = 52;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Stock Code";
            this.gridColumn28.FieldName = "StockCode";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn28.OptionsFilter.AllowFilter = false;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 0;
            this.gridColumn28.Width = 90;
            // 
            // colItemName
            // 
            this.colItemName.Caption = "Item Name";
            this.colItemName.FieldName = "FullItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowEdit = false;
            this.colItemName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colItemName.OptionsFilter.AllowFilter = false;
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 1;
            this.colItemName.Width = 253;
            // 
            // gridColumn66
            // 
            this.gridColumn66.Caption = "gridColumn66";
            this.gridColumn66.FieldName = "SubCategoryID";
            this.gridColumn66.Name = "gridColumn66";
            this.gridColumn66.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn66.OptionsFilter.AllowFilter = false;
            // 
            // gridColumn67
            // 
            this.gridColumn67.Caption = "gridColumn67";
            this.gridColumn67.FieldName = "CategoryId";
            this.gridColumn67.Name = "gridColumn67";
            this.gridColumn67.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn67.OptionsFilter.AllowFilter = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Batch No";
            this.gridColumn2.FieldName = "BatchNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 113;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Expiry Date";
            this.gridColumn3.DisplayFormat.FormatString = "MMM dd,yyyy";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "ExpDate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 113;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Quantity";
            this.gridColumn4.DisplayFormat.FormatString = "#,###";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "QuantityLeft";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsFilter.AllowFilter = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 86;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ID";
            this.gridColumn5.FieldName = "ID";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Expired Amount in Birr";
            this.gridColumn6.DisplayFormat.FormatString = "##,###.##";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "Price";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsColumn.AllowMove = false;
            this.gridColumn6.OptionsFilter.AllowFilter = false;
            this.gridColumn6.SummaryItem.DisplayFormat = "{0:#,##0.#0}";
            this.gridColumn6.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 153;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repositoryItemCheckEdit1.ValueGrayed = false;
            // 
            // cboStores
            // 
            this.cboStores.Location = new System.Drawing.Point(151, 44);
            this.cboStores.Name = "cboStores";
            this.cboStores.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStores.Properties.Appearance.Options.UseFont = true;
            this.cboStores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboStores.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreName", "Name")});
            this.cboStores.Properties.DisplayMember = "StoreName";
            this.cboStores.Properties.NullText = "";
            this.cboStores.Properties.ValueMember = "ID";
            this.cboStores.Size = new System.Drawing.Size(337, 20);
            this.cboStores.StyleController = this.layoutControl1;
            this.cboStores.TabIndex = 0;
            this.cboStores.EditValueChanged += new System.EventHandler(this.cboStores_SelectedValueChanged);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.dtDate;
            this.layoutControlItem7.CustomizationFormText = "To Date:";
            this.layoutControlItem7.Location = new System.Drawing.Point(378, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(296, 24);
            this.layoutControlItem7.Text = "To Date:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1061, 580);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Categories";
            this.layoutControlGroup2.ExpandButtonVisible = true;
            this.layoutControlGroup2.Expanded = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(29, 560);
            this.layoutControlGroup2.Text = "Categories";
            this.layoutControlGroup2.TextLocation = DevExpress.Utils.Locations.Left;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.treeCategory;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 35);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(305, 462);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.rdDrug;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(305, 0);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(305, 27);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(305, 35);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "Items";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.emptySpaceItem3,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.layoutControlItem8});
            this.layoutControlGroup3.Location = new System.Drawing.Point(29, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1012, 560);
            this.layoutControlGroup3.Text = "Items";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cboStores;
            this.layoutControlItem4.CustomizationFormText = "Store";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(439, 24);
            this.layoutControlItem4.Text = "Store";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtItemName;
            this.layoutControlItem6.CustomizationFormText = "Filter By Item Name";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(439, 24);
            this.layoutControlItem6.Text = "Filter By Item Name";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(94, 13);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(782, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(206, 48);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridItemsList;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(988, 442);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 490);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(804, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(439, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(343, 48);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.xpButton2;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(896, 490);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(92, 26);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.xpButton1;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(804, 490);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(92, 26);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // ExpiredProducts
            // 
            this.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 580);
            this.Controls.Add(this.layoutControl1);
            this.Name = "ExpiredProducts";
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.ManageItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rdDrug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cboStores;
        private CalendarLib.DateTimePickerEx dtDate;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private DevExpress.XtraTreeList.TreeList treeCategory;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraGrid.GridControl gridItemsList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemListView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn66;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn67;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.RadioGroup rdDrug;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton xpButton1;
        private DevExpress.XtraEditors.SimpleButton xpButton2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}