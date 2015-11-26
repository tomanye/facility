using System.Collections.Generic;
using System.Data;
using BLL;

namespace PharmInventory.Barcode.Service
{
    public static class RRFDataService
    {
        public static IEnumerable<DTO.RRFDetail> GetRRFDetails(DataTable table)
        {
            var item = new Items();
            var details = new List<DTO.RRFDetail>();
            

            foreach (var t in table.AsEnumerable())
            {
                item.LoadByPrimaryKey(t.Field<int>("ID"));

                details.Add(new DTO.RRFDetail
                {
                    I = item.DSItemID,
                    SC = t.Field<string>("StockCode"),
                    UID = Items.GetUnitIDFromSN(item.DSItemID),
                    B = (decimal) t.Field<double>("BeginingBalance"),
                    D = t.Field<int>("DaysOutOfStock"),
                    E = t.Field<decimal>("TotalSOH"),
                    L = (decimal) t.Field<double>("LossAdj"),
                    Q = (decimal) t.Field<double>("Quantity"),
                    R = (decimal) t.Field<double>("Received")
                });
            }

            return details;
        }
    }
}
