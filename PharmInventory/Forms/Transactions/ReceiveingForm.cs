using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;


namespace PharmInventory.Forms.Transactions
{
    /// <summary>
    /// This form is used to register received items.
    /// Input:Pack Qty, Qty/Pack, Price, Batch No, Expiry Date, Store, Supplier, RefNo
    /// </summary>
    public partial class ReceivingForm : XtraForm
    {
        public ReceivingForm()
        {
            InitializeComponent();
        }

        #region Members

        private int tabPage;
        private string selectedType = "Drug";
        private DataTable dtSelectedTable = null;
        private DataTable dtRecGrid = new DataTable();

        #endregion

        /// <summary>
        /// Populate the lookups and item lists.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReceiveingForm_Load(object sender, EventArgs e)
        {
            
                //gridRecieveView.Columns[4].Visible = VisibilitySetting.HandleUnits;
            var UnitColumn = ((GridView) receivingGrid.MainView).Columns[12];
            var UnitColumn1 = ((GridView) receivingGrid.MainView).Columns[5];
            var UnitColumn2 = ((GridView)gridItemsChoice.MainView).Columns[4];
            var qtyperpack = ((GridView)receivingGrid.MainView).Columns[3];
            var buqty = ((GridView)receivingGrid.MainView).Columns[4];
            if(VisibilitySetting.HandleUnits ==3)
            {
                UnitColumn.Visible = true;
                UnitColumn1.Visible = false;
                UnitColumn2.Visible = false;
                qtyperpack.Visible = false;
                buqty.Visible = false;

            }
            else if (VisibilitySetting.HandleUnits == 2)
            {
                UnitColumn.Visible = true;
                UnitColumn1.Visible = false;
                UnitColumn2.Visible = false;
                qtyperpack.Visible = false;
                buqty.Visible = false;

            }
            else if(VisibilitySetting.HandleUnits==1)
            {
                UnitColumn.Visible = false;
                UnitColumn1.Visible = true;
                qtyperpack.Visible = true;
                UnitColumn2.Visible = true;
                buqty.Visible = true;
            }
            
            Stores stor = new Stores();
            stor.GetActiveStores();

            cboStores.Properties.DataSource = stor.DefaultView;
            cboStores.ItemIndex = 0;
         
            Programs prog = new Programs();
            DataTable dtProg = prog.GetSubPrograms();
            object[] objProg = {0, "All Programs", "", 0, ""};
            dtProg.Rows.Add(objProg);
            cboProgram.Properties.DataSource = dtProg;
            cboProgram.ItemIndex = -1;
            cboProgram.Text = "Select Program";
            cboProgram.Properties.DisplayMember = "Name";
            cboProgram.Properties.ValueMember = "ID";

            var unit = new ItemUnit();
            var units = unit.GetAllUnits();
            UnitsbindingSource.DataSource = units.DefaultView;




            Supplier sup = new Supplier();
            DataTable dtSup = new DataTable();
            sup.GetActiveSuppliers();
            dtSup = sup.DefaultView.ToTable();
            cboSuppliers.DataSource = dtSup;
            cboSupplier.Properties.DataSource = sup.DefaultView;
            cboSuppliers.Text = "Select Supplier";
            cboSuppliers.ValueMember = "ID";
            cboSuppliers.DisplayMember = "CompanyName";

            // Bind the grid with only active items
            Items itm = new Items();
            //DataTable dtItem = itm.GetAllItems(1);
            DataTable dtItem = BLL.Items.GetActiveItemsByCommodityType(0);
            lkCategories.Properties.DataSource = BLL.Type.GetAllTypes();
            lkCategories.ItemIndex = 0;

            PopulateItemList(dtItem);
            selectedType = radioGroup1.EditValue.ToString();
            PopulateCatTree(selectedType);

            int userID = MainWindow.LoggedinId;
            User us = new User();
            us.LoadByPrimaryKey(userID);
            txtReceivedBy.Text = us.FullName;

            // bind the current date as the datetime field
            dtRecDate.Value = DateTime.Now;
        }

        private void PopulateCatTree(String Type)
        {
            if (Type == "Drug")
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

        private void OnItemCheckedChanged(object sender, EventArgs e)
        {
           
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();

            bool b = (dr["IsSelected"] != DBNull.Value) && Convert.ToBoolean(dr["IsSelected"]);

            if (b)
            {
                try
                {
                    dtSelectedTable.ImportRow(dr);
                }
                catch
                {
                }
            }
            else
            {
                int id = Convert.ToInt32(dr["ID"]);
                DataRow rw = dtSelectedTable.Rows.Find(id);
                if (rw != null)
                {
                    dtSelectedTable.Rows.Remove(rw);
                    try
                    {
                        DataRow[] dataRows = dtRecGrid.Select(String.Format("ID = {0}", dr["ID"]));
                            // dtRecGrid.Rows.Remove(dtRecGrid.Rows.Find(dr["ID"]));
                        foreach (DataRow r in dataRows)
                        {
                            r.Delete();
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        public void PopulateItemList(DataTable dtItem)
        {
            if (dtSelectedTable == null)
            {
                dtSelectedTable = dtItem.Clone();
                dtSelectedTable.PrimaryKey = new DataColumn[] {dtSelectedTable.Columns["ID"]};
            }
            gridItemsChoice.DataSource = dtItem;
            try
            {
                dtItem.Columns.Add("IsSelected", typeof (bool));
            }
            catch
            {
            }
        }

        private void xpButton1_Click(object sender, EventArgs e)
        {
            PopulateListToGrid();
        }

        private void PopulateListToGrid()
        {
          
            if (receivingGrid.DataSource != null)
            {
                DataTable dt = new DataTable();
                receivingGrid.DataSource = dt;
                dtRecGrid = new DataTable();
            }
            Items itm = new Items();
            tabPage = 1;
            tabControl1.SelectedTabPageIndex = 1;


            receivingGrid.DataSource = new DataTable();

            // No reason really to populate the grid columns like this.
            if (dtRecGrid.Columns.Count == 0)
            {
                string[] str =
                    {
                        "ID", "Stock Code", "Item Name", "Pack Qty", "Qty/pack", "BU Qty", "Unit", "Price/Pack",
                        "Batch No", "Expiry Date", "Total Price","UnitID"
                    };
                foreach (string col in str)
                {
                    if (col == "Expiry Date")
                    {
                        dtRecGrid.Columns.Add(col, typeof (DateTime));
                    }
                    else
                    {
                        dtRecGrid.Columns.Add(col);
                    }
                }
            }
            int count = 1;

            // this could get better
            foreach (DataRow lst in dtSelectedTable.Rows)
            {
                string itemName = lst["FullItemName"].ToString();
                object[] obj =
                    {
                        lst["ID"].ToString(), lst["StockCode"].ToString(), itemName, 1, 1, 1,
                        lst["Unit"].ToString(), "", ""
                    };
                dtRecGrid.Rows.Add(obj);
                count++;
            }
            receivingGrid.DataSource = dtRecGrid;
            //dtRecGrid.DefaultView.Sort = dtSelectedTable.DefaultView;
            dtRecDate.CustomFormat = "MMM dd,yyyy";
        }

        private void OnEditBatchNumbers(object sender, EventArgs e)
        {
            DataRow dr = gridRecieveView.GetDataRow(gridRecieveView.GetSelectedRows()[0]);

            dtRecGrid.ImportRow(dr);
            dtRecGrid.DefaultView.Sort = "Stock Code";
        }

        /// <summary>
        /// Validates user input and returns "true" when valid and the error message when invalid.
        /// </summary>
        /// <returns></returns>
        private string ValidateFields()
        {
            string valid = "true";

            if (Convert.ToDateTime(dtRecDate.Value) > DateTime.Now)
            {
                valid = "You cannot pick a Date in a future!";
                return valid;
            }

            if (!dxValidationProvider1.Validate())
            {
                valid = "Please correct the highlighted filed!";
            }

            Items itm = new Items();
            for (int i = 0; i < gridRecieveView.DataRowCount; i++)
            {
                DataRow dr = gridRecieveView.GetDataRow(i);
                dr.ClearErrors();
              

                //if (dr["Qty/Pack"] == null || dr["Qty/Pack"].ToString() == "" || Convert.ToInt64(dr["Qty/Pack"]) == 0)
                //{
                //    dr.SetColumnError("Qty/Pack", "This field cannot be left blank.");
                //    valid = "Please fill the requested feild!";
                //}

                if (dr["Pack Qty"] == null || dr["Pack Qty"].ToString() == "" || Convert.ToInt64(dr["Pack Qty"]) == 0)
                {
                    dr.SetColumnError("Pack Qty", "This field cannot be left blank.");
                    valid = "Please fill the requested feild!";
                }

                itm.LoadByPrimaryKey(Convert.ToInt32(dtRecGrid.Rows[i]["ID"]));

                if (!itm.IsColumnNull("NeedExpiryBatch"))
                {
                    if (itm.NeedExpiryBatch)
                    {

                        if (dr["Expiry Date"].ToString() == "")
                        {
                            dr.SetColumnError("Expiry Date", "This field cannot be left blank.");
                            valid = "Please fill the requested feild!";
                        }

                        if (dr["Batch No"].ToString() == "")
                        {
                            dr.SetColumnError("Batch No", "This field cannot be left blank.");
                            valid = "Please fill the requested feild!";
                        }
                    }
                }
            }

            return valid;

        }

        private void cboSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Convert.ToInt32(cboSuppliers.SelectedValue) != 0 && cboSupplier.Text != "Select Supplier")
            {
                Items itm = new Items();
                DataTable dtItem = new DataTable();
                dtItem = itm.GetItemsBySupplier(Convert.ToInt32(cboSuppliers.SelectedValue));
            }
        }

        private void OnAnyCellValueChangedOnRecieveGrid(object sender,
                                                        DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if ((view.FocusedColumn.FieldName == "Pack Qty") || (view.FocusedColumn.FieldName == "Qty/pack") ||
                (view.FocusedColumn.FieldName == "Pack Qty"))
            {
                DataRow dr = gridRecieveView.GetDataRow(gridRecieveView.GetSelectedRows()[0]);
                if (dr["Pack Qty"].ToString() == "" || dr["Qty/pack"].ToString() == "")
                {
                    return;
                }

                int qty = Convert.ToInt32(dr["Pack Qty"]);
                int qtyPerpack = Convert.ToInt32(dr["Qty/pack"]);
                if (qty > 0 && qtyPerpack > 0)
                {
                    dr["BU Qty"] = (qtyPerpack*qty);
                }
            }

            if ((view.FocusedColumn.FieldName == "Pack Qty") || (view.FocusedColumn.FieldName == "Qty/pack") ||
                (view.FocusedColumn.FieldName == "Price/Pack"))
            {
                DataRow dr = gridRecieveView.GetDataRow(gridRecieveView.GetSelectedRows()[0]);
                if (dr["Pack Qty"].ToString() == "" || dr["Qty/pack"].ToString() == "" ||
                    dr["Price/Pack"].ToString() == "")
                {
                    return;
                }

                int qty = Convert.ToInt32(dr["Pack Qty"]);
                //int qtyPerpack = Convert.ToInt32(dr["Qty/pack"]);
                double price = Convert.ToDouble(dr["Price/Pack"]);
                if (qty > 0 && price > 0)
                {
                    dr["Total Price"] = (qty*price);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ReceiveDoc rec = new ReceiveDoc();
            Items itm = new Items();
            string valid = ValidateFields();
            if (valid == "true")
            {
                if (
                    XtraMessageBox.Show("Are you sure you want to save this transaction?", "Confirmation",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                    try
                    {
                        //  mgr.BeginTransaction();
                        //ReceiveDoc receiveValidation = new ReceiveDoc();
                        //if (!receiveValidation.ValidateReceiveDate(Convert.ToDateTime(dtRecDate.Value)))
                        //{
                        //    XtraMessageBox.Show("The receive date should be checked!", "Error", MessageBoxButtons.OK,
                        //                        MessageBoxIcon.Error);
                        //    return;
                        //}

                        DataTable dtRecGrid = (DataTable) receivingGrid.DataSource;
                        //for (int i = 0; i < dtRecGrid.Rows.Count; i++)
                        //{
                        //    if (dtRecGrid.Rows[i]["Expiry Date"] != DBNull.Value)
                        //    {
                        //        if (Convert.ToDateTime(dtRecGrid.Rows[i]["Expiry Date"]) <= DateTime.Now)
                        //        {
                        //            var dialog =XtraMessageBox.Show("The item " + dtRecGrid.Rows[i]["Item Name"].ToString() +" has already expired.  Are you sure you want to receive it?", "Warning",
                        //                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        //                if (dialog == DialogResult.No)
                        //                {
                        //                   return;
                        //                }

                        //        }
                        //    }
                        //}

                        for (int i = 0; i < dtRecGrid.Rows.Count; i++)
                        {
                            if (dtRecGrid.Rows[i]["Expiry Date"] != DBNull.Value)
                            {
                                if (Convert.ToDateTime(dtRecGrid.Rows[i]["Expiry Date"]) <= DateTime.Now)
                                {
                                    var dialog =
                                        XtraMessageBox.Show(
                                            "The item " + dtRecGrid.Rows[i]["Item Name"].ToString() +
                                            " has already expired.  Are you sure you want to receive it?", "Warning",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    if (dialog == DialogResult.No)
                                    {
                                        //XtraMessageBox.Show("You can modify your receive info", "Information",
                                        //                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }

                                }
                            }
                            rec.AddNew();
                            rec.StoreID = Convert.ToInt32(cboStores.EditValue);
                            rec.RefNo = txtRefNo.Text.Trim();
                            rec.Remark = txtRemark.Text;
                            rec.ReceivedBy = txtReceivedBy.Text;

                            DateTime xx = dtRecDate.Value;
                            dtRecDate.CustomFormat = "MM/dd/yyyy";
                            DateTime dtRec = new DateTime();
                            rec.Date = ConvertDate.DateConverter(dtRecDate.Text);
                            dtRec = ConvertDate.DateConverter(dtRecDate.Text);
                            dtRecDate.IsGregorianCurrentCalendar = true;

                            rec.EurDate = dtRecDate.Value;
                            dtRecDate.IsGregorianCurrentCalendar = false;
                            rec.ItemID = Convert.ToInt32(dtRecGrid.Rows[i][0]);
                            if (VisibilitySetting.HandleUnits == 1)
                            {
                                rec.UnitID = 0;
                                rec.QtyPerPack = Convert.ToInt32(dtRecGrid.Rows[i]["Qty/Pack"]);
                            }
                            else if (VisibilitySetting.HandleUnits ==2)
                            {
                                rec.UnitID = Convert.ToInt32(dtRecGrid.Rows[i]["UnitID"]);
                                rec.QtyPerPack = 1;
                            }
                            rec.NoOfPack = Convert.ToInt32(dtRecGrid.Rows[i]["Pack Qty"]);
                           
                            rec.Quantity = rec.NoOfPack*rec.QtyPerPack;
                            rec.QuantityLeft = rec.Quantity;
                            if (dtRecGrid.Rows[i]["Price/Pack"] != null &&
                                dtRecGrid.Rows[i]["Price/Pack"].ToString() != "")
                            {
                                double pre = Convert.ToDouble(dtRecGrid.Rows[i]["Price/Pack"])/rec.QtyPerPack;
                                rec.Cost = Convert.ToDouble(pre);
                            }
                            else
                            {
                                rec.Cost = 0;
                            }
                            itm.LoadByPrimaryKey(Convert.ToInt32(dtRecGrid.Rows[i]["ID"]));
                            rec.BatchNo = dtRecGrid.Rows[i][8].ToString();
                            if (dtRecGrid.Rows[i]["Expiry Date"] != DBNull.Value)
                            {
                                rec.ExpDate = Convert.ToDateTime(dtRecGrid.Rows[i]["Expiry Date"]);
                            }


                            //if ( !itm.IsColumnNull("NeedExpiryBatch") && itm.NeedExpiryBatch)
                            //{
                            //    rec.BatchNo = dtRecGrid.Rows[i][8].ToString();
                            //    rec.ExpDate = Convert.ToDateTime(dtRecGrid.Rows[i]["Expiry Date"]);
                            //}
                            //else
                            //{
                            //    rec.BatchNo = "";
                            //}
                            rec.SupplierID = Convert.ToInt32(cboSupplier.EditValue);
                            rec.SubProgramID = Convert.ToInt32(cboProgram.EditValue);
                            string batch = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() +
                                           DateTime.Now.Minute.ToString() + rec.ItemID.ToString();
                            rec.LocalBatchNo = batch;

                            rec.Out = false;
                            rec.IsApproved = false;
                            rec.Save();

                            dtRecDate.Value = xx;

                        }
                        XtraMessageBox.Show("Transaction Successfully Saved!", "Success", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        ResetFields();
                        //  mgr.CommitTransaction();

                    }
                    catch (Exception exp)
                    {
                        //mgr.RollbackTransaction();
                        BLL.User user = new User();
                        user.LoadByPrimaryKey(MainWindow.LoggedinId);
                        if (user.UserType == UserType.Constants.SYSTEM_ADMIN)
                            XtraMessageBox.Show(exp.Message);
                        else
                            XtraMessageBox.Show("Saving Error!", "Error", MessageBoxButtons.OK);
                    }
                }

            }
            else
            {
                XtraMessageBox.Show(valid, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// Clear the form
        /// </summary>
        private void ResetFields()
        {
            tabControl1.SelectedTabPageIndex = 0;
            cboStores.ItemIndex = 0;
            txtReceivedBy.Text = "";
            txtRemark.Text = "";
            dtRecDate.Value = DateTime.Now;
            txtItemName.Text = "";
            dtSelectedTable.Rows.Clear();
            foreach (DataRowView dr in ((DataView) gridItemChoiceView.DataSource))
            {
                dr["IsSelected"] = false;
            }
        }


        private void OnCategoryClicked(object sender, EventArgs e)
        {
            string value = treeCategory.Selection[0].GetValue("ID").ToString();
            int categoryId = Convert.ToInt32(value.Substring(1));

            Items itm = new Items();
            string FilterString = "";
            switch (value.Substring(0, 1))
            {
                case "S":
                    FilterString = "[SubCategoryID] = " + categoryId.ToString();
                    gridItemChoiceView.ActiveFilterString = FilterString;

                    break;
                case "C":
                case "U":
                    FilterString = "[CategoryId] = " + categoryId.ToString();
                    gridItemChoiceView.ActiveFilterString = FilterString;

                    break;
                case "P":
                    gridItemChoiceView.ActiveFilterString = "";
                    break;
            }

            gridItemChoiceView.ClearSelection();
            gridItemChoiceView.SelectRow(0);

        }



        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            gridItemChoiceView.ActiveFilterString = String.Format("[FullItemName] Like '{0}%' And [TypeID] = {1}",
                                                                  txtItemName.Text, (int) (lkCategories.EditValue ?? 0));
        }

        private void tabControl1_SelectedIndexChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabPage == 0)
            {
                if (dtSelectedTable.Rows.Count > 0)
                {
                    PopulateListToGrid();
                }
                else
                {
                    if (tabControl1.SelectedTabPageIndex != 0)
                    {
                        tabControl1.SelectedTabPageIndex = 0;
                        XtraMessageBox.Show("You must select a drug to populate.", "Validation", MessageBoxButtons.OK,
                                            MessageBoxIcon.Stop);

                    }
                }
            }
            else if (tabPage == 1)
            {
                if (tabControl1.SelectedTabPageIndex != 1)
                    tabPage = 0;
            }
        }

        //private void ValidationStepOne()
        //{
        //    if (gridItemChoiceView.GetSelectedRows().Length > 0)
        //    {
        //        PopulateListToGrid();
        //    }
        //    else
        //    {
        //        XtraMessageBox.Show("You must select a drug to populate.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    }
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GridView view = sender as GridView;
            DataRow dr = view.GetFocusedDataRow();
            if (dr != null)
            {

                dtRecDate.Value = DateTime.Now;
                dtRecDate.CustomFormat = "MM/dd/yyyy";
                DateTime dtCur = ConvertDate.DateConverter(dtRecDate.Text);
                int year = ((dtCur.Month < 11) ? dtCur.Year : dtCur.Year + 1);
                dtRecDate.CustomFormat = "MMM dd,yyyy";
                int itemId = Convert.ToInt32(dr["ID"]);
                ItemDetailReport con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0);
                con.ShowDialog();
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtItem = new DataTable();
            Items itm = new Items();
            selectedType = radioGroup1.EditValue.ToString();
            dtItem = ((selectedType == "Drug") ? itm.GetAllItems(1) : itm.GetAllSupply());
            PopulateCatTree(selectedType);
            PopulateItemList(dtItem);
        }

        /// <summary>
        /// When clicked on the row, the item is selected or deselected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridItemChoiceView_RowClick(object sender, RowClickEventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();
            bool b = (dr["IsSelected"] != DBNull.Value) && Convert.ToBoolean(dr["IsSelected"]);
            dr["IsSelected"] = !b;
            dr.EndEdit();
            OnItemCheckedChanged(new object(), new EventArgs());
        }



        private void gridView1_CustomDrawRowIndicator(object sender,
                                                      DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void repositoryItemSpinEdit1_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            e.Handled = true;
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTabPageIndex = 1;
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            DataRow dr = gridRecieveView.GetDataRow(gridRecieveView.GetSelectedRows()[0]);
            if (dr != null)
            {
                dr.Delete();
            }
        }

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            gridItemChoiceView.ActiveFilterString = string.Format("TypeID={0}", Convert.ToInt32(lkCategories.EditValue));
        }

        private void unitsrepositoryItemLookUpEdit_Enter(object sender, EventArgs e)
        {
            var edit = sender as LookUpEdit;
            if (edit == null) return;
            var clone = new ItemUnit();
            var row = gridRecieveView.GetFocusedDataRow();
            var id = Convert.ToInt32(row["ID"]);
            var filterunit = clone.LoadFromSQl(id);
            //UnitsbindingSource.DataSource = clone.DefaultView;
         
            edit.Properties.DataSource = filterunit;
            edit.Properties.DisplayMember = "Text";
            edit.Properties.ValueMember = "ID";
            
        }

       
       

        
    }
}