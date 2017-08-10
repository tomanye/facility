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
 

