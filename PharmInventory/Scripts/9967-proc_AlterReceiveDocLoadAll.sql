ALTER PROCEDURE [proc_ReceiveDocLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
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
	FROM [ReceiveDoc]

	SET @Err = @@Error

	RETURN @Err
END
