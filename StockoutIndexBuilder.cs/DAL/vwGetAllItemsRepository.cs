using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockoutIndexBuilder.Models;

namespace StockoutIndexBuilder.DAL
{
    public class vwGetAllItemsRepository
    {
        StockoutEntities Context = new StockoutEntities();

        public List<vwGetAllItems> AllItems()
        {
            return Context.VwGetAllItemses.ToList();
        }
    }
}
