using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockoutIndexBuilder.Models;

namespace StockoutIndexBuilder.DAL
{
   public class ItemsRepository
    {
        StockoutEntities Context = new StockoutEntities();

        public List<Item> AllItems()
        {
            return Context.Items.ToList();
        }
    }
}
