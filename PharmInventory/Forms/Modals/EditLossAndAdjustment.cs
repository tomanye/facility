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
            dtLossDate.Value = DateTime.Now;
            dtLossDate.Value = DateTime.Now;

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
                        DateTime xx = dtLossDate.Value;
                        dtLossDate.CustomFormat = "MM/dd/yyyy";
                        DateTime dtRec = new DateTime();
                        datarow["Date"] = ConvertDate.DateConverter(dtLossDate.Text);
                        dtLossDate.IsGregorianCurrentCalendar = true;

                        datarow["EurDate"] = dtLossDate.Value;
                        dtLossDate.IsGregorianCurrentCalendar = false;
                    }
                    dis.Save();
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
                dtLossDate.Value = dis.Date;
            }
        }

      
    }
}