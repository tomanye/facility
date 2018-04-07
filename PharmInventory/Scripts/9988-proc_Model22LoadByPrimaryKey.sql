CREATE PROCEDURE [proc_Model22LoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[IssueDocID],
		[PackQty],
		[QtyPerPack],
		[PackPrice],
		[TotalPrice],
		[TotalPackSellingPrice],
		[priceRate],
		[PackSellingPrice],
		[UnitSellingPrice],
		[ExpiryDate],
		[IssuedBy]
	FROM [Model22]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
