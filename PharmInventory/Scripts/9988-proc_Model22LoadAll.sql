CREATE PROCEDURE [proc_Model22LoadAll]
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
		[priceRate]
	FROM [Model22]

	SET @Err = @@Error

	RETURN @Err
END