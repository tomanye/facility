using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using StockoutIndexBuilder.DAL;
using StockoutIndexBuilder.Models;

namespace PharmInventory.Forms.UtilitiesAndForms
{
    public partial class ProductConsolidator : DevExpress.XtraEditors.XtraForm
    {
        ProductRepository _productRepository =new ProductRepository();
        StockoutEntities context = new StockoutEntities();
        public ProductConsolidator()
        {
            InitializeComponent();
        }

        private void ProductCompare_Load(object sender, EventArgs e)
        {
            var products = _productRepository.GetAll();
            productBindingSource.DataSource = products;

        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            var selectedproduct = gridView1.GetFocusedRow();
            _productRepository.Update((Product) selectedproduct);
        }
    }
}