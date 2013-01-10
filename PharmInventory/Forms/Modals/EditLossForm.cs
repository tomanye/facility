using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAL;
using DevExpress.XtraEditors;

namespace PharmInventory.Forms.Modals
{
    public partial class EditLossForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly int _itemid;
        private readonly string _fullitemname;
        private readonly string _stockcode;
        private readonly string _unit;
        public readonly int _storeid;
        public readonly int _reasonid;


        public EditLossForm()
        {
            InitializeComponent();
        }
        public EditLossForm(int itemId, string fullitemname, string stockcode, string unit, int storeid)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            _itemid = itemId ;
            _fullitemname = fullitemname;
            _stockcode = stockcode;
            _unit = unit;
            _storeid = storeid;
        }

        private void btnUpdateLoss_Click(object sender, EventArgs e)
        {
            var disposal = new ReceiveDoc();
         //   disposal.GetRecievedItemsWithBalanceForStore(_storeid);
            if (disposal.ExpDate > DateTime.Today)
            {
                disposal.AddNew();
                disposal.ItemID= _itemid;
                disposal.StoreID = _storeid;
                disposal.NoOfPack = Convert.ToInt32(txtPackQty.Text);
                disposal.QtyPerPack = Convert.ToInt32(txtQtyPerPack.Text);
                disposal.Cost = Convert.ToInt32(txtPricePerPack.Text);
                if (expirydateEdit != null) disposal.ExpDate = (DateTime)expirydateEdit.EditValue;
                disposal.Save();
            }
            else if (disposal.ExpDate < DateTime.Today)
            {
                XtraMessageBox.Show(String.Format(" {0} is already expired", txtItemName.Text), "Warning");
            }
            Close();
        }

        private void btnCancelLoss_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditLossForm_Load(object sender, EventArgs e)
        {
          var disposal = new Disposal();
          DataTable dtbl=  disposal.GetLossByItemId(_itemid);
            txtItemName.Text = _fullitemname;
            txtStockCode.Text = _stockcode;
            txtUnit.Text = _unit;
        }

    }
}