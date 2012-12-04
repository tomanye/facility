using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLL;
using System.Linq;
using DevExpress.XtraEditors;
using CommCtrl;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout.Utils;
using PharmInventory.Reports;
using PharmInventory.RRFService;
using PharmInventory.HelperClasses;
using EthiopianDate;

namespace PharmInventory.Forms.Reports
{
    public partial class RRFForm : XtraForm
    {
        private int _storeID;
        private int _requestedquantity;
        private int _fromYear;
        private int _toYear;
        private int _fromMonth;
        private int _toMonth;
        private int _programID;
        private DataTable tblRRF;

        public RRFForm()
        {
            InitializeComponent();
        }

        private void RRFForm_Load(object sender, EventArgs e)
        {
            PopulateTheMonthCombos(cboFromMonth);
            PopulateTheMonthCombos(cboToMonth);
            PopulateTheYearCombo(cboFromYear);
            PopulateTheYearCombo(cboToYear);
            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStores.Properties.DataSource = stor.DefaultView;
            ReceivingUnits ru = new ReceivingUnits();
            PopulateRRFs();
            
            WindowVisibility(false);
            EnableDisableStatusCheck();
            Programs prog = new Programs();
            prog.GetAllPrograms();
            cboProgram.Properties.DataSource = prog.DefaultView;
           

            //DataTable dtProg = prog.GetSubPrograms();
            //object[] objProg = { 0, "All Programs", "", 0, "" };
            //dtProg.Rows.Add(objProg);
            //cboProgram.Properties.DataSource = dtProg;
        }

        private void PopulateRRFs()
        {
            RRF rrf = new RRF();
            grdRRF.DataSource = rrf.GetSavedRRFForDisplay();
            grdRRF.RefreshDataSource();
        }

        private void SetEndingMonthAndYear(int startingMonth, int startingYear)
        {
            if(startingMonth<=11)
            {
                cboToMonth.EditValue = startingMonth + 1;
                cboToYear.EditValue = startingYear;
            }

            else //If the starting month is the 12th month. (The period will be from Nehassie of last year - Meskerem of the next year)
            {
                cboToMonth.EditValue = 1;
                cboToYear.EditValue = startingYear + 1;
            }
        }

        private static int GetStartingMonth(int currentMonth)
        {
            int startingMonth;
            if(currentMonth>2)
            {
                startingMonth = currentMonth - 2;
            }
            else
            {
                startingMonth = 12 - currentMonth - 1;
            }

            return startingMonth;
        }

        private static int GetStartingYear(int currentMonth,int currentYear)
        {
            if(currentMonth<=2)
            {
                return currentYear - 1;
            }
            return currentYear;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void PopulateList()
        {
            _storeID = Convert.ToInt32(cboStores.EditValue);
             Items itm = new Items();
            
            _fromMonth = int.Parse(cboFromMonth.EditValue.ToString());
            _toMonth = int.Parse(cboToMonth.EditValue.ToString());
            _toYear = int.Parse(cboToYear.EditValue.ToString());
            _fromYear = int.Parse(cboFromYear.EditValue.ToString());

            tblRRF = itm.GetRRFReport(_storeID, _fromYear, _fromMonth, _toYear, _toMonth);
            gridItemsChoice.DataSource = tblRRF;
            
            ChooseGridView();
        }

        private void PopulateListByProgram()
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            Region reg = new BLL.Region();
            Zone zon = new Zone();
            Woreda wor = new Woreda();
            _storeID = Convert.ToInt32(cboStores.EditValue);
            _programID = Convert.ToInt32(cboProgram.EditValue);
            Items itm = new Items();

            _fromMonth = int.Parse(cboFromMonth.EditValue.ToString());
            _toMonth = int.Parse(cboToMonth.EditValue.ToString());
            _toYear = int.Parse(cboToYear.EditValue.ToString());
            _fromYear = int.Parse(cboFromYear.EditValue.ToString());

            tblRRF = itm.GetRRFReportByProgram(_storeID,_programID,_fromMonth,_toYear);
            gridItemsChoice.DataSource = tblRRF;

            ChooseGridView();
            //}
        }

        private static void PopulateTheYearCombo(ComboBoxEdit combo)
        {
            int []years=new int[25];
            for(int i=0;i<25;i++)
            {
                years[i] = 2003 + i;
            }
            combo.Properties.Items.AddRange(years);
        }


        private static void PopulateTheMonthCombos(ComboBoxEdit combo)
        {
            int []months=new int[12];
            for(int i=0;i<12;i++)
            {
                months[i] = i + 1;
            }
            combo.Properties.Items.AddRange(months);
        }

        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue == null) return;
            PopulateList();
        }

        private void dt_ValueChanged(object sender, EventArgs e)
        {
            //// TOFIX here,
            //// First day of 2003 is the first day of start of RRF
            //DateTime startDate = EthDate.EthiopianToGregorian("1/1/2003");
            //if (dtFrom.Value.Subtract(startDate).Days < 0)
            //{
            //    dtFrom.CustomFormat = "d/MM/yyyy";
            //    dtFrom.Value = startDate;
            //}
            //cboStores_SelectedValueChanged(null, null);
            //dtFrom.CustomFormat = "MMMM dd, yyyy";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you want to save and print the RRF?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            SaveRRF();
            
            GeneralInfo ginfo = new GeneralInfo();
            ginfo.LoadAll();

            EthiopianDate.EthiopianDate ethioDateFrom = new EthiopianDate.EthiopianDate(_fromYear, _fromMonth,1);
            EthiopianDate.EthiopianDate ethioDateTo = new EthiopianDate.EthiopianDate(_toYear, _toMonth, 30);
            

            RRFReport rrfReport = new RRFReport
                                      {
                                          FacilityName = { Text = ginfo.HospitalName },
                                          Period = { Text = string.Format("{0}, {1} - {2}, {3}",ethioDateFrom.GetMonthName(),ethioDateFrom.Year , ethioDateTo.GetMonthName(),ethioDateTo.Year) }
                                      };
            //rrfReport.Year.Text = dtFrom.Text.Substring(dtFrom.Text.LastIndexOf('/') + 1);
            Items itm = new Items();
            //DataTable dtbl = itm.GetRRFReportInPacks(_storeID,_fromYear,_fromMonth,_toYear,_toMonth); //  gridItemsChoice.DataSource;
            //DataTable tbl = (DataTable)gridItemsChoice.DataSource;
            tblRRF.TableName = "DataTable1";
            DataSet dtset = new DataSet();
            dtset.Tables.Add(tblRRF.Copy());
            rrfReport.DataSource = dtset;
            rrfReport.ShowPreviewDialog();
            //printableComponentLink1.PrintingSystem = new DevExpress.XtraPrinting.PrintingSystem();
            //printableComponentLink1.Component = gridItemsChoice;
            //printableComponentLink1.ShowPreview();
        }

        private void btnAutoPushToPFSA_Click(object sender, EventArgs e)
        {
            //contextMenuStrip1.Show(btnAutoPushToPFSA, 0, 0);
            //btnAutoPushToPFSA.Enabled = false;
            if (XtraMessageBox.Show("Are you sure you want to save and submit the RRF to PFSA?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            //ProgressSubmitVisibility(true);
            int rrf = SaveRRF();
            SendRRF(rrf);
            //bwRRFSubmit.RunWorkerAsync(rrf);
        }

        private int SaveRRF()
        {
            RRF rrf = new RRF();
            if(rrf.RRFExists(_storeID,_fromYear, _fromMonth, _toYear, _toMonth))
            {
                if (XtraMessageBox.Show("RRF Exists on disk, are you sure you want to replace it?", "RRF Save", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return -1;
            }
            int rrfID = rrf.AddNewRRF(_storeID,_fromYear, _fromMonth, _toYear, _toMonth, true);
            BLL.Items itm = new BLL.Items();
            DataTable dtbl1 = ((DataView) gridItemChoiceView.DataSource).Table;
            foreach (DataRow dr in dtbl1.Rows)
            {
                int itemID = Convert.ToInt32(dr["ID"]);
                int requestedqty = Convert.ToInt32(dr["Quantity"]);
                int storeID = int.Parse(cboStores.EditValue.ToString());
                 RRFDetail rrfDetail = new RRFDetail();
                rrfDetail.AddNewRRFDetail(rrfID, storeID, itemID, requestedqty);

            }
            return rrf.ID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rrfID"></param>
        private void SendRRF(int rrfID)
        {
            // Do the webservice magic here.
            GeneralInfo ginfo = new GeneralInfo();
            ginfo.LoadAll();

            chkCalculateInPacks.Checked = false;
            ChooseGridView();

            if (ginfo.IsColumnNull("FacilityID"))
            {
                XtraMessageBox.Show("The Facility ID Was not set, Please correct that and try again.");
                return;
            }
            
            int facilityID = ginfo.FacilityID;
            int startMonth = Convert.ToInt32(cboFromMonth.EditValue);
            int endMonth = Convert.ToInt32(cboToMonth.EditValue); //startMonth + 1;
            int fromYear = Convert.ToInt32(cboFromYear.EditValue);
            int toYear = Convert.ToInt32(cboToYear.EditValue);

            bool check;
            RRFService.ServiceSoapClient sc = new RRFService.ServiceSoapClient();
            try
            {
                check = sc.RRFExists(facilityID, toYear, startMonth, endMonth);
            }
            catch
            {
                XtraMessageBox.Show("There was a network Error, Please connect to the internet and try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (check)
            {
                check = (XtraMessageBox.Show("Another Report has been submitted for the period you specified, Are you sure you would like to overwrite it?", "Confirm Overwritting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes);
            }

            if (!check)
            {
                RRFService.RrfSubmission rsubmission = new RrfSubmission
                                                           {
                                                               StartMonth = startMonth,
                                                               EndMonth = endMonth,
                                                               Year = toYear,
                                                               FacilityId = facilityID,
                                                               FacilityName = ginfo.HospitalName,
                                                               Items = new List<RRFItem>()
                                                           };

                DataTable dtbl = ((DataView)gridItemChoiceView.DataSource).Table;

                foreach (DataRow dr in dtbl.Rows)
                {
                    BLL.Items item = new Items();
                    item.LoadByPrimaryKey(Convert.ToInt32(dr["ID"]));

                    if (!item.MappingID.HasValue)
                    {
                        continue;
                    }

                    RRFService.RRFItem itm = new RRFService.RRFItem()
                                                 {
                                                     ItemID = item.MappingID.Value //  Convert.ToInt32(dr["ID"])
                                                     ,
                                                     BBalance = Convert.ToInt32(dr["BeginingBalance"])
                                                     ,
                                                     EBalance = Convert.ToInt32(dr["SOH"])
                                                     ,
                                                     Consumption = Convert.ToInt32(dr["Issued"])
                                                     ,
                                                     LossAdjustment = Convert.ToInt32(dr["LossAdj"])
                                                     ,
                                                     Max = Convert.ToInt32(dr["Max"])
                                                     ,
                                                     Received = Convert.ToInt32(dr["Received"])
                                                     ,
                                                     Requested = Convert.ToInt32(dr["Quantity"])
                                                 };

                    rsubmission.Items.Add(itm);
                }

                sc = new RRFService.ServiceSoapClient();
                try
                {
                    rsubmission.ReportedBy = "";
                    if (sc.SubmitRRF(rsubmission))
                    {
                        XtraMessageBox.Show("The Request has been submitted to PFSA.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RRF rrf = new RRF();
                        rrf.LoadByPrimaryKey(rrfID);
                        rrf.DateOfSubmission = DateTime.Now;
                        rrf.LastRRFStatus = CheckRRFStatus(rrf.ID);
                        rrf.Save();
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
        }
        
        private void btnCheckStatus_Click(object sender, EventArgs e)
        {
            ProgressCheckingVisibility(true);
            btnCheckStatus.Enabled = false;
            bwRRFStatusCheck.RunWorkerAsync();
        }

        private void ProgressCheckingVisibility(bool visible)
        {
            lcCheckingProgress.Visibility = visible ? LayoutVisibility.Always : LayoutVisibility.Never;
        }

        private void ProgressSubmitVisibility(bool visible)
        {
            lcSendingProgress.Visibility = visible ? LayoutVisibility.Always : LayoutVisibility.Never;
        }

        private static string CheckRRFStatus(int rrfID)
        {
            GeneralInfo ginfo = new GeneralInfo();
            ginfo.LoadAll();

            if (ginfo.IsColumnNull("FacilityID"))
            {
                XtraMessageBox.Show("The Facility ID was not set, Please correct that and try again.");
                return "Unknown";
            }
            
            int facilityID = ginfo.FacilityID;
            RRF rrf = new RRF();
            rrf.LoadByPrimaryKey(rrfID);
            int startMonth = rrf.FromMonth; //Convert.ToInt32(cboFromMonth.EditValue);
            int endMonth = rrf.ToMonth;//Convert.ToInt32(cboToMonth.EditValue);
            //TODO: The Server side RRF reception will also have to handle the From/To Year values.
            int toYear = rrf.ToYear;//Convert.ToInt32(cboToYear.EditValue);
            int fromYear = rrf.FromYear;//Convert.ToInt32(cboFromYear.EditValue);
            
            RRFService.ServiceSoapClient sc = new RRFService.ServiceSoapClient();
            try
            {
                string rrfStatus = sc.GetRRFStatus(facilityID, toYear, startMonth, endMonth);//TODO: The service as well needs to handle the From/To year value
                rrf.LastRRFStatus = rrfStatus;
                rrf.Save();
                return rrfStatus;
            }
            catch
            {
                XtraMessageBox.Show("There was a network Error, Please connect to the internet and try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Unknown";
            }
        }

        private void chkCalculateInPacks_CheckedChanged(object sender, EventArgs e)
        {
            ChooseGridView();
        }

        private void ChooseGridView()
        {
            gridItemsChoice.MainView = chkCalculateInPacks.Checked ? grdViewInPacks : gridItemChoiceView;
        }

        private void cboFromYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFromMonth.EditValue == null || cboFromYear.EditValue == null) return;
            SetEndingMonthAndYear(Convert.ToInt32(cboFromMonth.EditValue), Convert.ToInt32(cboFromYear.EditValue));
            PopulateList();
        }

        private void cboFromMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFromMonth.EditValue == null || cboFromYear.EditValue == null) return;
            SetEndingMonthAndYear(Convert.ToInt32(cboFromMonth.EditValue), Convert.ToInt32(cboFromYear.EditValue));
            PopulateList();
        }

        private void grdRRF_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = grdViewRRFList.GetFocusedDataRow();
            if (dr == null)
                return;
            int rrfID = Convert.ToInt32(dr["ID"]);
            ShowRRFDetailWindow(rrfID);
            WindowVisibility(true);
        }

        private void ShowRRFDetailWindow(int rrfID)
        {
            Cursor = Cursors.WaitCursor;
            RRF rrf = new RRF();
            rrf.LoadByPrimaryKey(rrfID);
            cboFromMonth.EditValue = rrf.FromMonth;
            cboFromYear.EditValue = rrf.FromYear;
            cboToMonth.EditValue = rrf.ToMonth;
            cboToYear.EditValue = rrf.ToYear;
            cboStores.EditValue = rrf.RRFType;
            PopulateList();
            //Handle Edits here (Populate exact values from the database)
            if (!rrf.IsColumnNull("LastRRFStatus"))
            {
                if (rrf.LastRRFStatus == "" || rrf.LastRRFStatus.Contains("not") || rrf.LastRRFStatus.Contains("Not"))
                    btnAutoPushToPFSA.Enabled = true;
                else
                {
                    btnAutoPushToPFSA.Enabled = false;
                }
            }
            else
                btnAutoPushToPFSA.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            WindowVisibility(false);
        }

        private void WindowVisibility(bool rrfDetailVisible)
        {
            if (rrfDetailVisible)
            {
                lcRRFInformation.Visibility = LayoutVisibility.Always;
                lcRRFList.Visibility = LayoutVisibility.Never;
            }
            else
            {
                lcRRFInformation.Visibility = LayoutVisibility.Never;
                lcRRFList.Visibility = LayoutVisibility.Always;
            }

        }

        private void btnNewRRF_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var ethiopianDate = new EthiopianDate.EthiopianDate();
            int currentMonth = ethiopianDate.Month;
            int currentYear = ethiopianDate.Year;
            int startingMonth = GetStartingMonth(currentMonth);
            int startingYear = GetStartingYear(currentMonth, currentYear);
            cboFromMonth.EditValue = startingMonth;
            cboFromYear.EditValue = startingYear;
            SetEndingMonthAndYear(startingMonth, startingYear);
            cboStores.ItemIndex = 0;
           // cboProgram.ItemIndex = 0;
            WindowVisibility(true);
            Cursor = Cursors.Default;

        }

        private void grdRRF_Click(object sender, EventArgs e)
        {
            EnableDisableStatusCheck();
        }

        private void EnableDisableStatusCheck()
        {
            try
            {

                btnCheckStatus.Enabled = grdViewRRFList.GetFocusedDataRow()["LastRRFStatus"].ToString() != "Order Dispatched";
            }
            catch
            {
                btnCheckStatus.Enabled = false;
            }
        }

        private void bwRRFStatusCheck_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int rrfID = int.Parse(grdViewRRFList.GetFocusedDataRow()["ID"].ToString());
            string rrfStatus = CheckRRFStatus(rrfID);
            e.Result = rrfStatus;
        }

        private void bwRRFStatusCheck_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnCheckStatus.Enabled = true;
            ProgressCheckingVisibility(false);

            if (e.Result.ToString() != "")
            {
                XtraMessageBox.Show(e.Result.ToString(), "RRF Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            PopulateRRFs();
        }

        private void bwRRFSubmit_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            
        }

        private void bwRRFSubmit_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //ProgressSubmitVisibility(false);
            //btnAutoPushToPFSA.Enabled = true;
        }

        private void cboProgram_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProgram.EditValue == null) return;
            PopulateListByProgram();
        }


        private void gridItemChoiceView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "gridColumn40")
                if (Convert.ToDecimal(e.Value) <= 0) e.DisplayText = "0";
        }

    }
}