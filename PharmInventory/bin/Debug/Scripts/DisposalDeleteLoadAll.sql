Create PROCEDURE [dbo].[proc_DisposalDeleteLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[StoreId],
		[ReasonId],
		[Quantity],
		[Date],
		[ApprovedBy],
		[Losses],
		[BatchNo],
		[Remark],
		[Cost],
		[RefNo],
		[EurDate],
		[RecID]
	FROM [DisposalDelete]

	SET @Err = @@Error

	RETURN @Err
END
