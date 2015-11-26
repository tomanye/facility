using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using PharmInventory.Barcode;
using PharmInventory.Barcode.DTO;

namespace PharmInventory.Forms.Modals
{
    public partial class BarcodeInput : Form
    {
        private int _barcodeDataLen = -1;

       public IEnumerable<InvoiceHeader> STVs { get; set; }

        public BarcodeInput()
        {
            InitializeComponent();
            btnAddScannedData.DialogResult = DialogResult.OK;
            btnCancelScan.DialogResult = DialogResult.Cancel;
            txtRowInput.Focus();
        }

        private void txtRowInput_TextChanged(object sender, EventArgs e)
        {
            if (txtRowInput.Text.Length < 4) return;

            var dataLen = txtRowInput.Text.Substring(0, 4);

            if(_barcodeDataLen == -1)
                if (!int.TryParse(dataLen, out _barcodeDataLen))
                    return;

            if (_barcodeDataLen == -1) return;

            if (txtRowInput.Text.Length == _barcodeDataLen + 4)
            {
                STVs = DecodeBarcode(txtRowInput.Text.Substring(4, txtRowInput.Text.Length - 4));
                
                lblBarcodeStatus.Text = "Barcode read and decoded successfuly";
                //Thread.Sleep(2 * 1000);
                //Close();
                //DialogResult = DialogResult.OK;
            }
        }

        private IEnumerable<InvoiceHeader> DecodeBarcode(string rowData)
        {
            var rowInput = rowData;

            var dataType = rowInput.Substring(0, 3);
            var compressionStatus = rowInput.Substring(3, 3);
            rowInput = rowInput.Substring(6, rowInput.Length - 6);
            var serialized = compressionStatus == "CMP"
                ? TextCompression.Unzip(rowInput)
                : TextCompression.ConvetFromBase64StringToUTF(rowInput);

            barcodePicture.Image = new BarcodeService().Encode(serialized, EncodingType.QrCode, EncodedDataType.Invoice);

            if (dataType != "INV")
            {
                MessageBox.Show("Incorrect barcode");
                throw new Exception("Incorrect type of barcode");
            }
            return JsonConvert.DeserializeObject<IEnumerable<InvoiceHeader>>(serialized);
        }

    }
}
