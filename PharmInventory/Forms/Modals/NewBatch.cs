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
    public partial class NewBatch : DevExpress.XtraEditors.XtraForm
    {
        private readonly int _itemid;
        private readonly string _itemname;
        private readonly int _unitid;
        private readonly int _storeid;
        private readonly DateTime _date;

        public NewBatch()
        {
            InitializeComponent();
        }

        public NewBatch(int itemid, string itemname, int unitid, int storeid ,DateTime _dtcurrent)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            _itemid = itemid;
            _itemname = itemname;
            _unitid = unitid;
            _storeid = storeid;
            _date = _dtcurrent;
        }

        public NewBatch(int itemid, string itemname, int storeid, DateTime _dtcurrent)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            _itemid = itemid;
            _itemname = itemname;
            _storeid = storeid;
            _date = _dtcurrent;
        }
        private void NewBatch_Load(object sender, EventArgs e)
        {
            txtItemName.Text = _itemname;
        }


        private void BtnAddBatchClick(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            var yEnd = new YearEnd();
            switch (VisibilitySetting.HandleUnits)
            {
                case 1:
                    {
                        yEnd.AddNew();
                        yEnd.ItemID = _itemid;
                        yEnd.StoreID = _storeid;
                        yEnd.Year = _date.Year;
                        yEnd.AutomaticallyEntered = true;
                        yEnd.BBalance = 0;
                        yEnd.EBalance = 0;
                        yEnd.Remark = "New Batch";
                        yEnd.Save();
                    }
                    break;
                default:
                    {
                        yEnd.AddNew();
                        yEnd.ItemID = _itemid;
                        yEnd.StoreID = _storeid;
                        yEnd.UnitID = _unitid;
                        yEnd.Year = _date.Year;
                        yEnd.AutomaticallyEntered = true;
                        yEnd.BBalance = 0;
                        yEnd.EBalance = 0;
                        yEnd.Remark = "New Batch";
                        yEnd.Save();
                    }
                    break;
            }
            XtraMessageBox.Show("New Batch successfully added.", "Success");
            Close();
        }

        private void txtPackQty_TextChanged(object sender, EventArgs e)
        {
            if(txtPackQty.Text !=null && VisibilitySetting.HandleUnits!=1)
            {
                txtQtyPerPack.Text = 1.ToString();
            }
        }
    }
}