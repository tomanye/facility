ALTER PROCEDURE [proc_ItemsLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[StockCode],
		[Strength],
		[DosageFormID],
		[UnitID],
		[VEN],
		[ABC],
		[IsFree],
		[IsDiscontinued],
		[Cost],
		[EDL],
		[Refrigeratored],
		[Pediatric],
		[IINID],
		[IsInHospitalList],
		[NeedExpiryBatch],
		[Code],
		[StockCodeDACA],
		[NearExpiryTrigger],
		[StorageTypeID],
		[DSItemID],
		[isPFSAVital]
	FROM [Items]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
 