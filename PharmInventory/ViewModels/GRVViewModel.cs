using System;
using System.Collections.Generic;

namespace PharmInventory.ViewModels
{
    public class GrvViewModel
    {
        public string From { get; set; }
        public DateTime Date { get; set; }
        public string To { get; set; }
        public string StvNo { get; set; }

        public IEnumerable<GrvDetail> GrvDetails { get; set; }
    }

    public class GrvDetail
    {
        public int Count { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalCost { get; set; }
        public string BatchNo { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
