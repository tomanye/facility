using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockoutIndexBuilder.Models;

namespace PharmInventory.ViewModels
{
    public class ItemViewModel
    {
        private bool _indexed = false;
        
        public ItemViewModel(Item item)
        {
            ItemId = item.ID;
            StockCode = item.StockCode;
            DosageFormId = item.DosageFormId;
            Strength = item.Strength;
            IINID = item.IINID;

        }
        public string FullItemName
        {
            get { return String.Format("{0}{1}",StockCode, Strength); }
        }

        public int? IINID { get; set; }
        public int ItemId { get; set; }        
        public string StockCode { get; set; }
        public int? DosageFormId { get; set; }
        public string Strength { get; set; }
        
        public bool Indexed 
        {
            get { return _indexed; }
            set { _indexed = value; }
        }
    }
}
