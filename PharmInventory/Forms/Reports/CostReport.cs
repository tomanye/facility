using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;
using System.ComponentModel;
using DevExpress.XtraEditors;

namespace PharmInventory.Forms.Reports
{
    /// <summary>
    /// Interaction logic for BalanceReport Form
    /// </summary>
    public partial class CostReport : Form
    {
        public CostReport()
        {
            InitializeComponent();
        }

        String _selectedType = "Drug";
        bool _isReady = false;
        DateTime _dtCur;

        /// <summary>
        /// Load the dropdowns and the category tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageItems_Load(object sender, EventArgs e)
        {
            PopulateCatTree(_selectedType);

            //Programs prog = new Programs();
            //DataTable dtProg = prog.GetSubPrograms();
            //object[] objProg = { 0, "All Programs", "", 0, "" };
            //dtProg.Rows.Add(objProg);
            //cboSubProgram.DataSource = dtProg;
            //cboSubProgram.SelectedIndex = -1;
            //cboSubProgram.Text = "Select Program";

            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStores.DataSource = stor.DefaultView;
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            _dtCur = ConvertDate.DateConverter(dtDate.Text);
            dtTo.Value = DateTime.Now;
           // int yearFrom = ((_dtCur.Month == 11 && _dtCur.Month == 12) ? _dtCur.Year : _dtCur.Year - 1 );
            dtFrom.Value = DateTime.Now;
            //int year = _dtCur.Year;
            //DataTable dtyears = Items.AllYears();
            //cboYear.DataSource = dtyears;
            //cboYear.SelectedValue = year;
            //cboQuarter.DataSource = getQuarter();

            this._isReady = true;
            PopulateItemList();
        }

        //private DataTable getQuarter()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Quarter");
        //    dt.Columns.Add("Quarterv");
        //    dt.Rows.Add("");
        //    object[] q1 = { "Hamle - Meskerem", 1 };
        //    dt.Rows.Add(q1);
        //    object[] q2 = { "Tikmet - Tahsas", 2 };
        //    dt.Rows.Add(q2);
        //    object[] q3 = { "Tir - Megabit", 3 };
        //    dt.Rows.Add(q3);
        //    object[] q4 = { "Miyzia - Sene", 4 };
        //    dt.Rows.Add(q4);
        //    //for(int i = 1; i <= 4; i++)
        //    //{
        //    //    object[] obj = {"Q" + i, i};
        //    //    dt.Rows.Add(obj);
        //    //}
        //    return dt;
        //}

        /// <summary>
        /// Populates the category tree with drugs or supply categories based on the supplied parameter
        /// </summary>
        /// <param name="type">"Drug" - To get drugs, Otherwise, Supply Categories are filled out</param>
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

        /// <summary>
        /// Populates the list of items in the gridItemsList
        /// </summary>
        private void PopulateItemList()
        {
            //Balance bal = new Balance();
            //int storeId = (cboStores.SelectedValue != null) ? Convert.ToInt32(cboStores.SelectedValue) : 1;
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            //gridItemsList.DataSource = bal.CostBalanceByYear(storeId, dtCurrent.Year, dtCurrent.Month,);
            //if (ckExclude.Checked)
            //    gridItemListView.ActiveFilterString = "[Received] != '0'";          
            if (!_isReady)
                return;

            //if ((cboYear.EditValue == null) || (cboMonth.EditValue == null) || (cboStores.EditValue == null))
            //    return;

            int storeId = (cboStores.SelectedValue != null) ? Convert.ToInt32(cboStores.SelectedValue) : 1;
            int month = dtCurrent.Month;
            //int year = ((cboYear.SelectedValue != "" )?Convert.ToInt32(cboYear.SelectedValue) : dtCurrent.Year);
            //int quarter = ((cboQuarter.SelectedValue != DBNull.Value )? Convert.ToInt32(cboQuarter.SelectedValue) : 0);

            //translate the month selection to the appropriate month values
            //CALENDAR:
            //if (month > 2)
            //{
            //    month -= 2;
            //}
            //else
            //{
            //    month += 10;
            //}

            // different criteria for different options like suply and drug
            //int programID = ((cboSubProgram.EditValue != null) ? Convert.ToInt32(cboSubProgram.EditValue) : 0);
            dtFrom.CustomFormat = "MM/dd/yyyy";
            DateTime dt1 = ConvertDate.DateConverter(dtFrom.Text);
            dtTo.CustomFormat = "MM/dd/yyyy";
            DateTime dt2 = ConvertDate.DateConverter(dtTo.Text);
            string dRange = "From " + dtFrom.Text + " to " + dtTo.Text;
            if (dt1 == dt2)
            {
                dRange = "For Year " + dt1.Year.ToString();
            }
            layoutControlGroup3.Text = "Cost Report " + dRange;
            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync(new int[] { storeId, month });
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridItemsList.DataSource = (DataTable)e.Result;
            //cboStatus.EditValue = _filter;
            if (ckExclude.Checked)
                gridItemListView.ActiveFilterString = "[Received] != '0'";
        }

        /// <summary>
        /// Gets the balance of all items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Balance bal = new Balance();

            int[] arr = (int[])e.Argument;

            int storeId = arr[0], month = arr[1]; // year = arr[2], quarter = arr[3];
            
            dtFrom.CustomFormat = "MM/dd/yyyy";
            DateTime dt1 = ConvertDate.DateConverter(dtFrom.Text);
            dtTo.CustomFormat = "MM/dd/yyyy";
            DateTime dt2 = ConvertDate.DateConverter(dtTo.Text);
            //string dRange = "From " + dtFrom.Text + " to " + dtTo.Text;
            //layoutControlGroup3.Text = "Cost Report " + dRange;
            if (dt1 == dt2)
            { 
                dt1 = ((dt1.Month == 11 || dt1.Month == 12)? new DateTime(dt1.Year, 11,1) : new DateTime(dt1.Year -1,11,1));
                //dRange = "For Year " + dt1.Year.ToString();
            }
            
            DataTable dtBal = bal.TransactionReport(storeId, dt1,dt2, _selectedType, bw);
            e.Result = dtBal;
        }


        /// <summary>
        /// Updates the form based on the selection on the treeCategory (Does filtering)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    gridItemListView.ActiveFilterString = "";
                    break;
            }

            gridItemListView.ClearSelection();
        }
        
        /// <summary>
        /// Handles the selected value changed event of the cboStores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null)
            {
               PopulateItemList();
            }
        }
        
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        /// <summary>
        /// Opens the detailed item report for the chosen item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridItemListView_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                DataRow dr = view.GetFocusedDataRow();
                if (dr != null)
                {
                    dtDate.Value = DateTime.Now;
                    dtDate.CustomFormat = "MM/dd/yyyy";
                    DateTime dtCur = ConvertDate.DateConverter(dtDate.Text);
                    int month = dtCur.Month;
                    int year = (month < 11) ? dtCur.Year : dtCur.Year + 1;
                    int itemId = Convert.ToInt32(dr["ID"]);
                    ItemDetailReport con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.SelectedValue), year, 0);
                    con.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Shows print preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            printableComponentLink1.ShowPreviewDialog();
        }

        /// <summary>
        /// Exports to XLS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            //string fileName = MainWindow.GetNewFileName("xls");
            //gridItemsList.ExportToXls(fileName);
            //MainWindow.OpenInExcel(fileName);
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Microsoft Excel | *.xls";

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                gridItemsList.MainView.ExportToXls(saveDlg.FileName);
                XtraMessageBox.Show("The cost report has been exported", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Excludes never received items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckExclude_CheckedChanged(object sender, EventArgs e)
        {
            string fil = ((ckExclude.Checked) ? "[Received] != '0'" : "");
            gridItemListView.ActiveFilterString = fil;
        }

        /// <summary>
        /// Populate the items based on the choice of the radio buttons (Drugs or Supplies)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdDrug_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null)
            {
                _selectedType = rdDrug.EditValue.ToString();
                
                PopulateItemList();
                PopulateCatTree(_selectedType);
            }
        }

        /// <summary>
        /// Filters the grid based on the text in the txtItemName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            gridItemListView.ActiveFilterString = "[FullItemName] like '" + txtItemName.Text + "%'";
        }

       

        /// <summary>
        /// Populates the items based on the chosen program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSubProgram_SelectedValueChanged(object sender, EventArgs e)
        {
           // PopulateByProgram();
        }

        private void gridItemsList_Click(object sender, EventArgs e)
        {

        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null)//&& cboYear.SelectedValue != null)
            {
                PopulateItemList();
            }
        }
    }
}