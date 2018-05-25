CREATE PROCEDURE [proc_YearEndDetailLoadByPrimaryKey]
(
	@ID int
)
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
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END