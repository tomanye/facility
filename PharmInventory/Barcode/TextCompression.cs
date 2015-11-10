using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace PharmInventory.Barcode
{
    public class TextCompression
    {
        public static string Zip(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            using (var msi = new MemoryStream(bytes))
                using(var mso = new MemoryStream())
                {
                    using (var gs = new GZipStream(mso, CompressionMode.Compress))
                    {
                        CopyTo(msi, gs);   
                    }
                    return Convert.ToBase64String(mso.ToArray());
                }   
        }

        public static string Unzip(byte[] zipped)
        {
            using (var msi = new MemoryStream(zipped))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        public static string Unzip(string base64)
        {
            var bytes = Convert.FromBase64String(base64);
            return Unzip(bytes);
        }

        private static void CopyTo(Stream src, Stream dest)
        {
            var bytes = new byte[4096];
            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }
    }
}
