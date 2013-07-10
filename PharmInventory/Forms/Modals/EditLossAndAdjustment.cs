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
    public partial class EditLossAndAdjustment : DevExpress.XtraEditors.XtraForm
    {
        readonly string _refno;
        public EditLossAndAdjustment()
        {
            InitializeComponent();    
        }
        public EditLossAndAdjustment(string refno)
        {
            InitializeComponent();
            _refno = refno;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var dis =new Disposal();
            DataTable dtbl=dis.GetTransactionByRefNo(_refno);
                if (dis.RowCount > 0)
                {
                    foreach (DataRow datarow in dtbl.Rows)
                    {
                        datarow["RefNo"] = refNotextEdit.Text;
                        datarow["EurDate"] = Convert.ToDateTime(dateEdit1.EditValue);
                    }
                    dis.Save();
                }

                else
                {
                    XtraMessageBox.Show("There is no refrence no to edit");
                    return;
                }
                this.Close();
         }
        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditLossAndAdjustment_Load(object sender, EventArgs e)
        {
            var dis = new Disposal();
            if(_refno!=null)
            {
                dis.GetTransactionByRefNo(_refno);
                refNotextEdit.Text = dis.RefNo;
                if (dateEdit1 != null) dateEdit1.EditValue = dis.EurDate;
            }
        }

      
    }
}