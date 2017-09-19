ALTER PROCEDURE [dbo].[GetTransactionDetails]
	  @storeid int,
	  @todate datetime,
	  @fromdate datetime
AS
BEGIN
select t.*
	from
	(select 
		case when vw.ID in (select distinct ItemID from ReceiveDoc where StoreID = @storeid) then 1 else 0 end as Received, 
		isnull(rd.Quantity,0) as ReceivedQty, 
		isnull(rd.Price,0) as ReceivedPrice, 
		isnull(rd.QuantityLeft,0) as QuantityLeft, 
		isnull(rd.price1,0) as QuantityLeftPrice, 
		isnull(id.Quantity,0) as IssuedQty, 
		isnull(id.Price,0) as IssuedPrice,   
		 ISNULL(yr.Physicalinventory,0) AS Physicalinventory,
		vw.ID, vw.FullItemName,vw.StockCode, 
		vw.Unit,vw.Name ,vw.TypeID AS TypeID
		FROM vwGetAllItems vw  
		LEFT JOIN 
		(SELECT ItemID , SUM(Quantity) Quantity, SUM(QuantityLeft) QuantityLeft, SUM(Quantity * Cost) Price ,SUM(QuantityLeft*Cost) price1 
		FROM ReceiveDoc WHERE StoreID = @storeid AND (date BETWEEN @fromdate AND @todate) GROUP BY ItemID ) AS rd ON rd.ItemID = vw.ID 
		LEFT JOIN (SELECT ItemID , SUM(Physicalinventory) Physicalinventory, SUM(Physicalinventory * PhysicalInventoryPrice) PhysicalinventoryPrice 
		FROM [YearEnd] WHERE StoreID = @storeid AND ([year]  = YEAR(@fromdate)  ) GROUP BY ItemID ) AS yr ON yr.ItemID = vw.ID   
	     LEFT JOIN
		(select ItemID , sum(Quantity) Quantity, SUM(Quantity * Cost) Price 
		from IssueDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as id on id.ItemID = vw.ID 
		where vw.IsInHospitalList = 1) t order by t.FullItemName
END


