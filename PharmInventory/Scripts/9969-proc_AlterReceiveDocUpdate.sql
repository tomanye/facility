ALTER PROCEDURE [proc_ReceiveDocUpdate]
(
	@ID int,
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

	UPDATE [ReceiveDoc]
	SET
		[BatchNo] = @BatchNo,
		[ItemID] = @ItemID,
		[SupplierID] = @SupplierID,
		[Quantity] = @Quantity,
		[Date] = @Date,
		[ExpDate] = @ExpDate,
		[Out] = @Out,
		[ReceivedStatus] = @ReceivedStatus,
		[ReceivedBy] = @ReceivedBy,
		[Remark] = @Remark,
		[StoreID] = @StoreID,
		[LocalBatchNo] = @LocalBatchNo,
		[RefNo] = @RefNo,
		[Cost] = @Cost,
		[IsApproved] = @IsApproved,
		[ManufacturerId] = @ManufacturerId,
		[QuantityLeft] = @QuantityLeft,
		[NoOfPack] = @NoOfPack,
		[QtyPerPack] = @QtyPerPack,
		[EurDate] = @EurDate,
		[BoxLevel] = @BoxLevel,
		[SubProgramID] = @SubProgramID,
		[UnitID] = @UnitID,
		[InternalDrugCode] = @InternalDrugCode,
		[ItemUnit] = @ItemUnit
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
