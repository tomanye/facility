 
/****** Object:  StoredProcedure [proc_UserStoreLoadByPrimaryKey]    Script Date: 26-Jul-17 3:34:37 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_UserStoreLoadByPrimaryKey]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_UserStoreLoadByPrimaryKey];
GO

CREATE PROCEDURE [proc_UserStoreLoadByPrimaryKey]
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
		[StoreID]
	FROM [UserStore]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_UserStoreLoadByPrimaryKey Succeeded'
ELSE PRINT 'Procedure Creation: proc_UserStoreLoadByPrimaryKey Error on Creation'
GO

/****** Object:  StoredProcedure [proc_UserStoreLoadAll]    Script Date: 26-Jul-17 3:34:37 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_UserStoreLoadAll]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_UserStoreLoadAll];
GO

CREATE PROCEDURE [proc_UserStoreLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[UserID],
		[StoreID]
	FROM [UserStore]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_UserStoreLoadAll Succeeded'
ELSE PRINT 'Procedure Creation: proc_UserStoreLoadAll Error on Creation'
GO

/****** Object:  StoredProcedure [proc_UserStoreUpdate]    Script Date: 26-Jul-17 3:34:37 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_UserStoreUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_UserStoreUpdate];
GO

CREATE PROCEDURE [proc_UserStoreUpdate]
(
	@ID int,
	@UserID int,
	@StoreID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [UserStore]
	SET
		[UserID] = @UserID,
		[StoreID] = @StoreID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_UserStoreUpdate Succeeded'
ELSE PRINT 'Procedure Creation: proc_UserStoreUpdate Error on Creation'
GO




/****** Object:  StoredProcedure [proc_UserStoreInsert]    Script Date: 26-Jul-17 3:34:37 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_UserStoreInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_UserStoreInsert];
GO

CREATE PROCEDURE [proc_UserStoreInsert]
(
	@ID int = NULL output,
	@UserID int,
	@StoreID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [UserStore]
	(
		[UserID],
		[StoreID]
	)
	VALUES
	(
		@UserID,
		@StoreID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_UserStoreInsert Succeeded'
ELSE PRINT 'Procedure Creation: proc_UserStoreInsert Error on Creation'
GO

/****** Object:  StoredProcedure [proc_UserStoreDelete]    Script Date: 26-Jul-17 3:34:37 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_UserStoreDelete]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_UserStoreDelete];
GO

CREATE PROCEDURE [proc_UserStoreDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [UserStore]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_UserStoreDelete Succeeded'
ELSE PRINT 'Procedure Creation: proc_UserStoreDelete Error on Creation'
GO


