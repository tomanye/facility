using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;


namespace PharmInventory.Forms.ActivityLogs
{
    /// <summary>
    /// Displays the log of the received items.
    /// </summary>
    public partial class LogReceive : XtraForm
    {
        
        public LogReceive()
        {
            InitializeComponent();
        }

        readonly CalendarLib.DateTimePickerEx _dtDate = new CalendarLib.DateTimePickerEx();
        private void ManageItems_Load(object sender, EventArgs e)
        {
            Supplier sup = new Supplier();
            DataTable dtSup = sup.GetSuppliersWithTransaction();
            cboSupplier.Properties.DataSource = dtSup;
            cboSupplier.ItemIndex = -1;
            cboSupplier.Text = "Select Supplier";

            // bind the supplier lookup for the grid.
            lkEditSupplier.DataSource = dtSup;

            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStores.Properties.DataSource = stor.DefaultView;
            cboStores.ItemIndex = 0;

            // bind the current dates
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;

            try
            {
                 //CALENDAR:

            CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx
                                                      {
                                                          CustomFormat = "MM/dd/yyyy",
                                                          Value = DateTime.Now
                                                      };
            DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);

            DataRowView dr = (DataRowView)lstTree.GetDataRecordByNode(lstTree.Nodes[0].FirstNode);

            if (dr == null) return;
            
            ReceiveDoc rec = new ReceiveDoc();
            DataTable dtRec;
            if (dr["ParentID"] == DBNull.Value)
            {
                int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
                DateTime dt1 = new DateTime(Convert.ToInt32(dr["ID"]) - 1, 11, 1);
                DateTime dt2 = new DateTime(Convert.ToInt32(dr["ID"]), 11, 1);
                dtRec = rec.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dt1, dt2);
                string dateString = dr["RefNo"].ToString();
                lblRecDate.Text = dateString;
            }
            else
            {
                dtRec = rec.GetTransactionByRefNo(dr["RefNo"].ToString(), Convert.ToInt32(cboStores.EditValue), dr["Date"].ToString());
                lblRecDate.Text = Convert.ToDateTime(dr["Date"]).ToString("MM dd,yyyy");
            }
            gridReceives.DataSource = dtRec;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void PopulateDocuments(DataTable dtRec)
        {
            lstTree.DataSource = dtRec;
            lstTree.ExpandAll();
            // show the last entry
            //tree.SetFocusedNode(tree.Nodes(i))
            //lstTree.SetFocusedNode(lstTree.Nodes[0].FirstNode);
        }

        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue == null) return;

            ReceiveDoc rec = new ReceiveDoc();

            DataTable dtRec = rec.GetDistinctRecDocments(Convert.ToInt32(cboStores.EditValue));
            PopulateDocuments(dtRec);
            CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx
                                                      {
                                                          CustomFormat = "MM/dd/yyyy",
                                                          Value = DateTime.Now
                                                      };
            DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
            DateTime dt1 = new DateTime(yr, 11, 1);
            DateTime dt2 = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day);
            dtRec = rec.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dt1, dt2);
            gridReceives.DataSource = dtRec;
        }

        private void cboSupplier_EditValueChanged(object sender, EventArgs e)
        {
            if (cboSupplier.EditValue == null) return;
            ReceiveDoc rec = new ReceiveDoc();
            DataTable dtRec = rec.GetTransactionBySupplierId(Convert.ToInt32(cboStores.EditValue), Convert.ToInt32(cboSupplier.EditValue));
            gridReceives.DataSource = dtRec;
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            ReceiveDoc rec = new ReceiveDoc();
            dtFrom.CustomFormat = "MM/dd/yyyy";
            dtTo.CustomFormat = "MM/dd/yyyy";

            DateTime dteFrom = ConvertDate.DateConverter(dtFrom.Text);
            DateTime dteTo = ConvertDate.DateConverter(dtTo.Text);

            DataTable dtRec = dteFrom < dteTo ? rec.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dteFrom, dteTo) : rec.GetAllTransaction(Convert.ToInt32(cboStores.EditValue));
            gridReceives.DataSource = dtRec;
            dtFrom.CustomFormat = "MMMM dd, yyyy";
            dtTo.CustomFormat = "MMMM dd, yyyy";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();

            if (dr == null) return;

            int tranId = Convert.ToInt32(dr["ID"]);
            ReceiveDoc rec = new ReceiveDoc();
            IssueDoc iss = new IssueDoc();
            Disposal dis =new Disposal();

            rec.LoadByPrimaryKey(tranId);
            _dtDate.Value = DateTime.Now;
            _dtDate.CustomFormat = "MM/dd/yyyy";
         
            
             iss.GetIssueByBatchAndId(rec.ItemID, rec.BatchNo, rec.ID);
             if (iss.RowCount == 0)
             {
                 if ((iss.RowCount == 0) || (iss.RecievDocID == null || iss.RecievDocID != tranId))
                 {
                     EditReceive edRec = new EditReceive(tranId, true);
                     MainWindow.ShowForms(edRec);
                 }
                 
             }
             else
             {
                 XtraMessageBox.Show("Unable to edit, This Transaction has been processed. Try Loss and Adjustment.", "Unable to Edit", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                 return;
             }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();

            if (dr == null) return;

            int tranId = Convert.ToInt32(dr["ID"]);
            ReceiveDoc rec = new ReceiveDoc();
            rec.LoadByPrimaryKey(tranId);
            IssueDoc iss = new IssueDoc();
            iss.GetIssueByBatchAndId(rec.ItemID, rec.BatchNo, rec.ID);
            _dtDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = ConvertDate.DateConverter(_dtDate.Text);
            if ((rec.Date.Year != dtCurrent.Year && rec.Date.Month < 11) || (iss.RowCount != 0))
            {
                XtraMessageBox.Show("Unable to Delete, This Transaction has been processed. Try Loss and Adjustment.", "Unable to Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                
                if (XtraMessageBox.Show("Are You Sure, You want to delete this Transaction? You will not be able to restore this data.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                       var recd = new ReceiveDocDeleted();
                        recd.AddNew();
                        recd.ID = rec.ID;
                        recd.BatchNo = rec.BatchNo;
                        recd.ItemID = rec.ItemID;
                        recd.SupplierID = rec.SupplierID;
                        recd.Quantity = rec.Quantity;
                        recd.Date = rec.Date;
                        recd.ExpDate = rec.ExpDate;
                        recd.Out = rec.Out;
                        recd.ReceivedStatus = rec.ReceivedStatus;
                        recd.ReceivedBy = rec.ReceivedBy;
                        recd.Remark = rec.Remark;
                        recd.StoreID = rec.StoreID;
                        recd.LocalBatchNo = rec.LocalBatchNo;
                        recd.RefNo = rec.RefNo;
                        recd.Cost = rec.Cost;
                        recd.IsApproved = rec.IsApproved;
                        recd.ManufacturerId = rec.ManufacturerId;
                        recd.QuantityLeft = rec.QuantityLeft;
                        recd.NoOfPack = rec.NoOfPack;
                        recd.QtyPerPack = rec.QtyPerPack;
                        recd.BoxLevel = rec.BoxLevel;
                        recd.EurDate = rec.EurDate;
                        recd.SubProgramID = rec.SubProgramID;
                        recd.Save();


                    rec.MarkAsDeleted();
                    rec.Save();

                    _dtDate.Value = DateTime.Now;
                    _dtDate.CustomFormat = "MM/dd/yyyy";
                    dtCurrent = ConvertDate.DateConverter(_dtDate.Text);
                    int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
                    DateTime dt1 = new DateTime(yr, 11, 1);
                    DateTime dt2 = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day);
                    DataTable dtRec = rec.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dt1, dt2);
                    gridReceives.DataSource = dtRec;
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string fileName = MainWindow.GetNewFileName("xls");
            gridReceives.ExportToXls(fileName);
            MainWindow.OpenInExcel(fileName);
          
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();
            DevExpress.XtraPrinting.PrintableComponentLink pcl = new DevExpress.XtraPrinting.PrintableComponentLink(ps);

            pcl.CreateReportHeaderArea += this.pcl_CreateReportHeaderArea;

            pcl.Component = gridReceives;
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
           // original header
           // string header = info.HospitalName + " Receive Activity Log " + dtCurrent.ToString("MM dd,yyyy");
            // header with reference number
            string refNumber = lstTree.FocusedNode.GetDisplayText("RefNo");
            string header = info.HospitalName + " Receive Activity Log \n" + dtCurrent.ToString("MM dd,yyyy") + "   RefNo " + refNumber;

            TextBrick brick = e.Graph.DrawString(header, Color.Navy, new RectangleF(0, 0, 500, 40),
                                                 DevExpress.XtraPrinting.BorderSide.None);
            brick.Font = new Font("Arial", 16);
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }

        private void lstTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //CALENDAR:

            CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx
                                                      {
                                                          CustomFormat = "MM/dd/yyyy",
                                                          Value = DateTime.Now
                                                      };
            DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);

            DataRowView dr = (DataRowView)lstTree.GetDataRecordByNode(lstTree.FocusedNode);

            if (dr == null) return;
            
            ReceiveDoc rec = new ReceiveDoc();
            DataTable dtRec;
            if (dr["ParentID"] == DBNull.Value)
            {
                int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
                DateTime dt1 = new DateTime(Convert.ToInt32(dr["ID"]) - 1, 11, 1);
                DateTime dt2 = new DateTime(Convert.ToInt32(dr["ID"]), 11, 1);
                dtRec = rec.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dt1, dt2);
                string dateString = dr["RefNo"].ToString();
                lblRecDate.Text = dateString;
            }
            else
            {
                dtRec = rec.GetTransactionByRefNo(dr["RefNo"].ToString(), Convert.ToInt32(cboStores.EditValue), dr["Date"].ToString());
                lblRecDate.Text = Convert.ToDateTime(dr["Date"]).ToString("MM dd,yyyy");
            }
            gridReceives.DataSource = dtRec;
        }
     

        

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();

            if (dr == null) return;

            int tranId = Convert.ToInt32(dr["ID"]);
            ReceiveDoc rec = new ReceiveDoc();
            rec.LoadByPrimaryKey(tranId);

            _dtDate.Value = DateTime.Now;
            _dtDate.CustomFormat = "MM/dd/yyyy";
            IssueDoc iss = new IssueDoc();
            iss.GetIssueByBatchAndId(rec.ItemID, rec.BatchNo, rec.ID);
            DateTime dtCurrent = ConvertDate.DateConverter(_dtDate.Text);

            if ((rec.Date.Year != dtCurrent.Year && rec.Date.Month < 11) || (iss.RowCount != 0))
            {
                //XtraMessageBox.Show("Unable to edit, This Transaction has been processed. Try Loss and Adjustment.", "Unable to Edit", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                EditReceive edRec = new EditReceive(tranId, true);
                MainWindow.ShowForms(edRec);
            }
            else
            {
                EditReceive edRec = new EditReceive(tranId, false);
                MainWindow.ShowForms(edRec);
            }
        }
    }
}