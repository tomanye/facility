 
CREATE PROCEDURE [proc_YearEndDetailUpdate]
(
	@ID int,
	@YearEndID int = NULL,
	@ReceiveDocID int = NULL,
	@Quantity bigint = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [YearEndDetail]
	SET
		[YearEndID] = @YearEndID,
		[ReceiveDocID] = @ReceiveDocID,
		[Quantity] = @Quantity
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END