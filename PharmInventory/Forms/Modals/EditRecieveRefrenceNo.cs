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
    public partial class EditRecieveRefrenceNo : DevExpress.XtraEditors.XtraForm
    {
        private readonly string _refno;
        public EditRecieveRefrenceNo()
        {
            InitializeComponent();
        }
        public EditRecieveRefrenceNo(string refno)
        {
            InitializeComponent();
            _refno = refno;
            dtRecDate.Value = DateTime.Now;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditRecieveRefrenceNo_Load(object sender, EventArgs e)
        {
            var rec = new ReceiveDoc();
            if(_refno!=null)
            {
                rec.GetTransactionByRefNo(_refno);
                refnotextEdit.Text = rec.RefNo;
                dtRecDate.Value = rec.Date;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var rec = new ReceiveDoc();
            DataTable dtbl = rec.GetTransactionByRefNo(_refno);
            if (rec.RowCount > 0)
            {
                foreach (DataRow datarow in dtbl.Rows)
                {
                    datarow["RefNo"] = refnotextEdit.Text;
                    DateTime xx = dtRecDate.Value;
                    dtRecDate.CustomFormat = "MM/dd/yyyy";
                    DateTime dtRec = new DateTime();
                    datarow["Date"] = ConvertDate.DateConverter(dtRecDate.Text);
                    dtRecDate.IsGregorianCurrentCalendar = true;

                    datarow["EurDate"] = dtRecDate.Value;
                    dtRecDate.IsGregorianCurrentCalendar = false;
                }
                rec.Save();
                Close();
                XtraMessageBox.Show("Refrence No and Date is successfully updated", "Success");
            }

            else
            {
                XtraMessageBox.Show("There is no refrence to edit");
                return;
            }
            this.Close();
        }
    }
}