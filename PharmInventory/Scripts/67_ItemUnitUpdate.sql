CREATE PROCEDURE [dbo].[proc_ItemUnitUpdate]
(
	@ID int,
	@ItemID int = NULL,
	@QtyPerUnit int = NULL,
	@Text int =null
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ItemUnit]
	SET
		[ItemID] = @ItemID,
		[QtyPerUnit] = @QtyPerUnit,
		[Text] = @Text
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END