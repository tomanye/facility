/****** Object:  StoredProcedure [dbo].[Rpt_BinCard]    Script Date: 8/22/2012 10:05:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--EXEC [Rpt_BinCard] 390
Create PROC [dbo].[Rpt_BinCard]
    @StoreID as int,
    @ItemID as int   
AS

select * into #tmp from 
(
-- select the received item
select rd.ID, rd.ItemID, ISNULL(rd.RefNo,'') as RefNo , ISNULL(rd.Date,'') as [Date], ISNULL(rd.BatchNo,'')as [BatchNo], (rd.Quantity - isnull((SELECT SUM(d.Quantity) from Disposal d where d.RecID = rd.ID and Losses = 0) ,0)) as Received, Issued = 0, ISNULL(rd.Cost,0) UnitPrice, ISNULL(rd.Cost * rd.Quantity, 0) as TotalPrice, Balance = 0 , ISNULL(ExpDate,'') ExpDate,Precedance = 1,ToFrom = (SELECT CompanyName from Supplier where ID = rd.SupplierID) from ReceiveDoc rd where ItemID = @ItemID and StoreID=@StoreID and dbo.ToEthiopianDate(rd.EurDate).FiscalYear = dbo.ToEthiopianDate(GetDATE()).FiscalYear
Union
-- select the issued item
select id.ID, rd.ItemID, ISNULL(id.RefNo,'') , ISNULL(id.Date,''), ISNULL(rd.BatchNo,''), Received = 0, ISNULL(id.Quantity,'') as Issued, ISNULL(rd.Cost,0) UnitPrice, ISNULL(rd.Cost * id.Quantity, 0) as TotalPrice, Balance = 0 , ISNULL(ExpDate,''), Precedance = 3 ,ToFrom = (SELECT Name from ReceivingUnits where ID = id.ReceivingUnitID) from IssueDoc id join ReceiveDoc rd on id.RecievDocID = rd.ID where id.ItemID = @ItemID  and id.StoreID=@StoreID and rd.StoreID=@StoreID  and dbo.ToEthiopianDate(id.EurDate).FiscalYear = dbo.ToEthiopianDate(GetDATE()).FiscalYear
Union
-- select the Lost
select d.ID, rd.ItemID, ISNULL(d.RefNo,'') , ISNULL(d.Date,''), ISNULL(rd.BatchNo,''), Received = 0,ISNULL( d.Quantity,0) as Issued, ISNULL(rd.Cost,0) UnitPrice, ISNULL(rd.Cost * d.Quantity, 0) as TotalPrice, Balance = 0, ExpDate  , Precedance = 4, ToFrom = (SELECT cast (Reason as Varchar) from DisposalReasons where ID = d.ReasonId) from Disposal d join ReceiveDoc rd on d.RecID = rd.ID where d.ItemID = @ItemID  and d.StoreID=@StoreID  and d.Losses = 1 and dbo.ToEthiopianDate(rd.EurDate).FiscalYear = dbo.ToEthiopianDate(GetDATE()).FiscalYear
Union
-- select the Found/Adjusted
select d.ID, rd.ItemID, ISNULL(d.RefNo,'') , ISNULL(d.Date,''), ISNULL(rd.BatchNo,''), ISNULL(d.Quantity,0) as Received, Issued = null, ISNULL(rd.Cost,0) UnitPrice, ISNULL(rd.Cost * d.Quantity, 0) as TotalPrice, Balance = 0, ExpDate ,Precedance = 2, ToFrom = (SELECT cast(Reason as Varchar) from DisposalReasons where ID = d.ReasonId) from Disposal d join ReceiveDoc rd on d.RecID = rd.ID where d.ItemID = @ItemID  and d.StoreID=@StoreID  and d.Losses = 0  and dbo.ToEthiopianDate(rd.EurDate).FiscalYear = dbo.ToEthiopianDate(GetDATE()).FiscalYear
-- return the table.
) results order by [Date],Precedance

DECLARE @Balance as int
set @Balance = 0
select  @Balance = ISNULL(ye.PhysicalInventory,0) from YearEnd ye where ye.Year = dbo.ToEthiopianDate(GetDATE()).FiscalYear and ye.StoreID = @StoreID 

update t set @Balance = Balance = (@Balance + ISNULL(Received,0) - ISNULL(Issued, 0)) from #tmp t
select * from #tmp
GO