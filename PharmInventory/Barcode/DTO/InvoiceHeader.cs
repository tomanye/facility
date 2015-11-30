using System;
using System.Collections.Generic;

namespace PharmInventory.Barcode.DTO
{
    public class InvoiceHeader
    {
        public int ID { get; set; } //STVID
        public string M { get; set; } //Mode code
        public string A { get; set; } //Account code
        public string F { get; set; }//From
        public int T { get; set; }//To ID
        public string IN { get; set; }//InvoiceNumber
        public string LN { get; set; }//Letter Number
        public int W { get; set; }//Warehouse ID
        public DateTime Dt { get; set; }//Date
        public IEnumerable<InvoiceDetail> D { get; set; }
    }
}
