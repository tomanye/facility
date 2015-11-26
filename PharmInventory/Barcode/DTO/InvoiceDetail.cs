using System;

namespace PharmInventory.Barcode.DTO
{
    public class InvoiceDetail
    {
        public int I { get; set; } //ItemID
        public string U { get; set; }//Unit
        public int QP { get; set; }//QuantityPerPack
        public decimal Q { get; set; }//Quantity
        public decimal C { get; set; }//UnitCost
        public string B { get; set; }//Batch
        public DateTime? E { get; set; }//Expiry
    }
}
