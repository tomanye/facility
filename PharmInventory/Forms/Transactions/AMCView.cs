using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmInventory.ViewModels;
using StockoutIndexBuilder.DAL;

namespace PharmInventory.Forms.Transactions
{
    public partial class AMCView : DevExpress.XtraEditors.XtraForm
    {
        private readonly StockoutRepository _repository = new StockoutRepository();
        private readonly StoreRepository _storerepository = new StoreRepository();
        private readonly GeneralInfoRepository _generalInfoRepository = new GeneralInfoRepository();
        private List<AMCViewModel> _datasource; 
        public AMCView()
        {
            InitializeComponent();
            this.TopLevel = false;
            var allstores = _storerepository.AllStores();
            storebindingSource.DataSource = allstores;
        }

        private void LoadAllItems(int storeId)
        {
            var generalinfo = _generalInfoRepository.AllGeneralInfos().First();
            var allItems = _repository.AllItems();
            var viewModels = new List<AMCViewModel>();
            foreach (var item in allItems)
            {
                viewModels.Add(AMCViewModel.Create(item.ID, storeId, generalinfo.AMCRange, DateTime.Today));
            }
            amcbindingSource.DataSource = viewModels;

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue != null)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var storeId = (int)lookUpEdit1.EditValue;
            backgroundWorker1.ReportProgress(5);
            var generalinfo = _generalInfoRepository.AllGeneralInfos().First();
            backgroundWorker1.ReportProgress(10);
            var allItems = _repository.AllItems();
            backgroundWorker1.ReportProgress(20);
            _datasource = new List<AMCViewModel>();
            double percentage = 20.0;
            double increment = 80.0/Convert.ToDouble(allItems.Count);
            foreach (var item in allItems)
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
            amcbindingSource.DataSource = _datasource;
            XtraMessageBox.Show("AMC done successfully");
        }
    }
}