
/****** Object:  View [dbo].[vwGetAllItems]    Script Date: 12/21/2011 12:21:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[vwGetAllItems]
AS
SELECT DISTINCT 
					  dbo.Items.ID, ISNULL(dbo.Product.IIN, '') + ' - ' + ISNULL(dbo.DosageForm.Form, '') + ' - ' + ISNULL(dbo.Items.Strength, '') AS FullItemName, 
					  dbo.Product.IIN AS ItemName, dbo.Product.ATC, dbo.Items.Strength, dbo.Items.ABC AS ABCID, dbo.ABC.Value AS ABC, dbo.VEN.Value AS VEN, 
					  dbo.Items.VEN AS VENID, dbo.Items.IsFree, dbo.Items.IsDiscontinued, dbo.Items.EDL, dbo.Items.Refrigeratored, dbo.Items.Pediatric, dbo.Items.DosageFormID, 
					  dbo.DosageForm.Form AS DosageForm, dbo.Items.UnitID, dbo.Unit.Unit, dbo.Items.StockCode, dbo.Items.IINID, dbo.Items.IsInHospitalList, dbo.Product.TypeID, 
					  dbo.Type.Name, dbo.Items.StockCodeDACA, dbo.Items.Code, dbo.Items.NeedExpiryBatch, dbo.Items.StorageTypeID, 
					  dbo.Items.NearExpiryTrigger, dbo.SubCategory.CategoryId, dbo.ProductsCategory.SubCategoryID
FROM				  
					  dbo.Product join dbo.Items ON dbo.Items.IINID = dbo.Product.ID INNER JOIN
					  dbo.DosageForm  ON dbo.DosageForm.ID = dbo.Items.DosageFormID left JOIN
					  dbo.ABC ON  dbo.Items.ABC =dbo.ABC.ID left JOIN
					  dbo.VEN ON dbo.Items.VEN = dbo.VEN.ID INNER JOIN
					  dbo.Unit ON dbo.Items.UnitID = dbo.Unit.ID INNER JOIN
					  dbo.[Type] ON dbo.Product.TypeID = dbo.Type.ID left JOIN
					  dbo.ProductsCategory ON dbo.Items.ID = dbo.ProductsCategory.ItemId INNER JOIN
					  dbo.SubCategory ON dbo.ProductsCategory.SubCategoryID = dbo.SubCategory.ID AND (dbo.Product.TypeID = 1 or dbo.Product.TypeID = 7)

Union  
SELECT DISTINCT 
					  dbo.Items.ID, ISNULL(dbo.Product.IIN, '') + ' - ' + ISNULL(dbo.Items.Strength, '') AS FullItemName, 
					  dbo.Product.IIN AS ItemName, dbo.Product.ATC, dbo.Items.Strength, dbo.Items.ABC AS ABCID, null AS ABC, null AS VEN, 
					  dbo.Items.VEN AS VENID, dbo.Items.IsFree, dbo.Items.IsDiscontinued, dbo.Items.EDL, dbo.Items.Refrigeratored, dbo.Items.Pediatric, dbo.Items.DosageFormID, 
					  null AS DosageForm, dbo.Items.UnitID, dbo.Unit.Unit, dbo.Items.StockCode, dbo.Items.IINID, dbo.Items.IsInHospitalList, dbo.Product.TypeID, 
					  dbo.Type.Name, dbo.Items.StockCodeDACA, dbo.Items.Code, dbo.Items.NeedExpiryBatch, dbo.Items.StorageTypeID, 
					  dbo.Items.NearExpiryTrigger,dbo.SupplyCategory.ParentId as CategoryID ,dbo.ItemSupplyCategory.CategoryID as SubCategoryID 
FROM        
					  dbo.Items   JOIN
				
					  dbo.Unit ON dbo.Items.UnitID = dbo.Unit.ID  JOIN
					  dbo.Product ON dbo.Items.IINID = dbo.Product.ID inner JOIN
					  dbo.Type ON dbo.Product.TypeID = dbo.Type.ID inner JOIN
					  dbo.ItemSupplyCategory ON dbo.Items.ID = dbo.ItemSupplyCategory.ItemID inner JOIN
					 dbo.SupplyCategory on dbo.ItemSupplyCategory.CategoryID = dbo.SupplyCategory.ID 
					 and (dbo.Product.TypeID <> 1 and dbo.Product.TypeID <> 7)

GO