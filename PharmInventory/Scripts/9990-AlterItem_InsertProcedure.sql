
ALTER PROCEDURE [proc_ItemsInsert]
(
	@ID int = NULL output,
	@StockCode varchar(50) = NULL,
	@Strength varchar(1500) = NULL,
	@DosageFormID int = NULL,
	@UnitID int = NULL,
	@VEN int = NULL,
	@ABC int = NULL,
	@IsFree bit = NULL,
	@IsDiscontinued bit = NULL,
	@Cost varchar(50) = NULL,
	@EDL bit = NULL,
	@Refrigeratored bit = NULL,
	@Pediatric bit = NULL,
	@IINID int = NULL,
	@IsInHospitalList bit = NULL,
	@NeedExpiryBatch bit = NULL,
	@Code varchar(50) = NULL,
	@StockCodeDACA varchar(50) = NULL,
	@NearExpiryTrigger float = NULL,
	@StorageTypeID int = NULL,
	@DSItemID int = NULL,
	@isPFSAVital bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Items]
	(
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
	)
	VALUES
	(
		@StockCode,
		@Strength,
		@DosageFormID,
		@UnitID,
		@VEN,
		@ABC,
		@IsFree,
		@IsDiscontinued,
		@Cost,
		@EDL,
		@Refrigeratored,
		@Pediatric,
		@IINID,
		@IsInHospitalList,
		@NeedExpiryBatch,
		@Code,
		@StockCodeDACA,
		@NearExpiryTrigger,
		@StorageTypeID,
		@DSItemID,
		@isPFSAVital
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
