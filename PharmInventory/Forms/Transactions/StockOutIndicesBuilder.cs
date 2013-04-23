using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using BLL;
using System.Linq;
using DevExpress.XtraEditors;
using PharmInventory.ViewModels;
using StockoutIndexBuilder.DAL;
using StockoutIndexBuilder.Models;

namespace PharmInventory.Forms.Transactions
{
    public partial class StockOutIndicesBuilder : DevExpress.XtraEditors.XtraForm
    {
        private readonly StockoutRepository _repository = new StockoutRepository();
        private readonly  StoreRepository _storerepository =new StoreRepository();
        private readonly  ReceiveDocRepository receiveDocRepository =new ReceiveDocRepository();
        List<ItemViewModel> _dataSource = new List<ItemViewModel>();
         private List<AMCViewModel> _amcdatasource; 

        private readonly GeneralInfoRepository _generalInfoRepository = new GeneralInfoRepository();
        private readonly ReceiveDocRepository _receiveDocRepository = new ReceiveDocRepository();
        private readonly AmcReportRepository _amcReportRepository = new AmcReportRepository();
        public StockOutIndicesBuilder()
        {
            InitializeComponent();
            this.TopLevel = false;
            LoadAllItems();
        }

        void LoadAllItems()
        {
            var allstockouts = _repository.GetAll().LastOrDefault();
            if (allstockouts != null) lbllastindexedtime.Text = allstockouts.LastIndexedTime.ToString();
            var allItems = receiveDocRepository.RecievedItems().Select(m => m.Item).Distinct().ToList();
            itemsBindingSource.DataSource = ItemViewModelCollection.Create(allItems);
            var allstores = _storerepository.AllStores();
            storebindingSource.DataSource = allstores;
        }

        private void backgroundIndexer_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _repository.DeleteAll();
            _dataSource = itemsBindingSource.DataSource as List<ItemViewModel>;
            double percentage = 0;
            foreach (var item in _dataSource)
            {
                if (lkStore.EditValue != null)
                    StockoutIndexBuilder.Builder.BuildIndex(((ItemViewModel)item).ItemId, (int)lkStore.EditValue);
                  
                else
                   StockoutIndexBuilder.Builder.BuildIndex(((ItemViewModel) item).ItemId);
           
                item.Indexed = true;
                
                itemsBindingSource.DataSource = _dataSource;
                var newValue = 100.0 / _dataSource.Count;
                percentage += newValue;
                backgroundIndexer.ReportProgress(Convert.ToInt32(percentage));
               
            }

            foreach (var item in _dataSource)
            {
                if (lkStore.EditValue != null)
                    StockoutIndexBuilder.Builder.BuildIndex(((ItemViewModel)item).ItemId, (int)lkStore.EditValue);
                else
                    StockoutIndexBuilder.Builder.BuildIndex(((ItemViewModel)item).ItemId);

                item.Indexed = true;

                itemsBindingSource.DataSource = _dataSource;
                var newValue = 100.0 / _dataSource.Count;
                percentage += newValue;
                backgroundIndexer.ReportProgress(Convert.ToInt32(percentage));

            }


            //lblStatus.Text = String.Format("Completed index for {0} items successfully.", _dataSource.Count);            
           
        }


        private void btnBuildIndexer_Click(object sender, System.EventArgs e)
        {
            IndexAllItems();
        }

        private void IndexAllItems()
        {
            backgroundIndexer.RunWorkerAsync();
        }

        private void backgroundIndexer_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressIndex.Value = e.ProgressPercentage;
        }

        private void backgroundIndexer_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            itemsBindingSource.DataSource = null;
            itemsBindingSource.DataSource = _dataSource;
            XtraMessageBox.Show(String.Format("Indexing Completed for {0} items.", _dataSource.Count));
            progressIndex.Value = 0;
        }

        private void btnBuildAmc_Click(object sender, EventArgs e)
        {
            if (lkStore.EditValue == null)
            {
                XtraMessageBox.Show("Please select the store you want to update AMC report.");
            }
            if (lkStore.EditValue != null)
            {
                //amcBackgroundWorker.RunWorkerAsync();
            }
        }

        //private void amcBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        //{
        //    progressIndex.Value = 0;
        //    var storeId = (int)lkStore.EditValue;
        //    amcBackgroundWorker.ReportProgress(5);
        //    var generalinfo = _generalInfoRepository.AllGeneralInfos().First();
        //    amcBackgroundWorker.ReportProgress(10);
        //    var itemsrecieved = _receiveDocRepository.RecievedItems().Where(m => m.StoreID == storeId).Select(m => m.ItemID).Distinct();
        //    amcBackgroundWorker.ReportProgress(20);
        //    _amcdatasource = new List<AMCViewModel>();
        //    double percentage = 20.0;
        //    var receiveDocs = _repository.AllItems().Where(m => itemsrecieved.Contains(m.ID)).ToList();
        //    double increment = 80.0 / Convert.ToDouble(receiveDocs.Count());

        //    foreach (var item in receiveDocs)
        //    {
        //        _amcdatasource.Add(AMCViewModel.Create(item.ID, storeId, generalinfo.AMCRange, DateTime.Today));
        //        percentage += increment;
        //        amcBackgroundWorker.ReportProgress((int)percentage);
        //    }
        //}

        //private void amcBackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        //{
        //   progressIndex.Value = e.ProgressPercentage;
        //}

        //private void amcBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        //{
        //    progressIndex.Value = 0;
        //    XtraMessageBox.Show("AMC report done successfully");
        //    progressIndex.Hide();
        //}


       

    }
}