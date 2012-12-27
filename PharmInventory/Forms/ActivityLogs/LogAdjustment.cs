using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using CalendarLib;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraTreeList;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.ActivityLogs
{
    /// <summary>
    /// Shows the Loss/Adjustment log
    /// </summary>
    public partial class LogAdjustment : XtraForm
    {
        public LogAdjustment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Prepare all lookups
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageItems_Load(object sender, EventArgs e)
        {
            var stor = new Stores();
            stor.GetActiveStores();
            cboStores.Properties.DataSource = stor.DefaultView;
            cboStores.ItemIndex = 0;

            var rec = new DisposalReasons();
            var dtDis = rec.GetAvailableReasons();
            cboReasons.Properties.DataSource = dtDis;
            cboReasons.ItemIndex = 0;

            //Stores stor = new Stores();

            //cboStores.Properties.DataSource = stor.GetActiveStores();
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

                Disposal disp = new Disposal();
                DataTable dtRec;
                if (dr["ParentID"] == DBNull.Value)
                {
                    int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
                    DateTime dt1 = new DateTime(Convert.ToInt32(dr["ID"]) - 1, 11, 1);
                    DateTime dt2 = new DateTime(Convert.ToInt32(dr["ID"]), 11, 1);
                    dtRec = disp.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dt1, dt2);
                    string dateString = dr["RefNo"].ToString();
                    lblAdjDate.Text = dateString;
                }
                else
                {
                    dtRec = disp.GetDocumentByRefNo(dr["RefNo"].ToString(), Convert.ToInt32(cboStores.EditValue), dr["Date"].ToString());
                    lblAdjDate.Text = Convert.ToDateTime(dr["Date"]).ToString("MM dd,yyyy");
                }
                gridAdjustments.DataSource = dtRec;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            GetItemsByStore();
        }

        private void GetItemsByStore()
        {
            if (cboStores.EditValue == null) return;

            //CALENDAR:
            Disposal adj = new Disposal();
            DataTable dtRec = adj.GetDistinctAdjustmentDocments(Convert.ToInt32(cboStores.EditValue));
            /*PopulateDocument(dtRec);*/
            lstTree.DataSource = dtRec;
            CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx
                                                      {
                                                          CustomFormat = "MM/dd/yyyy",
                                                          Value = DateTime.Now
                                                      };
            DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
            DateTime dt1 = new DateTime(yr, 11, 1);
            DateTime dt2 = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day);
            dtRec = adj.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dt1, dt2);
            lblAdjDate.Text = @"Current Year";
            gridAdjustments.DataSource = dtRec;
        }

        private void cboReasons_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null && cboReasons.EditValue != null)
            {
                Disposal adj = new Disposal();
                DataTable dtRec = adj.GetTransactionByReason(Convert.ToInt32(cboStores.EditValue),Convert.ToInt32(cboReasons.EditValue));
                gridAdjustments.DataSource = dtRec;                
            }
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            //CALENDAR:
            Disposal adj = new Disposal();
            DataTable dtRec;
            dtFrom.CustomFormat = "MM/dd/yyyy";
            dtTo.CustomFormat = "MM/dd/yyyy";
            DateTime dteFrom = ConvertDate.DateConverter(dtFrom.Text);
            DateTime dteTo = ConvertDate.DateConverter(dtTo.Text);
            
            dtRec = dteFrom < dteTo ? adj.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dteFrom,dteTo) : adj.GetAllTransaction(Convert.ToInt32(cboStores.EditValue));
            gridAdjustments.DataSource = dtRec;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = @"Microsoft Excel | *.xls";

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                gridAdjustments.MainView.ExportToXls(saveDlg.FileName);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();
            DevExpress.XtraPrinting.PrintableComponentLink pcl = new DevExpress.XtraPrinting.PrintableComponentLink(ps);

            pcl.CreateReportHeaderArea += PclCreateReportHeaderArea;

            pcl.Component = gridAdjustments;
            pcl.Landscape = true;

            pcl.CreateDocument();
            ps.PreviewFormEx.ShowDialog();
        }

        private static void PclCreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx
                                                      {
                                                          Value = DateTime.Now,
                                                          CustomFormat = "MM/dd/yyyy"
                                                      };
            DateTime dtCurrent = Convert.ToDateTime(dtDate.Text);
            //Old header
            string header = info.HospitalName + " Loss/Adjustment Activity Log " + dtCurrent.ToString("MM dd,yyyy");
            //string refNumber = lstTree.FocusedNode.GetDisplayText("RefNo");
            //header with reference number
            //string header = info.HospitalName + " Loss/Adjustment Activity Log" + refNumber;
            TextBrick brick = e.Graph.DrawString(header, Color.Navy, new RectangleF(0, 0, 500, 40),
                                                 DevExpress.XtraPrinting.BorderSide.None);
            brick.Font = new Font("Arial", 16);
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }

        private void lstTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //CALENDAR:
            DateTime dtCurrent;
            DataRowView dr;
            DateTimePickerEx dtDate;
            GetSelectedNode(out dtCurrent, out dr, out dtDate);
        }

        public void GetSelectedNode(out DateTime dtCurrent, out DataRowView dr, out DateTimePickerEx dtDate)
        {
            dtDate = new DateTimePickerEx
                         {
                             CustomFormat = "MM/dd/yyyy",
                             Value = DateTime.Now
                         };
            dtCurrent = ConvertDate.DateConverter(dtDate.Text);

            dr = (DataRowView) lstTree.GetDataRecordByNode(lstTree.FocusedNode);

            if (dr == null) return;

            Disposal disp = new Disposal();
            DataTable dtRec;
            if (dr["ParentID"] == DBNull.Value)
            {
                int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
                DateTime dt1 = new DateTime(Convert.ToInt32(dr["ID"]) - 1, 11, 1);
                DateTime dt2 = new DateTime(Convert.ToInt32(dr["ID"]), 11, 1);
                dtRec = disp.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dt1, dt2);
                string dateString = dr["RefNo"].ToString();
                lblAdjDate.Text = dateString;
            }
            else
            {
                dtRec = disp.GetDocumentByRefNo(dr["RefNo"].ToString(), Convert.ToInt32(cboStores.EditValue),
                                                dr["Date"].ToString());
                lblAdjDate.Text = Convert.ToDateTime(dr["Date"]).ToString("MM dd,yyyy");
            }
            gridAdjustments.DataSource = dtRec;
        }

        /// <summary>
        /// Delete a row of adjustmen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dataRow = gridView1.GetFocusedDataRow();
            if (dataRow == null) return;

            //get the primary key of the row
            int ID = Convert.ToInt32(dataRow["ID"]);

            Disposal disposal = new Disposal();
            ReceiveDoc receiveDoc = new ReceiveDoc();

            //Retrieve the adjustment with the value of the primary key(id)
            disposal.LoadByPrimaryKey(ID);


            int itemId = disposal.ItemID;
            int storeID = disposal.StoreId;
            int recieveID = disposal.RecID;

            receiveDoc.LoadByPrimaryKey(recieveID);
            if (XtraMessageBox.Show("Are You Sure, You want to delete this?", "Confirmation", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //check for losss
                if (disposal.Losses) //it was loss
                {
                    receiveDoc.Quantity = receiveDoc.Quantity + disposal.Quantity;
                    receiveDoc.QuantityLeft = receiveDoc.QuantityLeft + disposal.Quantity;
                    if (receiveDoc.Out)
                        receiveDoc.Out = false;
                    disposal.Quantity = 0;
                }
                else // it was adjustment
                {
                    receiveDoc.Quantity = receiveDoc.Quantity - disposal.Quantity;
                    receiveDoc.QuantityLeft = receiveDoc.QuantityLeft - disposal.Quantity;
                    if (receiveDoc.Quantity == 0)
                        receiveDoc.Out = true;
                    disposal.Quantity = 0;
                }

                // proceed deletion and make the necessary changes on the database tables.
                DisposalDelete ddel;
                AddDeletedDisposal(disposal, out ddel);

                receiveDoc.Save();
                disposal.MarkAsDeleted();
                disposal.Save();

                //Repopulate the grid
                DataTable dtRec;
                dtFrom.CustomFormat = "MM/dd/yyyy";
                dtTo.CustomFormat = "MM/dd/yyyy";
                DateTime from = ConvertDate.DateConverter(dtFrom.Text);
                DateTime to = ConvertDate.DateConverter(dtTo.Text);
                dtRec = disposal.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), from, to);
                gridAdjustments.DataSource = dtRec;
            }
        }

        private static void AddDeletedDisposal(Disposal disposal, out DisposalDelete ddel)
        {
            ddel = new DisposalDelete();
            ddel.AddNew();
            ddel.ID = disposal.ID;
            ddel.ItemID = disposal.ItemID;
            ddel.StoreId = disposal.StoreId;
            ddel.ReasonId = disposal.ReasonId;
            ddel.Quantity = disposal.Quantity;
            ddel.Date = disposal.Date;
            ddel.ApprovedBy = disposal.ApprovedBy;
            ddel.Losses = disposal.Losses;
            ddel.BatchNo = disposal.BatchNo;
            ddel.Remark = disposal.Remark;
            ddel.Cost = disposal.Cost;
            ddel.RefNo = disposal.RefNo;
            ddel.EurDate = disposal.EurDate;
            ddel.RecID = disposal.RecID;
            ddel.Save();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {  
            DataRowView dr = (DataRowView)lstTree.GetDataRecordByNode(lstTree.FocusedNode);
            if (dr == null) return;
            var edtloss = new EditLossAndAdjustment((string)dr["RefNo"]);
            edtloss.ShowDialog();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataRowView dr = (DataRowView)lstTree.GetDataRecordByNode(lstTree.FocusedNode);
            if (dr == null) return;
            if (XtraMessageBox.Show("Are You Sure, You want to delete this?", "Confirmation", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
               var dis = new Disposal();
               DataTable dtbl =  dis.GetTransactionByRefNo((string) dr["RefNo"]);
                foreach (DataRow dataRow in dtbl.Rows)
                {
                    AddlossDeleted(dataRow);
                    dataRow.Delete();
                }
                dis.MarkAsDeleted();
                dis.Save();
                XtraMessageBox.Show("Item successfully deleted.");
            }
        }

        private static void AddlossDeleted(DataRow dataRow)
        {
            var dispdelete = new DisposalDelete();
            dispdelete.AddNew();
            dispdelete.ID = (int) dataRow["ID"];
            dispdelete.ItemID = (int) dataRow["ItemID"];
            dispdelete.StoreId = (int) dataRow["StoreID"];
            dispdelete.ReasonId = (int) dataRow["ReasonID"];
            dispdelete.Quantity = (long) dataRow["Quantity"];
            dispdelete.Date = (DateTime) dataRow["Date"];
            dispdelete.ApprovedBy = (string) dataRow["ApprovedBy"];
            dispdelete.Losses = (bool) dataRow["Losses"];
            dispdelete.BatchNo = (string) dataRow["BatchNo"];
            dispdelete.Remark = (string) dataRow["Remark"];
            dispdelete.Cost = (double) dataRow["Cost"];
            dispdelete.RefNo = (string) dataRow["RefNo"];
            dispdelete.EurDate = (DateTime) dataRow["EurDate"];
            dispdelete.RecID = (int) dataRow["RecID"];
            dispdelete.Save();
        }

        private void lstTree_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var treeList = sender as TreeList;
            if (treeList != null && treeList.FocusedNode.Id != 0)
            {
                e.Cancel = true;
            }
        }
    }
}