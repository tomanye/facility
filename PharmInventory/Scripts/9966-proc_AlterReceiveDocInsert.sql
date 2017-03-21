ALTER PROCEDURE [proc_ReceiveDocInsert]
(
	@ID int = NULL output,
	@BatchNo varchar(50) = NULL,
	@ItemID int = NULL,
	@SupplierID int = NULL,
	@Quantity bigint = NULL,
	@Date datetime = NULL,
	@ExpDate datetime = NULL,
	@Out bit = NULL,
	@ReceivedStatus int = NULL,
	@ReceivedBy varchar(50) = NULL,
	@Remark text = NULL,
	@StoreID int = NULL,
	@LocalBatchNo varchar(50) = NULL,
	@RefNo varchar(50) = NULL,
	@Cost float = NULL,
	@IsApproved bit = NULL,
	@ManufacturerId int = NULL,
	@QuantityLeft bigint = NULL,
	@NoOfPack int = NULL,
	@QtyPerPack int = NULL,
	@EurDate datetime = NULL,
	@BoxLevel int = NULL,
	@SubProgramID int = NULL,
	@UnitID int = NULL,
	@InternalDrugCode nvarchar(30) = NULL,
	@ItemUnit nvarchar(30) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ReceiveDoc]
	(
		[BatchNo],
		[ItemID],
		[SupplierID],
		[Quantity],
		[Date],
		[ExpDate],
		[Out],
		[ReceivedStatus],
		[ReceivedBy],
		[Remark],
		[StoreID],
		[LocalBatchNo],
		[RefNo],
		[Cost],
		[IsApproved],
		[ManufacturerId],
		[QuantityLeft],
		[NoOfPack],
		[QtyPerPack],
		[EurDate],
		[BoxLevel],
		[SubProgramID],
		[UnitID],
		[InternalDrugCode],
		[ItemUnit]
	)
	VALUES
	(
		@BatchNo,
		@ItemID,
		@SupplierID,
		@Quantity,
		@Date,
		@ExpDate,
		@Out,
		@ReceivedStatus,
		@ReceivedBy,
		@Remark,
		@StoreID,
		@LocalBatchNo,
		@RefNo,
		@Cost,
		@IsApproved,
		@ManufacturerId,
		@QuantityLeft,
		@NoOfPack,
		@QtyPerPack,
		@EurDate,
		@BoxLevel,
		@SubProgramID,
		@UnitID,
		@InternalDrugCode,
		@ItemUnit
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
