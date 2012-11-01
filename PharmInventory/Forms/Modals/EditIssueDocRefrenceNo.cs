using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;

namespace PharmInventory.Forms.Modals
{
    public partial class EditIssueDocRefrenceNo : DevExpress.XtraEditors.XtraForm
    {
        private readonly string _refno;
        public EditIssueDocRefrenceNo()
        {
            InitializeComponent();
        }
        public EditIssueDocRefrenceNo(string refno)
        {
            InitializeComponent();
            _refno = refno;
        }

        private void EditIssueDocRefrenceNo_Load(object sender, EventArgs e)
        {
            if(_refno!=null)
            {
                var iss = new IssueDoc();
                iss.GetTransactionByRefNo(_refno);
                refnotextEdit.Text = iss.RefNo;
                dateEdit3.EditValue = iss.EurDate;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var isd = new IssueDoc();
            DataTable dtbl = isd.GetTransactionByRefNo(_refno);
            if (isd.RowCount > 0)
            {
                foreach (DataRow datarow in dtbl.Rows)
                {
                    datarow["RefNo"] = refnotextEdit.Text;
                    datarow["EurDate"] = Convert.ToDateTime(dateEdit3.EditValue);
                }
                isd.Save();
            }

            else
            {
                XtraMessageBox.Show("There is no refrence no to edit");
                return;
            }
            this.Close();
        }
    }
}