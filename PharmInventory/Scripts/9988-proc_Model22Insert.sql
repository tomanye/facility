CREATE PROCEDURE [proc_Model22Insert]
(
	@ID int = NULL output,
	@IssueDocID int,
	@PackQty int = NULL,
	@QtyPerPack decimal(18,0) = NULL,
	@PackPrice decimal(16,4) = NULL,
	@TotalPrice decimal(16,4) = NULL,
	@TotalPackSellingPrice decimal(16,4) = NULL,
	@priceRate decimal(16,4) = NULL
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
		[priceRate]
	)
	VALUES
	(
		@IssueDocID,
		@PackQty,
		@QtyPerPack,
		@PackPrice,
		@TotalPrice,
		@TotalPackSellingPrice,
		@priceRate
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END