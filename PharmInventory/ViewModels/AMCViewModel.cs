using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockoutIndexBuilder;
using StockoutIndexBuilder.DAL;
using StockoutIndexBuilder.Models;

namespace PharmInventory.ViewModels
{
    class AMCViewModel
    {

        public int ItemID { get; set; }
        public int StoreID { get; set; }
        public string StockCode { get; set; }
        public int? DosageFormId { get; set; }
        public int? IINID { get; set; }
        public string Strength { get; set; }
        //public string FullItemName
        //{
        //    get { return String.Format("{0}{1}{2}{3}", StockCode, Strength, DosageFormId,IINID); }
        //}
        public string FullItemName { get; set; }
        public int AmcRange { get; set; }
        public string Store { get; set; }
        public long IssueInAmcRange { get; set; }
        public int DaysOutOfStock { get; set; }
        public double AmcWithDos { get; set; }
        public double AmcWithoutDos { get; set; }

        public static AMCViewModel Create(int itemId, int storeId, int amcRange, DateTime endDate)
        {
            ItemsRepository repository =new ItemsRepository();
            vwGetAllItemsRepository vwGetAllItemsRepository =new vwGetAllItemsRepository();
            var items = repository.AllItems().Single(m => m.ID == itemId);
            var products= vwGetAllItemsRepository.AllItems().SingleOrDefault(m => m.ID == itemId);
           
            var startDate = endDate.Subtract(TimeSpan.FromDays(amcRange*30));
          
                var viewModel = new AMCViewModel()
                                    {

                                        ItemID = itemId,
                                        StoreID = storeId,
                                        AmcRange = amcRange,
                                        StockCode = items.StockCode,
                                        Strength = items.Strength,
                                        DosageFormId = items.DosageFormId,
                                        IINID = items.IINID,
                                        
                                        IssueInAmcRange =
                                            Builder.CalculateTotalConsumption(itemId, storeId, startDate, endDate),
                                        DaysOutOfStock =
                                            Builder.CalculateStockoutDays(itemId, storeId, startDate, endDate),
                                        AmcWithDos =
                                            Builder.CalculateAverageConsumption(itemId, storeId, startDate, endDate,
                                                                                CalculationOptions.Monthly)
                                    };
                if (products != null)
                    viewModel.FullItemName = products.FullItemName;
                viewModel.AmcWithoutDos = Convert.ToDouble(viewModel.IssueInAmcRange) / Convert.ToDouble(viewModel.AmcRange);
                return viewModel;
            
        }

    }
}
