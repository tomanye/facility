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
                dateEdit2.EditValue = rec.Date;
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
                    datarow["EurDate"] = Convert.ToDateTime(dateEdit2.EditValue);
                }
                rec.Save();
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