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
        public string FullItemName { get; set; }
        public int AmcRange { get; set; }
        public string Store { get; set; }
        public  long IssueInAmcRange { get; set; }
        public int DaysOutOfStock { get; set; }
        public double AmcWithDos { get; set; }
        public double AmcWithoutDos { get; set; }
        public double IssueWithDOS { get; set; }
        public int UnitID { get; set; }

        public static AMCViewModel Create(int itemId, int storeId, int unitid,int amcRange, DateTime endDate)
        {
            var vwGetAllItemsRepository =new vwGetAllItemsRepository();
            var amcrepo = new AmcReportRepository();
            var allItemIdsonamc = amcrepo.AllAmcReport().SingleOrDefault(m => m.ItemID == itemId && m.StoreID == storeId && m.UnitID ==unitid);
            var products = vwGetAllItemsRepository.AllItems().SingleOrDefault(m => m.ID == itemId);
            var startDate = endDate.Subtract(TimeSpan.FromDays(amcRange*30));
            var viewModel = new AMCViewModel
                                {
                                    ItemID = itemId,
                                    StoreID = storeId,
                                    AmcRange = amcRange,
                                    IssueInAmcRange =Builder.CalculateTotalConsumptionWithoutDOS(itemId, storeId, startDate, endDate),
                                    DaysOutOfStock =Builder.CalculateStockoutDays(itemId, storeId, startDate, DateTime.Now),
                                    AmcWithDos =Builder.CalculateAverageConsumption(itemId, storeId, startDate, endDate,CalculationOptions.Monthly),
                                    IssueWithDOS =Builder.CalculateTotalConsumptionAMC(itemId, storeId, startDate, endDate),
                                    UnitID = unitid,
                                };
            AddorUpdateAmc(itemId, storeId, unitid,amcRange, endDate, amcrepo, viewModel, allItemIdsonamc, startDate);
            if (products != null)
            viewModel.FullItemName = products.FullItemName;
            viewModel.AmcWithoutDos = Convert.ToDouble(Builder.CalculateTotalConsumptionWithoutDOS(itemId,storeId,startDate,endDate)) / Convert.ToDouble(viewModel.AmcRange);
            return viewModel;
         }

        private static void AddorUpdateAmc(int itemId, int storeId,int unitid, int amcRange, DateTime endDate, AmcReportRepository amcrepo, AMCViewModel viewModel, AmcReport allItemIds, DateTime startDate)
        {
            if (allItemIds != null)
            {
                allItemIds.IssueInAmcRange = Builder.CalculateTotalConsumptionWithoutDOS(itemId, storeId, startDate,endDate);
                allItemIds.IssueWithDOS = Builder.CalculateTotalConsumptionAMC(itemId, storeId, startDate, endDate);
                allItemIds.AmcWithDOS = Builder.CalculateAverageConsumption(itemId, storeId, startDate, endDate,CalculationOptions.Monthly);
                allItemIds.AmcWithOutDOS =Builder.CalculateTotalConsumptionWithoutDOS(itemId, storeId, startDate, endDate)/Convert.ToDouble(viewModel.AmcRange);
                allItemIds.DaysOutOfStock = Builder.CalculateStockoutDays(itemId, storeId, startDate, DateTime.Now);
                allItemIds.LastIndexedTime = DateTime.Now;
                allItemIds.UnitID = unitid;
                amcrepo.Update(allItemIds);
            }
            else
            {
                var amcreport = new AmcReport
                                    {
                                        ItemID = itemId,
                                        StoreID = storeId,
                                        AmcRange = amcRange,
                                        IssueWithDOS = Builder.CalculateTotalConsumptionAMC(itemId, storeId, startDate, endDate),
                                        IssueInAmcRange =Builder.CalculateTotalConsumptionWithoutDOS(itemId, storeId, startDate,endDate),
                                        DaysOutOfStock =Builder.CalculateStockoutDays(itemId, storeId, startDate, DateTime.Now),
                                        AmcWithDOS = Builder.CalculateAverageConsumption(itemId, storeId, startDate,endDate,CalculationOptions.Monthly),
                                        AmcWithOutDOS = Builder.CalculateTotalConsumptionWithoutDOS(itemId, storeId, startDate, endDate) / Convert.ToDouble(viewModel.AmcRange),
                                        LastIndexedTime = DateTime.Now,
                                        UnitID = unitid
                                    };
                amcrepo.Add(amcreport);
            }
        }
    }
}
