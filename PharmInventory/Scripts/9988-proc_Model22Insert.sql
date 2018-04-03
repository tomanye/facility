CREATE PROCEDURE [proc_Model22Insert]
(
	@ID int = NULL output,
	@IssueDocID int,
	@PackQty decimal(18,0) = NULL,
	@QtyPerPack decimal(18,0) = NULL,
	@PackPrice decimal(16,4) = NULL,
	@TotalPrice decimal(16,4) = NULL,
	@TotalPackSellingPrice decimal(16,4) = NULL,
	@priceRate decimal(16,4) = NULL,
	@PackSellingPrice decimal(16,4) = NULL,
	@UnitSellingPrice decimal(16,4) = NULL,
	@ExpiryDate datetime = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Model22]
	(
		[IssueDocID],
		[PackQty],
		[QtyPerPack],
		[PackPrice],
		[TotalPrice],
		[TotalPackSellingPrice],
		[priceRate],	[PackSellingPrice],
		[UnitSellingPrice],[ExpiryDate]
	)
	VALUES
	(
		@IssueDocID,
		@PackQty,
		@QtyPerPack,
		@PackPrice,
		@TotalPrice,
		@TotalPackSellingPrice,
		@priceRate,
		@PackSellingPrice,
		@UnitSellingPrice,
		@ExpiryDate
)
	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END