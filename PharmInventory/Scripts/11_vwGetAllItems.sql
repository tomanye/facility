ALTER VIEW [dbo].[vwGetAllItems]
AS
SELECT DISTINCT 
                      dbo.Items.ID, ISNULL(dbo. Product .IIN, '') + ' - ' + ISNULL(dbo.Items.Strength, '') + ' - ' + ISNULL(dbo.DosageForm.Form, '') AS FullItemName, 
                      dbo. Product .IIN AS ItemName, dbo.Items.Strength, dbo.Items.ABC AS ABCID, dbo.Items.VEN AS VENID, dbo.Items.IsFree, dbo.Items.DosageFormID, 
                      dbo.DosageForm.Form AS DosageForm, dbo.Items.UnitID, dbo.Unit.Unit, dbo.Items.StockCode, dbo.Items.IINID, dbo.Items.IsInHospitalList, 
                      dbo. Product .TypeID, dbo.Items.Code, dbo.Items.NeedExpiryBatch, dbo.Items.StorageTypeID, dbo.Items.NearExpiryTrigger, dbo.[Type].Name,dbo.Items.Cost
FROM         dbo.Items INNER JOIN
                      dbo. Product ON dbo.Items.IINID = dbo. Product .ID INNER JOIN
                      dbo.[Type] ON dbo. Product .TypeID = dbo.[Type].ID INNER JOIN
                      dbo.DosageForm ON dbo.DosageForm.ID = dbo.Items.DosageFormID INNER JOIN
                      dbo.Unit ON dbo.Items.UnitID = dbo.Unit.ID AND dbo. Product .TypeID = 7
UNION
SELECT DISTINCT 
                      dbo.Items.ID, ISNULL(dbo. Product .IIN, '') + ' - ' + ISNULL(dbo.Items.Strength, '') AS FullItemName, dbo. Product .IIN AS ItemName, dbo.Items.Strength, 
                      dbo.Items.ABC AS ABCID, dbo.Items.VEN AS VENID, dbo.Items.IsFree, dbo.Items.DosageFormID, NULL AS DosageForm, dbo.Items.UnitID, dbo.Unit.Unit, 
                      dbo.Items.StockCode, dbo.Items.IINID, dbo.Items.IsInHospitalList, dbo. Product .TypeID, dbo.Items.Code, dbo.Items.NeedExpiryBatch, 
                      dbo.Items.StorageTypeID, dbo.Items.NearExpiryTrigger, dbo.[Type].Name,dbo.Items.Cost
FROM         dbo.Items JOIN
                      dbo.Unit ON dbo.Items.UnitID = dbo.Unit.ID JOIN
                      dbo. Product ON dbo.Items.IINID = dbo. Product .ID AND dbo. Product .TypeID <> 7 JOIN
                      dbo.[Type] ON dbo. Product .TypeID = dbo.[Type].ID