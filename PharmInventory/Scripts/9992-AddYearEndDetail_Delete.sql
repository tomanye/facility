 

CREATE PROCEDURE [dbo].[proc_YearEndDetailDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [YearEndDetail]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
