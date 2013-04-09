
// Generated by MyGeneration Version # (1.3.0.3)

using System;
using DAL;
using System.Data;

namespace BLL
{
    public class Disposal : _Disposal
    {
        public Disposal()
        {

        }

        public DataTable GetDocumentByRefNo(string refNo, int storeId, string dtAdj)
        {
            this.FlushData();
            string query =
                String.Format(
                    "SELECT *, CASE Losses WHEN 1 then cast(0-Quantity as nvarchar) else '+' + cast(Quantity as nvarchar) end as QuantityDetail," +
                    " ROW_NUMBER() OVER (ORDER BY Date DESC) as RowNo " +
                    "FROM Disposal d JOIN vwGetAllItems on vwGetAllItems.ID = d.ItemID JOIN ItemUnit iu on d.UnitID = iu.ID WHERE (RefNo = '{0}') AND Date = '{2}' AND StoreId = {1}",
                    refNo, storeId, dtAdj);
            this.LoadFromRawSql(query);
            return this.DataTable;
        }

        public DataTable GetDisposalByBatchAndID(int recId)
        {
            this.FlushData();
            this.LoadFromRawSql(String.Format("select * from Disposal where  RecID = {0}", recId));
            return this.DataTable;
        }

        public DataTable GetAllTransaction(int storeId)
        {
            this.FlushData();
            this.LoadFromRawSql(
                String.Format(
                    "SELECT *,ROW_NUMBER() OVER (ORDER BY Date DESC) FROM Disposal WHERE StoreId = {0} ORDER BY Date DESC",
                    storeId));
            return this.DataTable;
        }

        public DataTable GetTransactionByReason(int storeId, int reasonId)
        {
            this.FlushData();
            this.LoadFromRawSql(
                String.Format(
                    "SELECT *, ROW_NUMBER() OVER (ORDER BY Date DESC) as RowNo, CASE Losses WHEN 1 then cast(0-Quantity as nvarchar) else '+' + cast(Quantity as nvarchar) end as QuantityDetail FROM Disposal d JOIN vwGetAllItems on vwGetAllItems.ID = d.ItemID WHERE StoreId = {0} AND ReasonId = {1} ORDER BY Date DESC",
                    storeId, reasonId));
            return this.DataTable;
        }

        /// <summary>
        /// //ChangedDate:
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="itemId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetTransactionByItemId(int storeId, int itemId, int year)
        {
            this.FlushData();
            EthiopianDate.EthiopianDate ethioDate = new EthiopianDate.EthiopianDate(year, 1, 1);
            DateTime startOfFiscalYear = ethioDate.StartOfFiscalYear.ToGregorianDate();
            DateTime endOfFiscalYear = ethioDate.EndOfFiscalYear.ToGregorianDate();

            //this.LoadFromRawSql(String.Format("SELECT * FROM Disposal WHERE StoreId = {0} AND ItemId = {1} AND ((Year(Date) = {2} AND Month(Date) < 11) OR (Year(Date) = {3} AND Month(Date) > 10)) ORDER BY Date", storeId, itemId,year,year-1));
            this.LoadFromRawSql(
                String.Format(
                    "SELECT * FROM Disposal WHERE StoreId = {0} AND ItemId = {1} AND (EurDate between '{2}' and '{3}') ORDER BY Date",
                    storeId, itemId, startOfFiscalYear, endOfFiscalYear));
            return this.DataTable;
        }

        public DataTable GetTransactionByDateRange(int storeId, DateTime dt1, DateTime dt2)
        {
            this.FlushData();
            string query = String.Format("SELECT *,ROW_NUMBER() OVER (ORDER BY Date DESC) as RowNo, " +
                                         "CASE Losses WHEN 1 then cast(0-Quantity as nvarchar) else '+' + cast(Quantity as nvarchar) end as QuantityDetail " +
                                         "FROM Disposal JOIN DisposalReasons on Disposal.ReasonId = DisposalReasons.ID " +
                                         "JOIN vwGetAllItems on vwGetAllItems.ID = Disposal.ItemID WHERE StoreId = {0} AND (Date BETWEEN '{1}' AND '{2}' ) ORDER BY Date DESC",
                                         storeId, dt1.ToShortDateString(), dt2.ToShortDateString());
            this.LoadFromRawSql(query);
            return this.DataTable;
        }

        public Int64 GetLossesByDateRange(int itemId, int storeId, DateTime dt1, DateTime dt2)
        {
            this.FlushData();
            this.LoadFromRawSql(String.Format("SELECT Sum(Quantity) AS Loss FROM Disposal" +
                                              " WHERE StoreId = {0} AND Losses = 1 AND ItemID = {3} AND (Date BETWEEN '{1}' AND '{2}' ) ",
                                              storeId, dt1.ToShortDateString(), dt2.ToShortDateString(), itemId));
            return ((this.DataTable.Rows[0]["Loss"] != DBNull.Value)
                        ? Convert.ToInt64(this.DataTable.Rows[0]["Loss"])
                        : 0);
        }

        public Int64 GetAdjustmentsByDateRange(int itemId, int storeId, DateTime dt1, DateTime dt2)
        {
            this.FlushData();
            this.LoadFromRawSql(
                String.Format(
                    "SELECT Sum(Quantity) AS Adj FROM Disposal WHERE StoreId = {0} AND Losses = 0 AND ItemID = {3} AND (Date BETWEEN '{1}' AND '{2}' ) ",
                    storeId, dt1.ToShortDateString(), dt2.ToShortDateString(), itemId));
            return ((this.DataTable.Rows[0]["Adj"] != DBNull.Value) ? Convert.ToInt64(this.DataTable.Rows[0]["Adj"]) : 0);
        }

        public DataTable GetDistinctAdjustmentDocments(int storeId)
        {
            this.FlushData();
            this.LoadFromRawSql(
                String.Format(
                    "SELECT DISTINCT RefNo, StoreId, Date, cast (Year(Date) as varchar) as ParentID, RefNo + cast(Date as varchar) as ID  FROM Disposal WHERE StoreId = {0} ORDER BY Date DESC",
                    storeId));
            DataTable dtbl = this.DataTable;
            this.LoadFromRawSql("select distinct Year(Date) as Year from Disposal order by year(Date) DESC");
            while (!this.EOF) //The following is added for the benefit of tree control and having parents there.
            {
                DataRowView drv = dtbl.DefaultView.AddNew();
                drv["RefNo"] = drv["ID"] = (this.DataRow["Year"].ToString());
                this.MoveNext();
            }
            return dtbl;
        }

        public Int64 GetAdjustedQuantity(int itemId, int storeId, int year)
        {
            //There should be a date range for the last month or some thing
            this.FlushData();
            this.LoadFromRawSql(
                String.Format(
                    "SELECT SUM(Quantity) AS Quantity FROM  Disposal WHERE (Losses = 0) AND (ItemID = {0} AND StoreId = {1}) AND ((Year(Date) = {2} AND Month(Date) < 11) OR (Year(Date) = {3} AND Month(Date) > 10))",
                    itemId, storeId, year, year - 1));
            Int64 quant = 0;
            quant = (this.DataTable.Rows[0]["Quantity"].ToString() != "")
                        ? Convert.ToInt64(this.DataTable.Rows[0]["Quantity"])
                        : 0;
            return quant;
        }

        public Int64 GetAdjustedQuantityTillMonth(int itemId, int storeId, int month, int year)
        {
            //There should be a date range for the last month or some thing
            this.FlushData();
            int yr = (month < 11) ? year - 1 : year;
            DateTime dt1 = new DateTime(yr, 11, 1);
            DateTime dt2 = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            this.LoadFromRawSql(
                String.Format(
                    "SELECT SUM(Quantity) AS Quantity FROM  Disposal WHERE (Losses = 0) AND (ItemID = {0} AND StoreId = {1} AND (Date between '{2}' AND '{3}'))",
                    itemId, storeId, dt1.ToString(), dt2.ToString()));
            Int64 quant = 0;
            quant = (this.DataTable.Rows[0]["Quantity"].ToString() != "")
                        ? Convert.ToInt64(this.DataTable.Rows[0]["Quantity"])
                        : 0;
            return quant;
        }

        public Int64 GetAdjustedQuantityTillMonthAll(int itemId, int month, int year)
        {
            //There should be a date range for the last month or some thing
            this.FlushData();
            DateTime dt1 = new DateTime(year - 1, 11, 1);
            int yr = (month > 10) ? year - 1 : year;
            DateTime dt2 = new DateTime(yr, month, DateTime.DaysInMonth(yr, month));

            this.LoadFromRawSql(
                String.Format(
                    "SELECT SUM(Quantity) AS Quantity FROM  Disposal WHERE (Losses = 0) AND (ItemID = {0}  AND (Date between '{1}' AND '{2}'))",
                    itemId, dt1.ToString(), dt2.ToString()));
            Int64 quant = 0;
            quant = (this.DataTable.Rows[0]["Quantity"].ToString() != "")
                        ? Convert.ToInt64(this.DataTable.Rows[0]["Quantity"])
                        : 0;
            return quant;
        }

        public Int64 GetAdjustedQuantityPastMonth(int itemId, int storeId, int month, int year)
        {
            //There should be a date range for the last month or some thing
            this.FlushData();
            DateTime dt1 = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            int yr = (month > 10) ? year - 1 : year;
            DateTime dt2 = dt1.AddMonths(-12);

            this.LoadFromRawSql(
                String.Format(
                    "SELECT SUM(Quantity) AS Quantity FROM  Disposal WHERE (Losses = 0) AND (ItemID = {0} AND StoreId = {1} AND (Date between '{2}' AND '{3}'))",
                    itemId, storeId, dt1.ToString(), dt2.ToString()));
            Int64 quant = 0;
            quant = (this.DataTable.Rows[0]["Quantity"].ToString() != "")
                        ? Convert.ToInt64(this.DataTable.Rows[0]["Quantity"])
                        : 0;
            return quant;
        }

        public Int64 GetAdjustedQuantityPerMonth(int itemId, int storeId, int month, int year)
        {
            //There should be a date range for the last month or some thing
            this.FlushData();
            this.LoadFromRawSql(
                String.Format(
                    "SELECT SUM(Quantity) AS Quantity FROM  Disposal WHERE (Losses = 0) AND (ItemID = {0} AND StoreId = {1} AND ((Month(Date) = {2} AND Year(Date) = {3}) OR (Month(Date) = 11 AND Year(Date) = {4})OR (Month(Date) = 12 AND Year(Date) = {4}) ))",
                    itemId, storeId, month, year, year - 1));
            Int64 quant = 0;
            quant = (this.DataTable.Rows[0]["Quantity"].ToString() != "")
                        ? Convert.ToInt64(this.DataTable.Rows[0]["Quantity"])
                        : 0;
            return quant;
        }

        public double GetAdjustedAmount(int itemId, int storeId, int year)
        {
            //There should be a date range for the last month or some thing
            this.FlushData();
            this.LoadFromRawSql(
                String.Format(
                    "SELECT SUM(Quantity * Cost) AS Amount FROM  Disposal WHERE (Losses = 0) AND (ItemID = {0} AND StoreId = {1}) AND ((Year(Date) = {2} AND Month(Date) <11) OR (Year(Date) = {3} AND Month(Date) > 10))",
                    itemId, storeId, year, year - 1));
            double price = 0;
            price = (this.DataTable.Rows[0]["Amount"].ToString() != "")
                        ? Convert.ToDouble(this.DataTable.Rows[0]["Amount"])
                        : 0;
            return price;
        }

        public double GetAdjustedAmountTillMonth(int itemId, int storeId, int month, int year)
        {
            //There should be a date range for the last month or some thing
            this.FlushData();
            int yr = (month < 11) ? year - 1 : year;
            DateTime dt1 = new DateTime(yr, 11, 1);
            DateTime dt2 = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            this.LoadFromRawSql(
                String.Format(
                    "SELECT SUM(Quantity * Cost) AS Amount FROM  Disposal WHERE (Losses = 0) AND (ItemID = {0} AND StoreId = {1}) AND ( Date between '{2}' AND '{3}')",
                    itemId, storeId, dt1.ToString(), dt2.ToString()));
            double price = 0;
            price = (this.DataTable.Rows[0]["Amount"].ToString() != "")
                        ? Convert.ToDouble(this.DataTable.Rows[0]["Amount"])
                        : 0;
            return price;
        }

        public Int64 GetLossesQuantity(int itemId, int storeId, int year)
        {
            //There should be a date range for the last month or some thing
            this.FlushData();
            this.LoadFromRawSql(
                String.Format(
                    "SELECT SUM(Quantity) AS Quantity FROM  Disposal WHERE (Losses = 1) AND (ItemID = {0} AND StoreId = {1}) AND ((Year(Date) = {2} AND Month(Date) < 11) OR (Year(Date) = {3} AND Month(Date) > 10))",
                    itemId, storeId, year, year - 1));
            Int64 quant = 0;
            quant = (this.DataTable.Rows[0]["Quantity"].ToString() != "")
                        ? Convert.ToInt64(this.DataTable.Rows[0]["Quantity"])
                        : 0;
            return quant;
        }

        public Int64 GetLossesQuantityTillMonth(int itemId, int storeId, int month, int year)
        {
            //There should be a date range for the last month or some thing
            this.FlushData();
            int yr = (month < 11) ? year - 1 : year;
            DateTime dt1 = new DateTime(yr, 11, 1);
            DateTime dt2 = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            string query =
                String.Format(
                    "SELECT SUM(Quantity) AS Quantity FROM  Disposal WHERE (Losses = 1) AND (ItemID = {0} AND StoreId = {1} AND (Date between '{2}' AND '{3}'))",
                    itemId, storeId, dt1.ToString(), dt2.ToString());
            this.LoadFromRawSql(query);

            Int64 quant = 0;
            quant = (this.DataTable.Rows[0]["Quantity"].ToString() != "")
                        ? Convert.ToInt64(this.DataTable.Rows[0]["Quantity"])
                        : 0;
            return quant;
        }

        public Int64 GetLossesQuantityTillMonthAll(int itemId, int month, int year)
        {
            //There should be a date range for the last month or some thing
            this.FlushData();
            DateTime dt1 = new DateTime(year - 1, 11, 1);
            int yr = (month > 10) ? year - 1 : year;
            DateTime dt2 = new DateTime(yr, month, DateTime.DaysInMonth(yr, month));

            this.LoadFromRawSql(
                String.Format(
                    "SELECT SUM(Quantity) AS Quantity FROM  Disposal WHERE (Losses = 1) AND (ItemID = {0} AND (Date between '{1}' AND '{2}'))",
                    itemId, dt1.ToString(), dt2.ToString()));
            Int64 quant = 0;
            quant = (this.DataTable.Rows[0]["Quantity"].ToString() != "")
                        ? Convert.ToInt64(this.DataTable.Rows[0]["Quantity"])
                        : 0;
            return quant;
        }

        public Int64 GetLossesQuantityPastMonth(int itemId, int storeId, int month, int year)
        {
            //There should be a date range for the last month or some thing
            this.FlushData();
            DateTime dt1 = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            DateTime dt2 = dt1.AddMonths(-12);

            this.LoadFromRawSql(
                String.Format(
                    "SELECT SUM(Quantity) AS Quantity FROM  Disposal WHERE (Losses = 1) AND (ItemID = {0} AND StoreId = {1} AND (Date between '{2}' AND '{3}'))",
                    itemId, storeId, dt1.ToString(), dt2.ToString()));
            Int64 quant = 0;
            quant = (this.DataTable.Rows[0]["Quantity"].ToString() != "")
                        ? Convert.ToInt64(this.DataTable.Rows[0]["Quantity"])
                        : 0;
            return quant;
        }

        public Int64 GetLossesQuantityPerMonth(int itemId, int storeId, int month, int year)
        {
            //There should be a date range for the last month or some thing
            this.FlushData();
            this.LoadFromRawSql(
                String.Format(
                    "SELECT SUM(Quantity) AS Quantity FROM  Disposal WHERE (Losses = 1) AND (ItemID = {0} AND StoreId = {1} AND ((Month(Date) = {2} AND Year(Date) = {3}) OR (Month(Date) = 11 AND Year(Date) = {4}) OR (Month(Date) = 12 AND Year(Date) = {4})))",
                    itemId, storeId, month, year, year - 1));
            Int64 quant = 0;
            quant = (this.DataTable.Rows[0]["Quantity"].ToString() != "")
                        ? Convert.ToInt64(this.DataTable.Rows[0]["Quantity"])
                        : 0;
            return quant;
        }

        public DataTable GetTransactionByRefNo(string refNo)
        {
            this.FlushData();
            this.LoadFromRawSql(String.Format("SELECT * FROM Disposal where RefNo = '{0}'", refNo));
            return this.DataTable;
        }

        public double GetLossesAmount(int itemId, int storeId, int year)
        {
            //There should be a date range for the last month or some thing
            this.FlushData();
            this.LoadFromRawSql(
                String.Format(
                    "SELECT SUM(Quantity * Cost) AS Amount FROM  Disposal WHERE (Losses = 1) AND (ItemID = {0} AND StoreId = {1}) AND ((Year(Date) = {2} OR Month(Date) < 11) AND (Year(Date) = {3} AND Month(Date) > 10))",
                    itemId, storeId, year, year - 1));
            double price = 0;
            price = (this.DataTable.Rows[0]["Amount"].ToString() != "")
                        ? Convert.ToDouble(this.DataTable.Rows[0]["Amount"])
                        : 0;
            return price;
        }

        public double GetLossesAmountTillMonth(int itemId, int storeId, int month, int year)
        {
            //There should be a date range for the last month or some thing
            this.FlushData();
            //int yr = (month < 11) ? year - 1 : year;
            int yr = (month < 11) ? year : year + 1;
            DateTime dt1 = new DateTime(yr, 11, 1);
            DateTime dt2 = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            this.LoadFromRawSql(
                String.Format(
                    "SELECT SUM(Quantity * Cost) AS Amount FROM  Disposal WHERE (Losses = 1) AND (ItemID = {0} AND StoreId = {1}) AND ( Date between '{2}' AND '{3}')",
                    itemId, storeId, dt1.ToString(), dt2.ToString()));
            double price = 0;
            price = (this.DataTable.Rows[0]["Amount"].ToString() != "")
                        ? Convert.ToDouble(this.DataTable.Rows[0]["Amount"])
                        : 0;
            return price;
        }

        public DataTable GetLossByItemId(int Id)
        {
            this.FlushData();
            this.LoadFromRawSql(
                String.Format(
                    "select vw.FullItemName, vw.TypeID ,vw.Unit,vw.StockCode, rd.ID as ReceiveID,BatchNo,ItemID,SupplierID, ExpDate ExpiryDate, StoreID,QuantityLeft, RefNo,rd.Cost, EurDate from ReceiveDoc rd join vwGetAllItems vw on rd.ItemID = vw.ID where ItemID = {0} and QuantityLeft > 0",
                    Id));
            return this.DataTable;
        }

        public bool MergeStore(int storeone, int storetwo)
        {
            this.FlushData();
            return
                this.LoadFromRawSql(String.Format("UPDATE Disposal SET StoreID = {0} WHERE StoreID = {1}", storeone,
                                                  storetwo));
        }

        public DataTable GetLossAdjustmentsForLastRrfPeriod(int itemID, int storeID, int ProgramID, DateTime startDate, DateTime endDate)
        {
            this.FlushData();
            string query =
                string.Format(
                    "select * from disposal d join ReceiveDoc rd on d.RecID=rd.ID where  d.EurDate>cast('{0}' as datetime) and d.EurDate<=cast('{1}' as datetime) and rd.ItemID={2} and rd.StoreID={3} and rd.SubProgramID={4}",
                    startDate, endDate, itemID, storeID, ProgramID);
            this.LoadFromRawSql(query);
            return this.DataTable;
        }
    }
}
    