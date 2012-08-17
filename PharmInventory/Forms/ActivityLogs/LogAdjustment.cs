using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
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
            DisposalReasons rec = new DisposalReasons();
            DataTable dtDis = rec.GetAvailableReasons();
            cboReasons.Properties.DataSource = dtDis;
            cboReasons.ItemIndex = 0;

            Stores stor = new Stores();

            cboStores.Properties.DataSource = stor.GetActiveStores();
        }

        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue == null) return;

            //CALENDAR:
            Disposal adj = new Disposal();
            DataTable dtRec = adj.GetDistinctAdjustmentDocments(Convert.ToInt32(cboStores.EditValue));
            /*PopulateDocument(dtRec);*/ lstTree.DataSource = dtRec;
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
            string header = info.HospitalName + " Loss/Adjustment Activity Log " + dtCurrent.ToString("MM dd,yyyy");

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
    }
}