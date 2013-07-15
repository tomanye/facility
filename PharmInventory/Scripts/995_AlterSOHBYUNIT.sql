ALTER PROCEDURE [dbo].[SOHByUnit] 
	@storeid int,
	@month int,
	@year int,
	@days int
AS
BEGIN
	declare @tempdate varchar(20)
	
	declare @amcrange int
	declare @min int
	declare @max int
	declare @eop float

	select  @amcrange = AMCRange,@eop = EOP, @min = MIN, @max = MAX from GeneralInfo 
	
	declare @rangedate datetime
	declare @todate datetime
	declare @fromdate datetime
	
	
	select @tempdate = cast(@month as varchar) + '/' + cast(@days as varchar) + '/' + cast(@year as varchar) 
	select @todate = cast(@tempdate as datetime)
	select @fromdate = case
				when MONTH(@todate)<=10 then cast('11/1/' + (cast((@year - 1) as varchar) ) as datetime)
				else cast('11/1/' + (cast((@year) as varchar) ) as datetime)
				end	
	select @rangedate = dateadd(month,0-@amcrange,@todate)
				
	select t.*, [Status] = case 
		when t.SOH is null or t.SOH = 0  then 'Stock Out'  
		when t.SOH < t.EOP then 'Below EOP'  
		when t.SOH <  (t.EOP * 1.25) then 'Near EOP' 
		when t.SOH > t.[Max] and t.AMC > 0 then 'Over Stocked' 
		else 'Normal' 
		end,
		(t.SOH - (t.Expired)) as Dispatchable
	from
	(select 
		case when vw.ID in (select distinct ItemID from ReceiveDoc where StoreID = @storeid and UnitID =iu.ID) then 1 else 0 end as EverReceived, 
		iu.ID as UnitID,
		isnull(rd.Quantity,0) as Received, 
		isnull(rd.QuantityLeft,0) as QuantityLeft,
		isnull(id.Quantity,0) as Issued,
		isnull(id2.Quantity,0) as IssuedMonth,
		isnull(loss.Quantity,0) as Lost, 
		isnull(adj.Quantity,0) as Adjusted , 
		isnull(amc.Quantity,0) as AMC ,
		isnull(dos.Quantity,0) as DOS ,
		 ( isnull(bb.Quantity,0) + isnull(rd.Quantity,0) + isnull(adj.Quantity,0) - isnull(id.Quantity,0) - isnull(loss.Quantity,0)) as SOH, 
		 isnull(amc.Quantity * @min, 0) as Min, 
		 isnull(amc.Quantity * @max,0) as Max, 
		 isnull(amc.Quantity * @eop,0) as EOP,
		 isnull(ed.Quantity,0) as Expired,
		 ISNULL(nEx.Quantity,0) as NearExpiry , 
		 vw.ID, vw.FullItemName,vw.StockCode, vw.Unit,vw.Name as Type,vw.TypeID, p.ID as ProgramID, p.Name as ProgramName 
		from vwGetAllItems vw 
		left join ProgramProduct pp on vw.ID = pp.ItemID 
		left join Programs p on pp.ProgramID = p.ID 
		left join ItemUnit iu on vw.ID=iu.ItemID 
		left join
		(select ItemID ,UnitID, sum(Quantity) Quantity, sum(QuantityLeft) QuantityLeft from ReceiveDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ,UnitID) as rd on rd.ItemID = vw.ID and rd.UnitID =iu.ID
		left join
		(select  ItemID ,UnitID , sum(Quantity) Quantity from IssueDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID,UnitID ) as id on id.ItemID = vw.ID and id.UnitID =iu.ID
		left join
		(select  ItemID ,UnitID , sum(Quantity) Quantity from IssueDoc where StoreID = @storeid and (year(date) = @year and MONTH(date) = @month) group by ItemID ,UnitID) as id2 on id2.ItemID = vw.ID and id2.UnitID =iu.ID
		left join
		(select  ItemID ,UnitID , sum(PhysicalInventory) Quantity from YearEnd where StoreID = @storeid and Year = Year(@fromdate)  group by ItemID,UnitID ) as bb on bb.ItemID = vw.ID and bb.UnitID=iu.ID
		left join
		(select  ItemID ,UnitID , sum(QuantityLeft) Quantity from ReceiveDoc where StoreID = @storeid and ExpDate < GETDATE() group by ItemID ,UnitID) as ed on ed.ItemID = vw.ID and ed.UnitID =iu.ID
		left join
		(select  ItemID ,rd.UnitID , sum(QuantityLeft) Quantity from ReceiveDoc rd join vwGetAllItems v on rd.ItemID=v.ID where StoreID = @storeid and ExpDate between GETDATE() and DATEADD(day,v.NearExpiryTrigger,GETDATE()) group by ItemID ,rd.UnitID) as nEx on nEx.ItemID = vw.ID and nEx.UnitID =iu.ID	
		left join
		(select ItemID,UnitId, Max(AmcWithDos) as Quantity from AmcReport ar where ar.StoreID=@storeid group by ItemID ,UnitID)as amc on amc.ItemID = vw.ID and amc.UnitID=iu.ID
			left join
		(select ItemID,UnitID, Max(DaysOutOfStock) as Quantity from AmcReport ar where ar.StoreID=@storeid group by ItemID,UnitID)as dos on dos.ItemID = vw.ID  and dos.UnitID =iu.ID
	     left join
		(select  ItemID ,UnitID , sum(Quantity) Quantity from Disposal where StoreID = @storeid and (date between @fromdate and @todate) and Losses = 1 group by ItemID,UnitID ) as loss on loss.ItemID = vw.ID and loss.UnitID=iu.ID
		left join
		(select  ItemID ,UnitID , sum(Quantity) Quantity from Disposal where StoreID = @storeid and (date between @fromdate and @todate) and Losses = 0 group by ItemID ,UnitID ) as adj on adj.ItemID = vw.ID and adj.UnitID =iu.ID
		where vw.IsInHospitalList = 1 and vw.ID in (select ItemID from vwGetAllItems vw join ReceiveDoc rd on vw.ID =rd.ItemID and iu.ID =rd.UnitID))
		t order by t.FullItemName
END

