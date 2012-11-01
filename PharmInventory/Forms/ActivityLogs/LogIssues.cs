using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;
using EthiopianDate;

namespace PharmInventory.Forms.ActivityLogs
{
    /// <summary>
    /// Shows the log of the issued items.
    /// It can also be used to delete unprocessed issue transactions.
    /// </summary>
    public partial class LogIssues : XtraForm
    {
        public LogIssues()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populate the lookups
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageItems_Load(object sender, EventArgs e)
        {
            ReceivingUnits rec = new ReceivingUnits();
            DataTable drRec = rec.GetAllApplicableDU();
            cboIssuedTo.Properties.DataSource = drRec;
            cboIssuedTo.ItemIndex = -1;//.SelectedIndex = -1;
            cboIssuedTo.Text = @"Select Issue Location";

            // populate the receiving unit's lookup edit
            ReceivingUnits rus = new ReceivingUnits();
            rus.GetActiveDispensaries();
            lkEditReceivingUnis.DataSource = rus.DefaultView;

            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStores.Properties.DataSource = stor.DefaultView;
            cboStores.ItemIndex = 0;

            try
            {
                DataRowView dr = (DataRowView)lstTree.GetDataRecordByNode(lstTree.Nodes[0].FirstNode);

                if (dr == null) return;

                //lstTransactions.Items.Clear();                
                IssueDoc iss = new IssueDoc();
                DataTable dtRec;
                if (dr["ParentID"] == DBNull.Value)
                {
                    EthiopianDate.EthiopianDate ethiopianDate = new EthiopianDate.EthiopianDate(Convert.ToInt32(dr["ID"]), 1, 1);
                    dtRec = iss.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), ethiopianDate.StartOfFiscalYear.ToGregorianDate(), ethiopianDate.EndOfFiscalYear.ToGregorianDate());
                    string dateString = dr["RefNo"].ToString();
                    lblIssDate.Text = dateString;
                }
                else
                {
                    //dtRec = iss.GetTransactionByRefNo(dr["RefNo"].ToString(), Convert.ToInt32(cboStores.EditValue), dr["Date"].ToString());
                    dtRec = iss.GetTransactionByRefNo(dr["RefNo"].ToString(), Convert.ToDateTime(dr["Date"]));
                    lblIssDate.Text = Convert.ToDateTime(dr["Date"]).ToString("MM dd,yyyy");
                }
                gridIssues.DataSource = dtRec;
            }
            catch (Exception ex)
            {
                // do nothing
            }
            
        }

        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue == null) return;
            IssueDoc iss = new IssueDoc();
            DataTable dtRec = iss.GetDistinctIssueDocments(Convert.ToInt32(cboStores.EditValue));
            lstTree.DataSource = dtRec;

            DateTime dt1 = EthiopianDate.EthiopianDate.Now.StartOfFiscalYear.ToGregorianDate();
            DateTime dt2 = DateTime.Now;
            dtRec = iss.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue),dt1,dt2);
            lblIssDate.Text = @"Current Year";
            gridIssues.DataSource = dtRec;
        }

        private void cboIssuedTo_EditValueChanged(object sender, EventArgs e)
        {
            if (cboIssuedTo.EditValue == null || cboStores.EditValue == null) return;

            IssueDoc iss = new IssueDoc();

            DataTable dtRec = iss.GetTransactionByReceivingUnit(Convert.ToInt32(cboStores.EditValue), Convert.ToInt32(cboIssuedTo.EditValue));
            gridIssues.DataSource = dtRec;
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            //CALENDAR:
            IssueDoc iss = new IssueDoc();
            //dtFrom.CustomFormat = "MM/dd/yyyy";
            //dtTo.CustomFormat = "MM/dd/yyyy";

            //DateTime dteFrom = ConvertDate.DateConverter(dtFrom.Text);
            //DateTime dteTo = ConvertDate.DateConverter(dtTo.Text);
            
            DataTable dtRec = dtFrom.Value < dtTo.Value ? iss.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dtFrom.Value, dtTo.Value) : iss.GetAllTransaction(Convert.ToInt32(cboStores.EditValue));
            gridIssues.DataSource = dtRec;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();

            if (dr == null) return;

            int tranId = Convert.ToInt32(dr["ID"]);
            ReceiveDoc rec = new ReceiveDoc();
            IssueDoc iss = new IssueDoc();
            iss.LoadByPrimaryKey(tranId);

            string batchNo = iss.BatchNo;
            Int64 qty = iss.Quantity;
            try
            {
                if (iss.RecievDocID.ToString() != "")
                    rec.LoadByPrimaryKey(iss.RecievDocID);
                else
                    rec.GetTransactionByBatch(iss.ItemID, iss.BatchNo, iss.StoreId);
            }
            catch
            {
                rec.GetTransactionByBatch(iss.ItemID, iss.BatchNo, iss.StoreId);
            }

            if (batchNo != rec.BatchNo)
            {
                XtraMessageBox.Show("Unable to Delete, This Transaction has been processed. Try Loss and Adjustment.", "Unable to Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
            {
                if (XtraMessageBox.Show("Are You Sure, You want to delete this Transaction? You will not be able to restore this data.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rec.QuantityLeft = rec.QuantityLeft + iss.Quantity;
                    if (rec.QuantityLeft > 0)
                        rec.Out = false;
                    rec.Save();
                    IssueDocDeleted isdelete = new IssueDocDeleted();
                    isdelete.AddNew();
                    isdelete.ID = iss.ID;
                    isdelete.ItemID = iss.ItemID;
                    isdelete.StoreId = iss.StoreId;
                    isdelete.ReceivingUnitID = iss.ReceivingUnitID;
                    isdelete.LocalBatchNo = iss.LocalBatchNo;
                    isdelete.Quantity = iss.Quantity;
                    isdelete.Date = iss.Date;
                    isdelete.IsTransfer = iss.IsTransfer;
                    isdelete.IssuedBy = iss.IssuedBy;
                    isdelete.Remark = iss.Remark;
                    isdelete.RefNo = iss.RefNo;
                    isdelete.BatchNo = iss.BatchNo;
                    isdelete.IsApproved = iss.IsApproved;
                    isdelete.Cost = iss.Cost;
                    isdelete.NoOfPack = iss.NoOfPack;
                    isdelete.QtyPerPack = iss.QtyPerPack;
                    isdelete.DUSOH = iss.DUSOH;
                    isdelete.EurDate = iss.EurDate;
                    isdelete.RecievDocID = iss.RecievDocID;
                    isdelete.RecomendedQty = iss.RecomendedQty;
                    isdelete.Save();

                    iss.MarkAsDeleted();
                    iss.Save();

                    DataTable dtRec = iss.GetAllTransaction(Convert.ToInt32(cboStores.EditValue));
                    gridIssues.DataSource = dtRec;
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();

            if (dr == null) return;

            int tranId = Convert.ToInt32(dr["ID"]);
            EditIssue edRec = new EditIssue(tranId);
            MainWindow.ShowForms(edRec);
            IssueDoc iss = new IssueDoc();
            DataTable dtRec = iss.GetAllTransaction(Convert.ToInt32(cboStores.EditValue));
            /*PopulateTransaction(dtRec);*/
            gridIssues.DataSource = dtRec;
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog {Filter = @"Microsoft Excel | *.xls"};

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                gridIssues.MainView.ExportToXls(saveDlg.FileName);
                
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();
            DevExpress.XtraPrinting.PrintableComponentLink pcl = new DevExpress.XtraPrinting.PrintableComponentLink(ps);

            pcl.CreateReportHeaderArea += this.pcl_CreateReportHeaderArea;
            pcl.Component = gridIssues;
            pcl.Landscape = true;
            pcl.CreateDocument();
            ps.PreviewFormEx.ShowDialog();
        }

        private void pcl_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx
                                                      {
                                                          Value = DateTime.Now,
                                                          CustomFormat = "MM/dd/yyyy"
                                                      };
            DateTime dtCurrent = Convert.ToDateTime(dtDate.Text);
            //old header
            //string header = info.HospitalName + " Issue Activity Log " + dtCurrent.ToString("MM dd,yyyy");
            
            string refNumber = lstTree.FocusedNode.GetDisplayText("RefNo");
            //header that includes refno
            string header = info.HospitalName + " Issue Activity Log \n" + dtCurrent.ToString("MM dd,yyyy") + "  RefNumber  " + refNumber;

            TextBrick brick = e.Graph.DrawString(header, Color.Navy, new RectangleF(0, 0, 800, 40),
                                                 DevExpress.XtraPrinting.BorderSide.None);
            brick.Font = new Font("Arial", 16);
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();

            if (dr == null) return;

            int tranId = Convert.ToInt32(dr["ID"]);

            CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx
                                                      {
                                                          Value = DateTime.Now,
                                                          CustomFormat = "MM/dd/yyyy"
                                                      };
            DateTime dtCur = ConvertDate.DateConverter(dtDate.Text);
            int itemId = Convert.ToInt32(dr["ItemID"]);
            int yr = ((dtCur.Month < 11) ? dtCur.Year : dtCur.Year + 1);
            ItemDetailReport con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), yr, 0);
            con.ShowDialog();
        }
        
        private void lstTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DataRowView dr = (DataRowView)lstTree.GetDataRecordByNode(lstTree.FocusedNode);
            if (dr == null) return;
            //lstTransactions.Items.Clear();                
            IssueDoc iss = new IssueDoc();
            DataTable dtRec;
            if (dr["ParentID"] == DBNull.Value)
            {
                EthiopianDate.EthiopianDate ethiopianDate=new EthiopianDate.EthiopianDate(Convert.ToInt32(dr["ID"]),1,1);
                dtRec = iss.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), ethiopianDate.StartOfFiscalYear.ToGregorianDate(), ethiopianDate.EndOfFiscalYear.ToGregorianDate());
                string dateString = dr["RefNo"].ToString();
                lblIssDate.Text = dateString;
            }
            else
            {
                //dtRec = iss.GetTransactionByRefNo(dr["RefNo"].ToString(), Convert.ToInt32(cboStores.EditValue), dr["Date"].ToString());
                dtRec = iss.GetTransactionByRefNo(dr["RefNo"].ToString(), Convert.ToDateTime(dr["Date"]));
                lblIssDate.Text = Convert.ToDateTime(dr["Date"]).ToString("MM dd,yyyy");
            }
            gridIssues.DataSource = dtRec;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView dr = (DataRowView)lstTree.GetDataRecordByNode(lstTree.FocusedNode);
            var iss = new EditIssueDocRefrenceNo((string)dr["RefNo"]);
            iss.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView dr = (DataRowView)lstTree.GetDataRecordByNode(lstTree.FocusedNode);
            if (XtraMessageBox.Show("Are You Sure, You want to delete this?", "Confirmation", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var dis = new IssueDoc();
                DataTable dtbl = dis.GetTransactionByRefNo((string)dr["RefNo"]);
                foreach (DataRow dataRow in dtbl.Rows)
                {
                    dataRow.Delete();
                }
                dis.MarkAsDeleted();
                dis.Save();
            }
        }
    }
}