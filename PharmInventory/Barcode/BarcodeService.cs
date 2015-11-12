using System;
using System.Drawing;
using DataMatrix.net;
using MessagingToolkit.QRCode.Codec;

namespace PharmInventory.Barcode
{
    public class BarcodeService
    {
        public Bitmap Encode(string text, EncodingType type, EncodedDataType dataType)
        {
            var uncompressedText = "UNC" + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));
            var compressedText = "CMP" + TextCompression.Zip(text);

            int originalLen = uncompressedText.Length, compressedLen = compressedText.Length;

            var toEncode = compressedLen < originalLen ? compressedText : uncompressedText;

            toEncode = (dataType == EncodedDataType.Invoice ? "INV" : "RCT") + toEncode;

            toEncode = toEncode.Length.ToString("0000") + toEncode;

            if (type == EncodingType.QrCode)
                return GetQrCode(toEncode);

            return type == EncodingType.DataMatrix ? GetDataMatrix(toEncode) : null;
        }

        private static Bitmap GetQrCode(string text)
        {
            var enc = new QRCodeEncoder();
            return enc.Encode(text);
        }

        private static Bitmap GetDataMatrix(string text)
        {
            var encoder = new DmtxImageEncoder();
            return encoder.EncodeImage(text);
        }
    }

    public enum EncodingType
    {
        QrCode, DataMatrix
    }

    public enum EncodedDataType
    {
        Invoice, Receipt
    }
}
