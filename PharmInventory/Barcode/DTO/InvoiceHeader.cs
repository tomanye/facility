using System;
using System.Collections.Generic;

namespace PharmInventory.Barcode.DTO
{
    public class InvoiceHeader
    {
        public int ID { get; set; } //STVID
        public int A { get; set; } //Account ID
        public string F { get; set; }//From
        public int T { get; set; }//To ID
        public string IN { get; set; }//InvoiceNumber
        public string LN { get; set; }//Letter Number
        public int W { get; set; }//Warehouse ID
        public DateTime Dt { get; set; }//Date
        public IEnumerable<InvoiceDetail> D { get; set; }
    }
}
