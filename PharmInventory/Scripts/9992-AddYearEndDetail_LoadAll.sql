CREATE PROCEDURE [proc_YearEndDetailLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[YearEndID],
		[ReceiveDocID],
		[Quantity]
	FROM [YearEndDetail]

	SET @Err = @@Error

	RETURN @Err
END