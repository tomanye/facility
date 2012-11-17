using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmInventory.ViewModels;
using StockoutIndexBuilder.DAL;
using StockoutIndexBuilder.Models;

namespace PharmInventory.Forms.Transactions
{
    public partial class AMCView : DevExpress.XtraEditors.XtraForm
    {
        private readonly StockoutRepository _repository = new StockoutRepository();
        private readonly StoreRepository _storerepository = new StoreRepository();
        private readonly GeneralInfoRepository _generalInfoRepository = new GeneralInfoRepository();
        private readonly ReceiveDocRepository _receiveDocRepository =new ReceiveDocRepository();
        private readonly AmcReportRepository _amcReportRepository =new AmcReportRepository();
        private List<AMCViewModel> _datasource; 
        public AMCView()
        {
            InitializeComponent();
            this.TopLevel = false;
            loadamc();

            
        }

        private void loadamc()
        {
            var allamcs = _amcReportRepository.AllAmcReport();
            var allstores = _storerepository.AllStores();
            storebindingSource.DataSource = allstores;
            amcbindingSource.DataSource = allamcs.Distinct().OrderBy(m=>m.FullItemName);
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var allamcs = _amcReportRepository.AllAmcReport();
            var allstores = _storerepository.AllStores();
            storebindingSource.DataSource = allstores;
            amcbindingSource.DataSource = allamcs.Where(m=>m.StoreID==(int)lookUpEdit1.EditValue);
           // progressBar1.Visible = true;
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var storeId = (int)lookUpEdit1.EditValue;
            backgroundWorker1.ReportProgress(5);
            var generalinfo = _generalInfoRepository.AllGeneralInfos().First();
            backgroundWorker1.ReportProgress(10);
            var itemsrecieved =_receiveDocRepository.RecievedItems().Where(m => m.StoreID == storeId).Select(m => m.ItemID).Distinct();
            backgroundWorker1.ReportProgress(20);
            _datasource = new List<AMCViewModel>();
            double percentage = 20.0;
            var receiveDocs = _repository.AllItems().Where(m => itemsrecieved.Contains(m.ID)).ToList();
            //var enumerable = receiveDocs as List<ReceiveDoc> ?? receiveDocs.ToList();
            double increment = 80.0 / Convert.ToDouble(receiveDocs.Count());
        
           // _amcReportRepository.DeleteAll();

            foreach (var item in receiveDocs)
            {
                _datasource.Add(AMCViewModel.Create(item.ID, storeId, generalinfo.AMCRange, DateTime.Today));
                percentage += increment;
                backgroundWorker1.ReportProgress((int) percentage);
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            
            XtraMessageBox.Show("AMC report done successfully");
            if(lookUpEdit1.EditValue == null)
                loadamc();
            else
            {
                lookUpEdit1_EditValueChanged(null,null);
            }
            progressBar1.Hide();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue != null)
            {
                backgroundWorker1.RunWorkerAsync();
            }

        }

       
    }
}