using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using PharmInventory.HelperClasses;

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
            dtIssueDate.Value = DateTime.Now;
            dtIssueDate.IsGregorianCurrentCalendar = true;
            if(_refno!=null)
            {
                var iss = new IssueDoc();
                iss.GetTransactionByRefNo(_refno);
                refnotextEdit.Text = iss.RefNo;
                dtIssueDate.Value = iss.Date;
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
                    DateTime xx = dtIssueDate.Value;
                    dtIssueDate.CustomFormat = "MM/dd/yyyy";
                    DateTime dtRec = new DateTime();
                    datarow["Date"] = ConvertDate.DateConverter(dtIssueDate.Text);
                    dtIssueDate.IsGregorianCurrentCalendar = true;

                    datarow["EurDate"] = dtIssueDate.Value;
                    dtIssueDate.IsGregorianCurrentCalendar = false;
                }
                isd.Save();
                Close();
                XtraMessageBox.Show("Refrence No and Date is successfully updated", "Success");
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