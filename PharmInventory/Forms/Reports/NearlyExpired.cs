using System;
using System.Data;
using System.Drawing;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraEditors;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.Reports
{
    /// <summary>
    /// Interaction Logic for NearlyExpired Form
    /// </summary>
    public partial class NearlyExpired : XtraForm
    {
        public NearlyExpired()
        {
            InitializeComponent();
        }
        string _selectedType = "Drug";
        DateTime _dtCurrent = new DateTime();

        /// <summary>
        /// Loads the lookups
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageItems_Load(object sender, EventArgs e)
        {
            PopulateCatTree(_selectedType);
            lkCommodityTypes.Properties.DataSource = BLL.Type.GetAllTypes();
            // Select the very first commodity type.
            lkCommodityTypes.ItemIndex = 0;
            //DateTime xx = dtDate.Value;
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            _dtCurrent = ConvertDate.DateConverter(dtDate.Text);
           // dtDate.Value = xx;
            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStores.Properties.DataSource = stor.DefaultView;
            cboStores.ItemIndex = 0;
        }

        private void PopulateCatTree(String type)
        {
            if (type == "Drug")
            {
                Category cat = new Category();
                treeCategory.DataSource = cat.GetCategoryTree();
            }
            else
            {
                SupplyCategory subCat = new SupplyCategory();
                treeCategory.DataSource = subCat.GetAllSupplyCategories();
            }
        }

        private void PopulateItemList(DataTable dtItem)
        {
            gridItemsList.DataSource = dtItem;
        }

        private void xpButton1_Click(object sender, EventArgs e)
        {
            printableComponentLink1.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowPreview();
        }

        private void xpButton2_Click(object sender, EventArgs e)
        {
            string fileName = MainWindow.GetNewFileName("xls");
            gridItemsList.ExportToXls(fileName);
            MainWindow.OpenInExcel(fileName);
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            gridItemListView.ActiveFilterString = "[FullItemName] like '" + txtItemName.Text + "%'";
        }

        private void gridItemListView_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) 
                return;

            DataRow dr = view.GetFocusedDataRow();
            
            if (dr == null) 
                return;

            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCur = ConvertDate.DateConverter(dtDate.Text);
            int month = dtCur.Month;
            int year = (month < 11) ? dtCur.Year : dtCur.Year + 1;
            int itemId = Convert.ToInt32(dr["ID"]);
            //ItemDetailReport con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0);
            //con.ShowDialog();
        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue == null) 
                return;

            Items itm = new Items();
            _selectedType = radioGroup1.EditValue.ToString();
            int storeId = (cboStores.EditValue != null) ? Convert.ToInt32(cboStores.EditValue) : 1;
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            int yr = (dtCurrent.Month < 11) ? dtCurrent.Year - 1 : dtCurrent.Year;
            DateTime dt1 = new DateTime(yr, 11, 1);
            int commodityType = Convert.ToInt32(lkCommodityTypes.EditValue);
            DataTable dtItem = itm.GetNearlyExpiredItemsByBatch(storeId,commodityType,dtCurrent) ;
           
            PopulateItemList(dtItem);
            PopulateCatTree(_selectedType);
        }

        private void hideContainerLeft_DockChanged(object sender, EventArgs e)
        {
            //PopulateCatTree(selectedType);
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText =  (e.RowHandle + 1).ToString();
            }
        }

        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            string[] header = { info.HospitalName, "Date: " + dtDate.Text, "Store: " + cboStores.Text };
            printableComponentLink1.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 200, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(0, 20, 200, 100), BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(0, 40, 200, 100), BorderSide.None);
        }

        private void treeCategory_Click(object sender, EventArgs e)
        {
            string value = treeCategory.Selection[0].GetValue("ID").ToString();
            int categoryId = Convert.ToInt32(value.Substring(1));

            Items itm = new Items();
            string filterString = "";
            switch (value.Substring(0, 1))
            {

                case "S":
                    filterString = "[SubCategoryID] = " + categoryId.ToString();
                    gridItemListView.ActiveFilterString = filterString;

                    break;
                case "C":
                case "U":
                    filterString = "[CategoryId] = " + categoryId.ToString();
                    gridItemListView.ActiveFilterString = filterString;

                    break;
                case "P":
                    // dtItem = itm.GetAllItem();
                    gridItemListView.ActiveFilterString = "";
                    break;


            }

            gridItemListView.ClearSelection();
        }

        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue == null || lkCommodityTypes.EditValue == null) return;
            var itm = new Items();
            var dtItem = itm.GetNearlyExpiredItemsByBatch((int)cboStores.EditValue, (int)lkCommodityTypes.EditValue, _dtCurrent);
            PopulateItemList(dtItem);
        }

        private void lkCommodityTypes_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null && lkCommodityTypes.EditValue != null)
            {
                Items itm = new Items();
                DataTable dtItem = itm.GetNearlyExpiredItemsByBatch((int)cboStores.EditValue, (int)lkCommodityTypes.EditValue, _dtCurrent);
                PopulateItemList(dtItem);
            }
        }
    }
}