using System;
using System.Collections.Generic;

namespace PharmInventory.Barcode.DTO
{
    public class RRFHeader
    {
        public Guid F { get; set; }                     //facility name or sn
        public string PC { get; set; }                  //program name should be sn but don't know how to 
        public string M { get; set; }                   //Budget store, Program Store
        public DateTime PS { get; set; }                //request period start
        public DateTime PE { get; set; }                //request period end
        //public string C { get; set; }                   //category
        public IEnumerable<RRFDetail> D { get; set; }   //details
    }
}
