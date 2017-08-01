 

/****** Object:  StoredProcedure [proc_UserCommodityTypeLoadByPrimaryKey]    Script Date: 26-Jul-17 3:33:58 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_UserCommodityTypeLoadByPrimaryKey]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_UserCommodityTypeLoadByPrimaryKey];
GO

CREATE PROCEDURE [proc_UserCommodityTypeLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[UserID],
		[TypeID]
	FROM [UserCommodityType]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_UserCommodityTypeLoadByPrimaryKey Succeeded'
ELSE PRINT 'Procedure Creation: proc_UserCommodityTypeLoadByPrimaryKey Error on Creation'
GO

/****** Object:  StoredProcedure [proc_UserCommodityTypeLoadAll]    Script Date: 26-Jul-17 3:33:58 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_UserCommodityTypeLoadAll]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_UserCommodityTypeLoadAll];
GO

CREATE PROCEDURE [proc_UserCommodityTypeLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[UserID],
		[TypeID]
	FROM [UserCommodityType]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_UserCommodityTypeLoadAll Succeeded'
ELSE PRINT 'Procedure Creation: proc_UserCommodityTypeLoadAll Error on Creation'
GO

/****** Object:  StoredProcedure [proc_UserCommodityTypeUpdate]    Script Date: 26-Jul-17 3:33:58 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_UserCommodityTypeUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_UserCommodityTypeUpdate];
GO

CREATE PROCEDURE [proc_UserCommodityTypeUpdate]
(
	@ID int,
	@UserID int,
	@TypeID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [UserCommodityType]
	SET
		[UserID] = @UserID,
		[TypeID] = @TypeID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_UserCommodityTypeUpdate Succeeded'
ELSE PRINT 'Procedure Creation: proc_UserCommodityTypeUpdate Error on Creation'
GO




/****** Object:  StoredProcedure [proc_UserCommodityTypeInsert]    Script Date: 26-Jul-17 3:33:58 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_UserCommodityTypeInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_UserCommodityTypeInsert];
GO

CREATE PROCEDURE [proc_UserCommodityTypeInsert]
(
	@ID int = NULL output,
	@UserID int,
	@TypeID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [UserCommodityType]
	(
		[UserID],
		[TypeID]
	)
	VALUES
	(
		@UserID,
		@TypeID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_UserCommodityTypeInsert Succeeded'
ELSE PRINT 'Procedure Creation: proc_UserCommodityTypeInsert Error on Creation'
GO

/****** Object:  StoredProcedure [proc_UserCommodityTypeDelete]    Script Date: 26-Jul-17 3:33:58 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_UserCommodityTypeDelete]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_UserCommodityTypeDelete];
GO

CREATE PROCEDURE [proc_UserCommodityTypeDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [UserCommodityType]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_UserCommodityTypeDelete Succeeded'
ELSE PRINT 'Procedure Creation: proc_UserCommodityTypeDelete Error on Creation'
GO


