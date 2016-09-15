using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace PharmInventory.Forms.SummaryReports
{
    public partial class ActivityLogReports : Form
    {
        private DataTable dtRec;
        private ReceiveDoc rec = new ReceiveDoc();
        public ActivityLogReports()
        {
            InitializeComponent();
        }

        private void ActivityLogReports_Load(object sender, EventArgs e)
        {
            Stores stor = new Stores();
            DataTable dtStor = stor.GetActiveStores();
            DataRow dtStorRow = dtStor.NewRow();
            dtStorRow["ID"] = "0";
            dtStorRow["StoreName"] = "All Stores";
            dtStor.Rows.InsertAt(dtStorRow, 0);

            cboStores.Properties.DataSource = dtStor;

            DateTime dateFrom = dtFrom.Value;
            DateTime dateTo = dtTo.Value;

           
            dtRec = rec.GetAllReceiveByDateRange(dateFrom, dateTo);
            gridReceives.DataSource = dtRec;
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            RefreshFilter();
        }

        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            RefreshFilter();
        }
        private void RefreshFilter()
        {
            if (cboStores.Text == "All Stores")
            {
                dtRec = rec.GetAllReceiveByDateRange(dtFrom.Value, dtTo.Value);
            }
            else
                dtRec = rec.GetAllReceiveByStoreDateRange(Convert.ToInt32(cboStores.EditValue), dtFrom.Value, dtTo.Value);
            gridReceives.DataSource = dtRec;
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            RefreshFilter();
        }
    }
}
