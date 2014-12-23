USE [DECHATUHCDB]
GO

/****** Object:  StoredProcedure [dbo].[proc_ProgramProductUpdate]    Script Date: 12/23/2014 12:17:50 PM ******/
DROP PROCEDURE [dbo].[proc_ProgramProductUpdate]
GO

/****** Object:  StoredProcedure [dbo].[proc_ProgramProductLoadByPrimaryKey]    Script Date: 12/23/2014 12:17:50 PM ******/
DROP PROCEDURE [dbo].[proc_ProgramProductLoadByPrimaryKey]
GO

/****** Object:  StoredProcedure [dbo].[proc_ProgramProductLoadAll]    Script Date: 12/23/2014 12:17:50 PM ******/
DROP PROCEDURE [dbo].[proc_ProgramProductLoadAll]
GO

/****** Object:  StoredProcedure [dbo].[proc_ProgramProductInsert]    Script Date: 12/23/2014 12:17:50 PM ******/
DROP PROCEDURE [dbo].[proc_ProgramProductInsert]
GO

/****** Object:  StoredProcedure [dbo].[proc_ProgramProductDelete]    Script Date: 12/23/2014 12:17:50 PM ******/
DROP PROCEDURE [dbo].[proc_ProgramProductDelete]
GO

/****** Object:  StoredProcedure [dbo].[proc_ProgramProductDelete]    Script Date: 12/23/2014 12:17:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_ProgramProductDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ProgramProduct]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END

GO

/****** Object:  StoredProcedure [dbo].[proc_ProgramProductInsert]    Script Date: 12/23/2014 12:17:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_ProgramProductInsert]
(
	@ID int = NULL output,
	@StoreID int = NULL,
	@ProgramID int = NULL,
	@ItemID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ProgramProduct]
	(
		[StoreID],
		[ProgramID],
		[ItemID]
	)
	VALUES
	(
		@StoreID,
		@ProgramID,
		@ItemID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END

GO

/****** Object:  StoredProcedure [dbo].[proc_ProgramProductLoadAll]    Script Date: 12/23/2014 12:17:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_ProgramProductLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[StoreID],
		[ProgramID],
		[ItemID]
	FROM [ProgramProduct]

	SET @Err = @@Error

	RETURN @Err
END

GO

/****** Object:  StoredProcedure [dbo].[proc_ProgramProductLoadByPrimaryKey]    Script Date: 12/23/2014 12:17:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_ProgramProductLoadByPrimaryKey]
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
		[ProgramID],
		[ItemID]
	FROM [ProgramProduct]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END

GO

/****** Object:  StoredProcedure [dbo].[proc_ProgramProductUpdate]    Script Date: 12/23/2014 12:17:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_ProgramProductUpdate]
(
	@ID int,
	@StoreID int = NULL,
	@ProgramID int = NULL,
	@ItemID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ProgramProduct]
	SET
		[StoreID] = @StoreID,
		[ProgramID] = @ProgramID,
		[ItemID] = @ItemID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END

GO


