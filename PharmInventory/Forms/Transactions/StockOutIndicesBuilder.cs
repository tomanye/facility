using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLL;
using System.Linq;
using PharmInventory.ViewModel;
using StockoutIndexBuilder.DAL;

namespace PharmInventory.Forms.Transactions
{
    public partial class StockOutIndicesBuilder : DevExpress.XtraEditors.XtraForm
    {
        private readonly StockoutRepository _repository = new StockoutRepository();
        List<ItemViewModel> _dataSource = new List<ItemViewModel>();
        public StockOutIndicesBuilder()
        {
            InitializeComponent();
            this.TopLevel = false;
            LoadAllItems();
        }

        void LoadAllItems()
        {
            var allItems = _repository.AllItems().Where(m => m.ID < 500);
            itemsBindingSource.DataSource = ItemViewModelCollection.Create(allItems);
        }

        private void backgroundIndexer_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _repository.DeleteAll();
            _dataSource = itemsBindingSource.DataSource as List<ItemViewModel>;
            double percentage = 0;
            foreach (var item in _dataSource)
            {
                StockoutIndexBuilder.Builder.BuildIndex(((ItemViewModel)item).ItemID);
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
            MessageBox.Show(String.Format("Indexing Completed for {0} items.", _dataSource.Count));
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
    }
}