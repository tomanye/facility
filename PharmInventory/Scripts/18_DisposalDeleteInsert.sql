
CREATE PROCEDURE [dbo].[proc_DisposalDeleteInsert]
(
    @ID int= NULL OUTPUT,
	@ItemID int = NULL,
	@StoreId int = NULL,
	@ReasonId int = NULL,
	@Quantity bigint = NULL,
	@Date datetime = NULL,
	@ApprovedBy varchar(50) = NULL,
	@Losses bit = NULL,
	@BatchNo varchar(50) = NULL,
	@Remark text = NULL,
	@Cost float = NULL,
	@RefNo varchar(50) = NULL,
	@EurDate datetime = NULL,
	@RecID int = NULL
	
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [DisposalDelete]
	(
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
		)
	VALUES
	(
	    @ID,
		@ItemID,
		@StoreId,
		@ReasonId,
		@Quantity,
		@Date,
		@ApprovedBy,
		@Losses,
		@BatchNo,
		@Remark,
		@Cost,
		@RefNo,
		@EurDate,
		@RecID
		
	)

	SET @Err = @@Error

	SELECT @ID =SCOPE_IDENTITY()
	
	RETURN @Err
END
