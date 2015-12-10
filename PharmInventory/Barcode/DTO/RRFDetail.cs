
namespace PharmInventory.Barcode.DTO
{
    public class RRFDetail
    {
        //public string SC { get; set; }//stock code
        public int I { get; set; }//Item SN
        //public int? UID { get; set; } //UnitID
        //public int PPPS { get; set; }//prefered pfsa pack size
        public decimal B  { get; set; } //Beggining Balance
        //public decimal LDUSOH { get; set; } //Last despensing unit soh
        public decimal R { get; set; } // received
        public decimal IS { get; set; } //issued
        public decimal L { get; set; } //loss and adjustment
        public decimal E { get; set; } //EndingBalance
        public int  D { get; set; } //DOS
        public decimal M { get; set; } //Max stock
        public decimal QM { get; set; } //qty to reach max
        public decimal Q { get; set; } //quantity ordered
    }
}
