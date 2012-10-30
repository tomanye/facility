using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLL;
using System.Linq;
using DevExpress.XtraEditors;
using PharmInventory.ViewModel;
using StockoutIndexBuilder.DAL;

namespace PharmInventory.Forms.Transactions
{
    public partial class StockOutIndicesBuilder : DevExpress.XtraEditors.XtraForm
    {
        private readonly StockoutRepository _repository = new StockoutRepository();
        private readonly  StoreRepository _storerepository =new StoreRepository();
        List<ItemViewModel> _dataSource = new List<ItemViewModel>();
        public StockOutIndicesBuilder()
        {
            InitializeComponent();
            this.TopLevel = false;
            LoadAllItems();
        }

        void LoadAllItems()
        {
            var allItems = _repository.AllItems().Where(m => m.ID < 1000);
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
                if (lookUpEdit1.EditValue != null)
                    StockoutIndexBuilder.Builder.BuildIndex(((ItemViewModel)item).ItemID, (int)lookUpEdit1.EditValue);
                else
                    StockoutIndexBuilder.Builder.BuildIndex(((ItemViewModel) item).ItemID);
               
                item.Indexed = true;
                itemsBindingSource.DataSource = _dataSource;
                var newValue = 100.0 / _dataSource.Count;
                percentage += newValue;
                backgroundIndexer.ReportProgress(Convert.ToInt32(percentage));
            }
            //lblStatus.Text = String.Format("Completed index for {0} items successfully.", _dataSource.Count);            
           
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
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

        //private void StockOutIndicesBuilder_Load(object sender, EventArgs e)
        //{
        //    Items items = new Items();
        //    DataTable dtItem = items.GetAllItems();
        //    PopulateItemList(dtItem);
        //}

        private void PopulateItemList(DataTable dtItem)
        {
            gridControl1.DataSource = dtItem;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
           // stockoutindexergridView.ActiveFilterString = string.Format("StoreID={0}", Convert.ToInt32(lookUpEdit1.EditValue));
        }
    }
}