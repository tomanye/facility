using System;
using System.Drawing;
using DataMatrix.net;
using MessagingToolkit.QRCode.Codec;

namespace PharmInventory.Barcode
{
    public class BarcodeService
    {
        public Bitmap Encode(string text, EncodingType type, string dataType)
        {
            var uncompressedText = "UNC" + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));
            var compressedText = "CMP" + TextCompression.Zip(text);

            int originalLen = uncompressedText.Length, compressedLen = compressedText.Length;

            var toEncode = compressedLen < originalLen ? compressedText : uncompressedText;

            if (dataType != EncodedDataType.Invoice && dataType != EncodedDataType.RRF && EncodedDataType.Receipt != dataType)
                throw new Exception("Invalid data type, please use the defined constants in EncodedDataType class");

            toEncode = dataType + toEncode;

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

    public class EncodedDataType
    {
        public const string Invoice = "INV", Receipt = "RCT", RRF = "RRF", Grv = "GRV";
    }

}
