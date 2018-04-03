CREATE PROCEDURE [proc_Model22Update]
(
    @ID int,
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

	UPDATE [Model22]
	SET
		[IssueDocID] = @IssueDocID,
		[PackQty] = @PackQty,
		[QtyPerPack] = @QtyPerPack,
		[PackPrice] = @PackPrice,
		[TotalPrice] = @TotalPrice,
		[TotalPackSellingPrice] = @TotalPackSellingPrice,
		[priceRate] = @priceRate,
	    [PackSellingPrice] = @PackSellingPrice,
		[UnitSellingPrice] = @UnitSellingPrice,
		[ExpiryDate] = @ExpiryDate  
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END