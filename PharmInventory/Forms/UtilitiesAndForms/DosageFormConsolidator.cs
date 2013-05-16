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
    public partial class DosageFormConsolidator : DevExpress.XtraEditors.XtraForm
    {
        DosageFormRepository _dosageFormRepositiory =new DosageFormRepository();
        public DosageFormConsolidator()
        {
            InitializeComponent();
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            var selecteddosageform = gridView1.GetFocusedRow();
            _dosageFormRepositiory.Update((DosageForm)selecteddosageform);
        }

        private void DosageFormCompare_Load(object sender, EventArgs e)
        {
            var dosageform = _dosageFormRepositiory.GetAll();
            dosageFormBindingSource.DataSource = dosageform;
        }
    }
}