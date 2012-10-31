using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using PharmInventory.Forms.Modals;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraEditors;
using PharmInventory.HelperClasses;


namespace PharmInventory.Forms.Transactions
{
    /// <summary>
    /// This form is for issuing items.
    /// The following fields will be required
    /// Item Name,
    /// Dispensary Unit,
    /// Reference Number,
    /// Date of Issue,
    /// Dispensary Unit Remaining Stock on hand (DUSOH),
    /// Pack Qty,
    /// Qty/Pack,
    /// After receiving the following as an input, the form generates a pick list for printing and the issue is confirmed.
    /// </summary>
    public partial class IssueForm : XtraForm
    {
        public IssueForm()
        {
            InitializeComponent();
        }

        #region Members
        DataTable _dtRec = new DataTable();
        int _tabPage = 0;
        int _catID = 0;
        String _selectedType = "Drug";
        DataTable _dtSelectedTable = null;
        #endregion

        /// <summary>
        /// Load all the stores and put them in the combo box
        /// Set the logged in user name in the issued by text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IssuingForm_Load(object sender, EventArgs e)
        {
            PopulateCatTree(_selectedType);
            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStoreConf.Properties.DataSource = cboStores.Properties.DataSource = stor.DefaultView;
            lkCategories.Properties.DataSource = BLL.Type.GetAllTypes();
            lkCategories.ItemIndex = 0;

            int userID = MainWindow.LoggedinId;
            User us = new User();
            us.LoadByPrimaryKey(userID);
            txtIssuedBy.Text = us.FullName;

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

        private void treeCategory_Click(object sender, EventArgs e)
        {
            string value = treeCategory.Selection[0].GetValue("ID").ToString();
            int categoryId = Convert.ToInt32(value.Substring(1));
            _catID = categoryId;
            Items itm = new Items();
            string filterString = "";
            string isStock = ((ckStockOut.Checked) ? "[Status] = 'Stock Out' AND " : "[Status] != 'Stock Out' AND ");
            switch (value.Substring(0, 1))
            {

                case "S":
                    filterString = isStock + "[SubCategoryID] = " + categoryId.ToString();
                    gridItemChoiceView.ActiveFilterString = filterString;                    
                    break;
                case "C":
                case "U":
                    filterString = isStock + "[CategoryId] = " + categoryId.ToString();
                    gridItemChoiceView.ActiveFilterString = filterString;                    
                    break;
                case "P":
                    gridItemChoiceView.ActiveFilterString = ((ckStockOut.Checked) ? "[Status] = 'Stock Out'" : "[Status] != 'Stock Out'");                    
                    break;
            }
            gridItemChoiceView.ClearSelection();
            gridItemChoiceView.SelectRow(0);            
        }

        public void PopulateItemList()
        {
            if (!bw.IsBusy)
            {
                int storeID = (cboStores.EditValue != null) ? Convert.ToInt32(cboStores.EditValue) : 1;
                bw.RunWorkerAsync(storeID);
            }
        }

        DataTable _dtRecGrid = new DataTable();

        /// <summary>
        /// Validate the input based on which tab is active right now. And retuns true if input is valid.
        /// When the input is invalid, the function returns false.
        /// </summary>
        /// <returns>True - If input is valid, False - If input is invalid</returns>
        private bool Validation()
        {
            if (_tabPage == 0)
            {

                if  (_dtSelectedTable != null && _dtSelectedTable.Rows.Count > 0)
                {
                    PopulateGridList();
                }
                else
                {
                    XtraMessageBox.Show("You must select a drug to populate.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            else if (_tabPage == 1)
            {
                if (tabControl1.SelectedTabPageIndex != 1)
                    _tabPage = tabControl1.SelectedTabPageIndex;
                if (tabControl1.SelectedTabPageIndex == 2)
                {
                    PopulatePickList();

                }
            }
            else if (_tabPage == 2)
            {
                if (tabControl1.SelectedTabPageIndex != 2)
                    _tabPage = tabControl1.SelectedTabPageIndex;
            }
            return true;
        }

        private void xpButton1_Click(object sender, EventArgs e)
        {
            Validation();
        }

        /// <summary>
        /// Populates the grid based on the selection.
        /// </summary>
        private void PopulateGridList()
        {
            if (issueGrid.DataSource != null)
            {
                DataTable dt = new DataTable();
                issueGrid.DataSource = dt;
                _dtRecGrid.Rows.Clear();
                _dtRecGrid.Columns.Clear();
            }

            Items itm = new Items();
            Items itmB = new Items();
            Balance bal = new Balance();
            IssueDoc iss = new IssueDoc();
            _tabPage = 1;
            tabControl1.SelectedTabPageIndex = 1;

            if (_dtRecGrid.Columns.Count == 0)
            {                
                string[] str = { "ID", "Stock Code", "Item Name", "Unit", "Store SOH","Dispatchable", "MR Issue Qty", "DU Remaining SOH", "DU AMC", "Recommended Qty", "Pack Qty", "Qty Per Pack", "Requested Qty", "MR DU SOH" };
                foreach (string col in str)
                {
                    _dtRecGrid.Columns.Add(col);
                }
            }

            int count = 1;
            Int64 quantity = 0;
            int storeId = Convert.ToInt32(cboStores.EditValue);

            dtIssueDate.Value = DateTime.Now;
            dtIssueDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);

            foreach (DataRow lst in _dtSelectedTable.Rows)//(ListViewItem lst in lstItem.Items)
            {
                int itmID = Convert.ToInt32(lst["ID"]);
                DataTable dtExp = itm.GetExpiredItemsByID(Convert.ToInt32(cboStores.EditValue), itmID);
                DataTable dtItm = itm.GetItemById(itmID);
                Int64 expAmount = 0;

                foreach (DataRow dr in dtExp.Rows)
                {
                    expAmount = itmB.GetExpiredQtyItemsByID(Convert.ToInt32(dr["ID"]), storeId);
                    quantity = Convert.ToInt64(dr["Quantity"]) - expAmount;//+ adjQuant - issuedQuant - lostQuant 
                }
                Int64 soh = bal.GetSOH(itmID, Convert.ToInt32(cboStores.EditValue), dtCurrent.Month, dtCurrent.Year);
                Int64 dispatchable = Convert.ToInt64(lst["Dispatchable"]);

                string itemName = lst["FullItemName"].ToString();
                object[] obj = { itmID.ToString(), dtItm.Rows[0]["StockCode"].ToString(), itemName, dtItm.Rows[0]["Unit"].ToString(), soh, dispatchable, 0, 0, 0, 0, 0, 0, 0, 0 };

                if (expAmount < soh && quantity < soh)
                {
                    _dtRecGrid.Rows.Add(obj);
                    count++;
                }
                else
                {
                    ResetValues();
                    XtraMessageBox.Show("You are tring to issue an Expired item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tabControl1.TabIndex = 0;
                    break;
                }
            }

            issueGrid.DataSource = _dtRecGrid;
            cboStoreConf.EditValue = cboStores.EditValue;
            dtIssueDate.CustomFormat = "MMM dd,yyyy";

            ReceivingUnits recUnit = new ReceivingUnits();
            recUnit.GetActiveDispensaries();
            cboReceivingUnits.Properties.DataSource = recUnit.DefaultView;
            cboReceivingUnits.Properties.DisplayMember = "Name";
            cboReceivingUnits.Properties.ValueMember = "ID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PopulatePickList();
        }

        /// <summary>
        /// Populates the picklist based on the selected issue configuration
        /// </summary>
        private void PopulatePickList()
        {
            
            string valid = ValidateFields();
            
            if (valid == "true")
            {
                IssueDoc iss = new IssueDoc();
                ReceiveDoc rec = new ReceiveDoc();
                Balance bal = new Balance();
                Items itmB = new Items();
                ReceivingUnits DUs = new ReceivingUnits();

                DataTable dtIssueConf = new DataTable();
                string[] strr = {"No", "Stock Code", "Item Name", "Quantity", "BatchNo", "Expiry Date", "Pack Price", "Total Price", "ItemId", "RecId", 
                                    "Unit Price", "No of Pack", "Qty per pack", "DUSOH", "DUAMC", "Near Expiry", "DURecomended" ,"SOH Left" };
                foreach (string col in strr)
                {
                    dtIssueConf.Columns.Add(col);
                }

                DUs.LoadByPrimaryKey(Convert.ToInt32(cboReceivingUnits.EditValue));
                double duMax = 0.5;
                try
                { duMax = DUs.Max; }
                catch { }
                double duMaxDays = duMax * 30;
                lblNearExpiryComment.Text = "*Near Expiry means items that has expiry in the next " + duMaxDays.ToString() + " Days.";

                DateTime xx = dtIssueDate.Value;
                dtIssueDate.CustomFormat = "MM/dd/yyyy";
                DateTime dtIss = ConvertDate.DateConverter(dtIssueDate.Text);
                dtIssueDate.Value = DateTime.Now;

                DateTime dtCurrent = new DateTime();// Convert.ToDateTime(dtIssueDate.Text);
                dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
                dtIssueDate.Value = xx;
                dtIssueDate.CustomFormat = "MMM dd,yyyy";
                DataTable dtIssueGrid = (DataTable)issueGrid.DataSource;
                for (int i = 0; i < dtIssueGrid.Rows.Count; i++)
                {
                    Int64 expAmount = itmB.GetExpiredQtyItemsByID(Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]), Convert.ToInt32(cboStores.EditValue));
                    Int64 sohQty=0;
                
                    try
                    {
                        sohQty = bal.GetSOH(Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]), Convert.ToInt32(cboStores.EditValue), dtIss.Month, dtIss.Year) - expAmount;
                    }
                    catch
                    {
                        XtraMessageBox.Show("Please check all the information you have input into the form including the issue date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (sohQty >= Convert.ToInt64(dtIssueGrid.Rows[i]["Requested Qty"]))
                    {
                        Items itm = new Items();
                        itm.LoadByPrimaryKey(Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]));
                        _dtRec = itm.NeedExpiryBatch ? rec.GetBatchToIssue(Convert.ToInt32(cboStores.EditValue), Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]), dtIss) : rec.GetSupplyToIssueWithOutBatch(Convert.ToInt32(cboStores.EditValue), Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]), dtIssueDate.Value);

                        // Extream measures:
                        // This has tobe properly mitigated
                        // if there is the balance an there is no batch to be issued, just select the last batch and add the balance to it.



                        if (rec.RowCount > 0)
                        {
                            int j = 0;
                            Int64 quantity = Convert.ToInt64(dtIssueGrid.Rows[i]["Requested Qty"]);
                            double sohleft = sohQty - quantity;
                            while (quantity > 0)
                            {
                                if (_dtRec != null)
                                {
                                    string batch = ((itm.NeedExpiryBatch) ? _dtRec.Rows[j]["BatchNo"].ToString() : "");
                                    //double quantityleft = (Convert.ToInt32(_dtRec.Rows[j]["QuantityLeft"]) - quantity);
                                    Int64 qu = ((quantity > Convert.ToInt32(_dtRec.Rows[j]["QuantityLeft"])) ? Convert.ToInt64(_dtRec.Rows[j]["QuantityLeft"]) : quantity);
                                    double qtyPerPack = Convert.ToDouble(_dtRec.Rows[j]["QtyPerPack"]);
                                    double unitPrice = Convert.ToDouble(_dtRec.Rows[j]["Cost"]);
                                    double packPrice = unitPrice * qtyPerPack; //Convert.ToDouble(dtIssueGrid.Rows[i]["Qty Per Pack"]);
                                    double reqPackQty = Convert.ToDouble(dtIssueGrid.Rows[i]["Pack Qty"]);
                                    double totPrice = unitPrice * quantity;
                                    bool nearExp = false;
                                    DateTime dtx = new DateTime();
                                    if (itm.NeedExpiryBatch)
                                    {
                                        dtx = Convert.ToDateTime(_dtRec.Rows[j]["ExpDate"]);
                                        if (dtx <= DateTime.Now.AddDays(duMaxDays))
                                            nearExp = true;
                                    }
                                    int rowNo = j + 1;
                                    object[] obj = {rowNo, dtIssueGrid.Rows[i]["Stock Code"], dtIssueGrid.Rows[i]["Item Name"], qu, batch, dtx.ToString("MMM dd,yyyy"), 
                                                    packPrice.ToString("#,##0.#0"), ((totPrice != double.NaN) ? totPrice.ToString("#,##0.#0") : "0"),
                                                    Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]), Convert.ToInt32(_dtRec.Rows[j]["ID"]), 
                                                    unitPrice.ToString("#,##0.#0"), dtIssueGrid.Rows[i]["Pack Qty"], dtIssueGrid.Rows[i]["Qty Per Pack"], 
                                                    dtIssueGrid.Rows[i]["DU Remaining SOH"], dtIssueGrid.Rows[i]["DU AMC"], ((nearExp) ? "Yes" : "No"), 
                                                    dtIssueGrid.Rows[i]["Recommended Qty"],sohleft};
                                    dtIssueConf.Rows.Add(obj);
                                }
                                quantity = quantity - Convert.ToInt64(_dtRec.Rows[j]["QuantityLeft"]);
                                j++;
                            }
                         
                        }
                        else
                        {                            
                            XtraMessageBox.Show("There is no enough Quantity in the store OR It has expired. Please check the issue date, quantity and try again!");
                        }
                    }
                    else
                    {                        
                        XtraMessageBox.Show("There is not enough Quantity in the store OR It has expired. Please check the issue date, quantity and try again!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                if (dtIssueConf.Rows.Count > 0)
                {
                    _tabPage = 2;
                    
                    tabControl1.SelectedTabPageIndex = 2;
                    txtConfRef.Text = txtRefNo.Text;
                    txtIssuedDate.Value = dtIssueDate.Value;
                    txtIssuedTo.Text = cboReceivingUnits.Text;

                    txtStore.Text = cboStores.Text;
                    txtConIssuedBy.Text = txtIssuedBy.Text;
                    txtConRemark.Text = txtRemark.Text;
                    gridConfirmation.DataSource = dtIssueConf;
                }
            }
            else
            {
                tabControl1.SelectedTabPageIndex = 1;
                XtraMessageBox.Show(valid, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ckSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            //foreach (ListViewItem lst in lstItem.Items)
            //{
            //    lst.Checked = ckSelectAll.Checked;
            //}

            //if (ckSelectAll.Checked)
            //{
            //    ckSelectAll.Text = "UnSelect All";
            //}
            //else
            //{
            //    ckSelectAll.Text = "Select All";
            //}
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {            
            if (ckStockOut.Checked)
                gridItemChoiceView.ActiveFilterString = "[Status] = 'Stock Out' AND [FullItemName] Like '" + txtItemName.Text + "%'";
            else
                gridItemChoiceView.ActiveFilterString = "[Status] != 'Stock Out' AND [FullItemName] Like '" + txtItemName.Text + "%'";
        }

        /// <summary>
        /// Validate the fields in the issue form
        /// </summary>
        /// <returns>"true" is returned if valid; if invalid, the error description is returned as a string which 
        /// can be used in the message displayed to the user.
        /// </returns>
        private string ValidateFields()
        {
            string valid = "true";

            if (!dxValidationProvider1.Validate())
            {
                valid = "All * marked fields are required!";
            }

            if (Convert.ToDateTime(dtIssueDate.Value).Date > DateTime.Now.Date)
            {
                valid = "You cannot pick a Date into the future!";
            }

            if (dtIssueDate.IsGregorianCurrentCalendar)
            {
                valid = "The Date has to be in Ethiopian Calander.";
            }

            DataTable dtIssueGrid = (DataTable)issueGrid.DataSource;
            if (dtIssueGrid != null)
                for (int i = 0; i < dtIssueGrid.Rows.Count; i++)
                {
                    if (Convert.ToInt64(dtIssueGrid.Rows[i]["Requested Qty"]) == 0)
                    {
                        dtIssueGrid.Rows[i].SetColumnError("Requested Qty", "Cannot be 0");
                        valid = "All * marked fields are required!";
                    }

                    if (Convert.ToInt64(dtIssueGrid.Rows[i]["Qty Per Pack"]) == 0)
                    {
                        dtIssueGrid.Rows[i].SetColumnError("Qty Per Pack", "Cannot be 0");
                        valid = "All * marked fields are required!";
                    }

                    if (Convert.ToInt64(dtIssueGrid.Rows[i]["Pack Qty"]) == 0)
                    {
                        dtIssueGrid.Rows[i].SetColumnError("Pack Qty", "Cannot be 0");
                        valid = "All * marked fields are required!";
                    }

                    if(Convert.ToInt64(dtIssueGrid.Rows[i]["Requested Qty"])>Convert.ToInt64(dtIssueGrid.Rows[i]["Dispatchable"]))
                    {
                        dtIssueGrid.Rows[i].SetColumnError("Requested Qty", "Requested quantity for this item cannot be greater than the usable stock!");
                        valid = String.Format("Requested quantity for item cannot be greater than the usable stock!");
                    }
                }

            return valid;
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string valid = ValidateFields();
            if (valid == "true")
            {
                if (XtraMessageBox.Show("Are You Sure, You want to save this Transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    IssueDoc issDoc = new IssueDoc();
                    ReceiveDoc recDoc = new ReceiveDoc();
                    Balance bal = new Balance();
                    DataTable dtConfirmation = (DataTable)gridConfirmation.DataSource;
                    for (int i = 0; i < dtConfirmation.Rows.Count; i++)
                    {
                        issDoc.GetDULastIssue(Convert.ToInt32(dtConfirmation.Rows[i]["ItemID"]), Convert.ToInt32(cboReceivingUnits.EditValue));
                        if (issDoc.RowCount > 0)
                        {
                            //issDoc.DUSOH = ((dtConfirmation.Rows[i]["DUSOH"] != null) ? Convert.ToInt64(dtConfirmation.Rows[i]["DUSOH"]) : 0);
                            //issDoc.Save();
                        }
                        //Saving the issue
                        issDoc.AddNew();
                        issDoc.StoreId = Convert.ToInt32(cboStores.EditValue);
                        issDoc.RefNo = txtRefNo.Text.Trim();
                        issDoc.ReceivingUnitID = Convert.ToInt32(cboReceivingUnits.EditValue);
                        DateTime xx = dtIssueDate.Value;
                        dtIssueDate.CustomFormat = "MM/dd/yyyy";

                        DateTime dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
                        issDoc.Date = dtCurrent;
                        dtIssueDate.IsGregorianCurrentCalendar = true;
                        issDoc.EurDate = dtIssueDate.Value;
                        dtIssueDate.IsGregorianCurrentCalendar = false;
                        issDoc.RecievDocID = Convert.ToInt32(dtConfirmation.Rows[i]["RecId"]); // Used to have 8 as an index
                        issDoc.IsApproved = true;
                        issDoc.IsTransfer = false;
                        issDoc.Remark = txtRemark.Text;
                        issDoc.IssuedBy = txtIssuedBy.Text;
                        issDoc.DUSOH = Convert.ToInt32(dtConfirmation.Rows[i]["DUSOH"]);
                        issDoc.ItemID = Convert.ToInt32(dtConfirmation.Rows[i]["ItemId"]);
                        issDoc.Quantity = Convert.ToInt64(dtConfirmation.Rows[i]["Quantity"]);
                        issDoc.NoOfPack = Convert.ToInt32(dtConfirmation.Rows[i]["No Of Pack"]);
                        issDoc.QtyPerPack = Convert.ToInt32(dtConfirmation.Rows[i]["Qty Per Pack"]);
                        issDoc.BatchNo = dtConfirmation.Rows[i]["BatchNo"].ToString();
                        issDoc.Cost = Convert.ToDouble(dtConfirmation.Rows[i]["Unit Price"]);

                        issDoc.RecomendedQty = Convert.ToInt32(dtConfirmation.Rows[i]["DURecomended"]);// ((recQty > 0) ? Convert.ToInt64(recQty) : 0);
                        //End DU
                        issDoc.Save();

                        //updating the receiving doc
                        recDoc.LoadByPrimaryKey(Convert.ToInt32(dtConfirmation.Rows[i]["RecId"]));
                        recDoc.QuantityLeft = recDoc.QuantityLeft - issDoc.Quantity;
                        recDoc.Out = (recDoc.QuantityLeft == 0) ? true : false;
                        recDoc.Save();
                        //Log Activity
                       dtIssueDate.Value = xx;
                    }
                    XtraMessageBox.Show("Transaction Succsfully Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValues();
                    IssuingForm_Load(null, null);
                }
            }
            else
            {
                XtraMessageBox.Show(valid, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            //Print after confirm
            xpButton2_Click(sender, e);
        }


        /// <summary>
        /// The issue form is reset so that every input is cleared out.
        /// </summary>
        private void ResetValues()
        {
            _dtRec = new DataTable();
            _dtRecGrid = new DataTable();
            _dtRecGrid.Columns.Clear();
            _dtSelectedTable = null;// new DataTable();
            dtIssueDate.Value = DateTime.Now;
            issueGrid.DataSource = null;
            gridConfirmation.DataSource = null;
            txtRefNo.Text = "";
            txtConfRef.Text = "";
            txtIssuedBy.Text = "";
            txtIssuedDate.Text = "";
            txtIssuedTo.Text = "";
            txtItemName.Text = "";
            txtRemark.Text = "";
            txtStore.Text = "";
            cboReceivingUnits.ItemIndex = -1;
            cboStores.EditValue = 1;
            PopulateItemList();
            _tabPage = 0;
            tabControl1.SelectedTabPageIndex = 0;            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void xpButton3_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void ckStockOut_CheckedChanged(object sender, EventArgs e)
        {
            gridItemChoiceView.Columns[0].Visible = !ckStockOut.Checked;

            gridItemChoiceView.ActiveFilterString = ckStockOut.Checked ? "[Status] = 'Stock Out'" : "[Status] != 'Stock Out'";
        }

        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null)
            {
                PopulateItemList();
            }
        }

        private void xpButton2_Click(object sender, EventArgs e)
        {
            //if(printableComponentLink2==null)
            //    printableComponentLink2 = new PrintableComponentLink();
            //printableComponentLink2.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);

            //printableComponentLink2.CreateDocument();
            //printableComponentLink2.Landscape = true;
            //PrinterSettings settings = new PrinterSettings();
            ////Console.WriteLine(settings.PrinterName);
            //printableComponentLink2.Print(settings.PrinterName);
            ////printableComponentLink2.PrintDlg();
        }

        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            //DateTime xx = dtIssueDate.Value;
            //dtIssueDate.Value = DateTime.Now; //Commented so that the issue date and the pick list printing date will be the same.
            dtIssueDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
            //dtIssueDate.Value = xx;
            string[] header = { "Pick List ", "Date: " + dtCurrent.ToShortDateString(), " Ref No: " + txtConfRef.Text, "From: " + txtStore.Text, "To: " + txtIssuedTo.Text };
            printableComponentLink2.PageHeaderFooter = header;
            printableComponentLink2.Landscape = true;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF (20, 0, 200, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(20, 20, 200, 100), BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(20, 40, 200, 100), BorderSide.None);
            TextBrick brick3 = e.Graph.DrawString(header[3], Color.DarkBlue, new RectangleF(300, 20, 200, 100), BorderSide.None);
            TextBrick brick4 = e.Graph.DrawString(header[4], Color.DarkBlue, new RectangleF(300, 40, 200, 100), BorderSide.None);
        }

        private void cboReceivingUnits_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable issGrid = (DataTable)issueGrid.DataSource;
            if (issGrid != null)
            {
                if (cboReceivingUnits.EditValue != null && issGrid.Rows.Count > 0)
                {
                    //DAte Function
                    DateTime xx = dtIssueDate.Value;
                    dtIssueDate.Value = DateTime.Now;
                    dtIssueDate.CustomFormat = "MM/dd/yyyy";
                    DateTime dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
                    dtIssueDate.Value = xx;

                    IssueDoc iss = new IssueDoc();
                    Balance bal = new Balance();
                    int receivingUnit = Convert.ToInt32(cboReceivingUnits.EditValue);
                    //GeneralInfo info = new GeneralInfo();
                    //info.LoadAll();
                    ReceivingUnits DUs = new ReceivingUnits();
                    DUs.LoadByPrimaryKey(receivingUnit);
                    double dumax = 0.5;
                    try
                    {
                        dumax = DUs.Max;
                    }
                    catch
                    { }//.DUMax;//replace with the specific du max

                    for (int i = 0; i < issGrid.Rows.Count; i++)
                    {
                        int itmId = Convert.ToInt32(issGrid.Rows[i]["ID"]);
                        int lastIssueQty = iss.GetDULastIssueQty(itmId, receivingUnit);
                        int lastDUSOH = iss.GetDULastSOH(itmId, receivingUnit);
                        issGrid.Rows[i]["MR Issue Qty"] = lastIssueQty;
                        issGrid.Rows[i]["MR DU SOH"] = lastDUSOH;
                        //int lstSOH = lastDUSOH + lastIssueQty;
                        const int lstSOH = 0;
                        //issGrid.Rows[i]["DU Remaining SOH"] = lstSOH;
                        issGrid.Rows[i]["DU Remaining SOH"] = 0;
                        int yer = (dtCurrent.Month < 11) ? dtCurrent.Year : dtCurrent.Year - 1;
                        Int64 duAmc = bal.CalculateDUAMC(itmId, receivingUnit, dtCurrent.Month, dtCurrent.Year, lstSOH);
                        issGrid.Rows[i]["DU AMC"] = duAmc;
                        double recQty = (duAmc * dumax) - Convert.ToInt32(issGrid.Rows[i]["DU Remaining SOH"]);
                        issGrid.Rows[i]["Recommended Qty"] = ((recQty > 0) ? Convert.ToInt64(recQty) : 0);
                    }
                }
            }
        }


        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtItem = new DataTable();
            Items itm = new Items();
            _selectedType = radioGroup1.EditValue.ToString();
            PopulateCatTree(_selectedType);
            PopulateItemList();
        }

        private void gridItemChoiceView_RowClick(object sender, RowClickEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                DataRow dr = view.GetFocusedDataRow();
                dr["IsSelected"] = ((dr["IsSelected"] == DBNull.Value) ? true : !Convert.ToBoolean(dr["IsSelected"])); // true;
            }
            OnItemCheckedChanged(new object(), new EventArgs());
        }

        private void OnItemCheckedChanged(object sender, EventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();

            bool b = (dr["IsSelected"] != DBNull.Value) && Convert.ToBoolean(dr["IsSelected"]);

            if (b)
            {
                try
                {
                    _dtSelectedTable.ImportRow(dr);
                }
                catch { }
            }
            else
            {
                _dtSelectedTable.PrimaryKey = new DataColumn[] { _dtSelectedTable.Columns["ID"] };
                int id = Convert.ToInt32(dr["ID"]);
                DataRow rw = _dtSelectedTable.Rows.Find(id);
                if (rw != null)
                {
                    _dtSelectedTable.Rows.Remove(rw);
                    try
                    {
                        DataRow[] dataRows = _dtRecGrid.Select(String.Format("ID = {0}", dr["ID"]));// dtRecGrid.Rows.Remove(dtRecGrid.Rows.Find(dr["ID"]));
                        foreach (DataRow r in dataRows)
                        {
                            r.Delete();
                        }
                    }
                    catch { }
                }

            }

        }

        private void gridItemChoiceView_RowClick_1(object sender, RowClickEventArgs e)
        {

            DataRow dr = gridItemChoiceView.GetFocusedDataRow();
            bool b = (dr["IsSelected"] != DBNull.Value) ? Convert.ToBoolean(dr["IsSelected"]) : false;
            dr["IsSelected"] = !b;
            OnItemCheckedChanged(new object(), new EventArgs());
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            if ((view.FocusedColumn.FieldName == "Pack Qty") || (view.FocusedColumn.FieldName == "Qty Per Pack") || (view.FocusedColumn.FieldName == "DU Remaining SOH"))
            {
                DataRow dr = issueGridView.GetDataRow(issueGridView.GetSelectedRows()[0]);

                int qty = Convert.ToInt32(dr["Pack Qty"]);
                int qtyPerpack = Convert.ToInt32(dr["Qty Per Pack"]);
                if (qty > 0 && qtyPerpack > 0)
                {
                    dr["Requested Qty"] = (qtyPerpack * qty);
                }

                DateTime xx = dtIssueDate.Value;
                dtIssueDate.Value = DateTime.Now;
                dtIssueDate.CustomFormat = "MM/dd/yyyy";
                DateTime dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
                dtIssueDate.Value = xx;
                //recalculate AMC Again
                // IssueDoc iss = new IssueDoc();
                Balance bal = new Balance();
                int receivingUnit = Convert.ToInt32(cboReceivingUnits.EditValue);

                Int64 duAmc = 0;
                int itmId = Convert.ToInt32(dr["ID"]);                
                int lstSOH = ((dr["DU Remaining SOH"] != null && dr["DU Remaining SOH"] != DBNull.Value) ? Convert.ToInt32(dr["DU Remaining SOH"]) : 0);
                duAmc = bal.CalculateDUAMC(itmId, receivingUnit, dtCurrent.Month, dtCurrent.Year, lstSOH);
                dr["DU AMC"] = duAmc;

                //recommend qty to du
                ReceivingUnits DUs = new ReceivingUnits();
                DUs.LoadByPrimaryKey(receivingUnit);
                double dumax = 0.5;
                try
                {
                    dumax = DUs.Max;
                }
                catch
                { }
                double recQty = (Convert.ToInt32(dr["DU AMC"]) * dumax) - lstSOH;
                dr["Recommended Qty"] = ((recQty > 0) ? Convert.ToInt64(recQty) : 0);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            _dtSelectedTable = new DataTable();
        }

        /// <summary>
        /// We want to show the item detail report when the user double clicks on the grid row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridItemChoiceView_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            DataRow dr = view.GetFocusedDataRow();
            if (dr == null) return;

            dtIssueDate.Value = DateTime.Now;
            dtIssueDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCur = ConvertDate.DateConverter(dtIssueDate.Text);
            int year = ((dtCur.Month < 11) ? dtCur.Year : dtCur.Year + 1);
            dtIssueDate.CustomFormat = "MMM dd,yyyy";
            int itemId = Convert.ToInt32(dr["ID"]);
            ItemDetailReport con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0);
            con.ShowDialog();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            //if (e.Info.IsRowIndicator)
            //{
            //    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            //}
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int storeId = Convert.ToInt32(e.Argument);
            dtIssueDate.Value = DateTime.Now;
            dtIssueDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
            Balance bal = new Balance();
            e.Result = bal.ItemListToIssue(storeId, dtCurrent, _selectedType, bw);
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBarControl1.Properties.Maximum = 100;
            //progressBarControl1.EditValue = e.ProgressPercentage;
            //progressBarControl1.PerformStep();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable dtList;
            gridItemsChoice.DataSource = dtList = (DataTable)e.Result;
            if (_dtSelectedTable == null)
            {
                _dtSelectedTable = dtList.Clone();
            }
            gridItemChoiceView.ActiveFilterString = "";
            gridItemChoiceView.ActiveFilterString = "[Status] != 'Stock Out'";
            //progressBarControl1.Visible = false;
        }

        private void tabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page == tabPage2)
            {
                if (!Validation())
                {
                    e.Cancel = true;
                }
            }
        }

        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void repositoryItemButtonEdit3_Click(object sender, EventArgs e)
        {
            DataRow dr = issueGridView.GetDataRow(issueGridView.GetSelectedRows()[0]);
            if (dr != null)
            {
                dr.Delete();
            }
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            DataRow dr = issueGridView.GetDataRow(issueGridView.GetSelectedRows()[0]);
            if (dr != null)
            {
                dr.Delete();
            }
        }

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            gridItemChoiceView.ActiveFilterString = string.Format("TypeID={0}", Convert.ToInt32(lkCategories.EditValue));
        }
        private void toolTipController1_BeforeShow(object sender, DevExpress.Utils.ToolTipControllerShowEventArgs e)
        {
            //
        } 
    }
}