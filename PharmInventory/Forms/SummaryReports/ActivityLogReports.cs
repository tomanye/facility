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
        private DataTable dtRec,dtiss;
        private ReceiveDoc rec = new ReceiveDoc();
        private IssueDoc iss = new IssueDoc();
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

            Supplier sp = new Supplier();
            DataTable dtsupp = sp.GetActiveSuppliers();
            DataRow dtrsupp = dtsupp.NewRow();
            dtrsupp["ID"] = "0";
            dtrsupp["CompanyName"] = "All Suppliers";
            dtsupp.Rows.InsertAt(dtrsupp, 0);
            lkSupplier.Properties.DataSource = dtsupp;
           
            dtRec = rec.GetAllReceiveByDateRange(dateFrom, dateTo);
            dtiss  = iss.GetIssuedByDateRange(dateFrom, dateTo);
            gridReceives.DataSource = dtRec;
            gridIssues.DataSource = dtiss;
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
            if ((cboStores.Text == "All Stores") || (cboStores.EditValue== null))
            {
                dtRec = rec.GetAllReceiveByDateRange(dtFrom.Value, dtTo.Value);
                dtiss = iss.GetIssuedByDateRange(dtFrom.Value, dtTo.Value);
            }
            else
            {
                dtRec = rec.GetAllReceiveByStoreDateRange(Convert.ToInt32(cboStores.EditValue), dtFrom.Value, dtTo.Value);
                dtiss = iss.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dtFrom.Value, dtTo.Value);
            }
                
            gridReceives.DataSource = dtRec;
            gridIssues.DataSource = dtiss;
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            RefreshFilter();
        }

        private void lkSupplier_EditValueChanged(object sender, EventArgs e)
        {
            if (lkSupplier.Text != "All Suppliers")
                grdViewReceive.ActiveFilterString = string.Format("[CompanyName]='{0}'", lkSupplier.Text);
            else
                grdViewReceive.ActiveFilterString = "";
        }
    }
}
