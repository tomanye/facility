CREATE PROCEDURE [proc_Model22Delete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Model22]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END