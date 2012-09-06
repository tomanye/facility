namespace PharmInventory.Forms.Profiles
{
    partial class ManageSupply
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageSupply));
            this.ProductTree = new System.Windows.Forms.TreeView();
            this.PackSize = new System.Windows.Forms.ColumnHeader();
            this.Item = new System.Windows.Forms.ColumnHeader();
            this.lstItem = new PrintableListView.PrintableListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddItems = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEditItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblState = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.button1 = new DevExpress.XtraEditors.SimpleButton();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductTree
            // 
            this.ProductTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ProductTree.BackColor = System.Drawing.Color.PowderBlue;
            this.ProductTree.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductTree.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ProductTree.Location = new System.Drawing.Point(2, 1);
            this.ProductTree.Name = "ProductTree";
            this.ProductTree.ShowNodeToolTips = true;
            this.ProductTree.Size = new System.Drawing.Size(269, 421);
            this.ProductTree.TabIndex = 7;
            this.ProductTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ProductTree_NodeMouseDoubleClick);
            // 
            // PackSize
            // 
            this.PackSize.Text = "Stock Code";
            this.PackSize.Width = 94;
            // 
            // Item
            // 
            this.Item.Text = "Item";
            this.Item.Width = 351;
            // 
            // lstItem
            // 
            this.lstItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItem.BackColor = System.Drawing.Color.White;
            this.lstItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.PackSize,
            this.Item,
            this.columnHeader2,
            this.columnHeader3});
            this.lstItem.FitToPage = false;
            this.lstItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstItem.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lstItem.FullRowSelect = true;
            this.lstItem.GridLines = true;
            this.lstItem.Location = new System.Drawing.Point(279, 55);
            this.lstItem.Name = "lstItem";
            this.lstItem.ShowItemToolTips = true;
            this.lstItem.Size = new System.Drawing.Size(845, 348);
            this.lstItem.TabIndex = 9;
            this.lstItem.Title = "";
            this.lstItem.UseCompatibleStateImageBehavior = false;
            this.lstItem.View = System.Windows.Forms.View.Details;
            this.lstItem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstItem_MouseDoubleClick);
            this.lstItem.SelectedIndexChanged += new System.EventHandler(this.lstItem_SelectedIndexChanged);
            this.lstItem.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstItem_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.";
            this.columnHeader1.Width = 37;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Unit";
            this.columnHeader2.Width = 98;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Dosage Form";
            this.columnHeader3.Width = 137;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddItems,
            this.toolStripSeparator2,
            this.toolStripButtonEditItem,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(279, 10);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(138, 39);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAddItems
            // 
            this.toolStripButtonAddItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddItems.Enabled = false;
            this.toolStripButtonAddItems.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddItems.Image")));
            this.toolStripButtonAddItems.Name = "toolStripButtonAddItems";
            this.toolStripButtonAddItems.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonAddItems.Text = "Add New";
            this.toolStripButtonAddItems.Click += new System.EventHandler(this.toolBtnAddNew_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonEditItem
            // 
            this.toolStripButtonEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEditItem.Enabled = false;
            this.toolStripButtonEditItem.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditItem.Image")));
            this.toolStripButtonEditItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditItem.Name = "toolStripButtonEditItem";
            this.toolStripButtonEditItem.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonEditItem.Text = "Edit ";
            this.toolStripButtonEditItem.Click += new System.EventHandler(this.toolBtnEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton3.Text = "Refresh";
            this.toolStripButton3.Click += new System.EventHandler(this.toolBtnRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(430, 28);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(58, 13);
            this.lblState.TabIndex = 11;
            this.lblState.Text = "All Items";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(791, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 51);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtering";
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.Location = new System.Drawing.Point(6, 20);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(156, 21);
            this.txtItemName.TabIndex = 3;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(400, 200);
            this.progressBar1.Minimum = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(300, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 19;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Value = 1;
            this.progressBar1.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::PharmInventory.Properties.Resources.printer1;
            
            this.btnPrint.Location = new System.Drawing.Point(1055, 21);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(61, 25);
            this.btnPrint.TabIndex = 25;
            this.btnPrint.Text = "Print";
                        
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::PharmInventory.Properties.Resources.MS_Excel;
            
            this.button1.Location = new System.Drawing.Point(969, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Export";
            
            
            this.button1.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // ManageSupply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1139, 432);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.ProductTree);
            this.Controls.Add(this.lstItem);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ManageSupply";
            this.Text = "ManageItems";
            this.Load += new System.EventHandler(this.ManageItems_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView ProductTree;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddItems;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditItem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ColumnHeader PackSize;
        private System.Windows.Forms.ColumnHeader Item;
        private PrintableListView.PrintableListView lstItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private System.Windows.Forms.ProgressBar progressBar1;
        private DevExpress.XtraEditors.SimpleButton button1;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
    }
}