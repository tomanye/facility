CREATE PROCEDURE [proc_YearEndDetailInsert]
(
	@ID int = NULL output,
	@YearEndID int = NULL,
	@ReceiveDocID int = NULL,
	@Quantity bigint = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [YearEndDetail]
	(
		[YearEndID],
		[ReceiveDocID],
		[Quantity]
	)
	VALUES
	(
		@YearEndID,
		@ReceiveDocID,
		@Quantity
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END