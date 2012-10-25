using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockoutIndexBuilder.Models;

namespace PharmInventory.ViewModel
{
    public class ItemViewModel
    {
        private bool _indexed = false;
        public ItemViewModel()
        {

        }

        public ItemViewModel(Item item)
        {
            ItemID = item.ID;
            StockCode = item.StockCode;
        }
        public int ItemID { get; set; }        
        public string StockCode { get; set; }
        public bool Indexed 
        {
            get { return _indexed; }
            set { _indexed = value; }
        }
    }
}
