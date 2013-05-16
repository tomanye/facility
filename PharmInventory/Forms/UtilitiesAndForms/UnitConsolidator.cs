using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using StockoutIndexBuilder.DAL;
using StockoutIndexBuilder.Models;

namespace PharmInventory.Forms.UtilitiesAndForms
{
    public partial class UnitConsolidator : DevExpress.XtraEditors.XtraForm
    {
        UnitsRepository _unitsRepository =new UnitsRepository();
        public UnitConsolidator()
        {
            InitializeComponent();
        }

        private void UnitCompare_Load(object sender, EventArgs e)
        {
            var units = _unitsRepository.GetAll();
            unitBindingSource.DataSource = units;
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            var selectedunit = gridView1.GetFocusedRow();
            _unitsRepository.Update((Unit) selectedunit);
        }
    }
}