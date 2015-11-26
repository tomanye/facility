using System.Collections.Generic;

namespace PharmInventory.Barcode.DTO
{
    public class RRFHeader
    {
        public string F { get; set; }                   //facility name or sn
        public string PN { get; set; }                  //program name should be sn but don't know how to 
        public string M { get; set; }
        public string P { get; set; }                   //request period
        public string C { get; set; }                   //category
        public IEnumerable<RRFDetail> D { get; set; }   //details
    }
}
