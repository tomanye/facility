USE [MFE_DB]
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceiveDocLoadByPrimaryKey]    Script Date: 4/9/2013 1:37:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[proc_ReceiveDocLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[BatchNo],
		[ItemID],
		[SupplierID],
		[Quantity],
		[Date],
		[ExpDate],
		[Out],
		[ReceivedStatus],
		[ReceivedBy],
		[Remark],
		[StoreID],
		[LocalBatchNo],
		[RefNo],
		[Cost],
		[IsApproved],
		[QuantityLeft],
		[NoOfPack],
		[QtyPerPack],
		[EurDate],
		[ManufacturerID],
		[BoxLevel],
		[SubProgramID],
		[UnitID]
	FROM [ReceiveDoc]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END


SET ANSI_NULLS ON
