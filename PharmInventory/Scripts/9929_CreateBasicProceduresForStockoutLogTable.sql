
/****** Object:  StoredProcedure [dbo].[proc_StockoutLogDelete]    Script Date: 10/7/2014 9:50:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_StockoutLogDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [StockoutLog]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END

GO

/****** Object:  StoredProcedure [dbo].[proc_StockoutLogInsert]    Script Date: 10/7/2014 9:50:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_StockoutLogInsert]
(
	@ID int = NULL output,
	@StoreID int = NULL,
	@ItemID int,
	@StartDate datetime,
	@EndDate datetime = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [StockoutLog]
	(
		[StoreID],
		[ItemID],
		[StartDate],
		[EndDate]
	)
	VALUES
	(
		@StoreID,
		@ItemID,
		@StartDate,
		@EndDate
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END

GO

/****** Object:  StoredProcedure [dbo].[proc_StockoutLogUpdate]    Script Date: 10/7/2014 9:50:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_StockoutLogUpdate]
(
	@ID int,
	@StoreID int = NULL,
	@ItemID int,
	@StartDate datetime,
	@EndDate datetime = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [StockoutLog]
	SET
		[StoreID] = @StoreID,
		[ItemID] = @ItemID,
		[StartDate] = @StartDate,
		[EndDate] = @EndDate
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END

GO

/****** Object:  StoredProcedure [dbo].[proc_StockoutLogLoadAll]    Script Date: 10/7/2014 9:50:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_StockoutLogLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[StoreID],
		[ItemID],
		[StartDate],
		[EndDate]
	FROM [StockoutLog]

	SET @Err = @@Error

	RETURN @Err
END

GO

/****** Object:  StoredProcedure [dbo].[proc_StockoutLogLoadByPrimaryKey]    Script Date: 10/7/2014 9:50:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_StockoutLogLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[StoreID],
		[ItemID],
		[StartDate],
		[EndDate]
	FROM [StockoutLog]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END

GO


