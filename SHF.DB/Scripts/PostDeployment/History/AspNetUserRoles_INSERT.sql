DECLARE @UserID INT, @RoleID INT
SELECT @UserID=Id FROM [dbo].[AspNetUsers] WITH(NOLOCK) WHERE UserName='delmon.vikram'
SELECT @RoleID=Id FROM [dbo].[AspNetRoles] WITH(NOLOCK) WHERE [Name]='DEVLOPMENT'
IF NOT EXISTS(SELECT 1 FROM [dbo].[AspNetUserRoles] WITH(NOLOCK) WHERE [UserId]=@UserID AND [RoleId]=@RoleID)
BEGIN
	INSERT INTO [dbo].[AspNetUserRoles]([UserId],[RoleId],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq])
    VALUES(@UserID,@RoleID,'dbo',GetDate(),'dbo',GetDate(),1,0,0)
END
GO


DECLARE @UserID INT, @RoleID INT
SELECT @UserID=Id FROM [dbo].[AspNetUsers] WITH(NOLOCK) WHERE UserName='atul009'
SELECT @RoleID=Id FROM [dbo].[AspNetRoles] WITH(NOLOCK) WHERE [Name]='DEVLOPMENT'
IF NOT EXISTS(SELECT 1 FROM [dbo].[AspNetUserRoles] WITH(NOLOCK) WHERE [UserId]=@UserID AND [RoleId]=@RoleID)
BEGIN
	INSERT INTO [dbo].[AspNetUserRoles]([UserId],[RoleId],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq])
    VALUES(@UserID,@RoleID,'dbo',GetDate(),'dbo',GetDate(),1,0,0)
END
GO



DECLARE @UserID INT, @RoleID INT
SELECT @UserID=Id FROM [dbo].[AspNetUsers] WITH(NOLOCK) WHERE UserName='delmon'
SELECT @RoleID=Id FROM [dbo].[AspNetRoles] WITH(NOLOCK) WHERE [Name]='DEVLOPMENT'
IF NOT EXISTS(SELECT 1 FROM [dbo].[AspNetUserRoles] WITH(NOLOCK) WHERE [UserId]=@UserID AND [RoleId]=@RoleID)
BEGIN
	INSERT INTO [dbo].[AspNetUserRoles]([UserId],[RoleId],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq])
    VALUES(@UserID,@RoleID,'dbo',GetDate(),'dbo',GetDate(),1,0,0)
END
GO

DECLARE @UserID INT, @RoleID INT
SELECT @UserID=Id FROM [dbo].[AspNetUsers] WITH(NOLOCK) WHERE UserName='delmon.ajinath'
SELECT @RoleID=Id FROM [dbo].[AspNetRoles] WITH(NOLOCK) WHERE [Name]='DEVLOPMENT'
IF NOT EXISTS(SELECT 1 FROM [dbo].[AspNetUserRoles] WITH(NOLOCK) WHERE [UserId]=@UserID AND [RoleId]=@RoleID)
BEGIN
	INSERT INTO [dbo].[AspNetUserRoles]([UserId],[RoleId],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq])
    VALUES(@UserID,@RoleID,'dbo',GetDate(),'dbo',GetDate(),1,0,0)
END
GO



DECLARE @UserID INT, @RoleID INT
SELECT @UserID=Id FROM [dbo].[AspNetUsers] WITH(NOLOCK) WHERE UserName='delmon'
SELECT @RoleID=Id FROM [dbo].[AspNetRoles] WITH(NOLOCK) WHERE [Name]='DEVLOPMENT'
IF NOT EXISTS(SELECT 1 FROM [dbo].[AspNetUserRoles] WITH(NOLOCK) WHERE [UserId]=@UserID AND [RoleId]=@RoleID)
BEGIN
	INSERT INTO [dbo].[AspNetUserRoles]([UserId],[RoleId],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq])
    VALUES(@UserID,@RoleID,'dbo',GetDate(),'dbo',GetDate(),1,0,0)
END
GO

DECLARE @UserID INT, @RoleID INT
SELECT @UserID=Id FROM [dbo].[AspNetUsers] WITH(NOLOCK) WHERE UserName='delmon.snehal'
SELECT @RoleID=Id FROM [dbo].[AspNetRoles] WITH(NOLOCK) WHERE [Name]='DEVLOPMENT'
IF NOT EXISTS(SELECT 1 FROM [dbo].[AspNetUserRoles] WITH(NOLOCK) WHERE [UserId]=@UserID AND [RoleId]=@RoleID)
BEGIN
	INSERT INTO [dbo].[AspNetUserRoles]([UserId],[RoleId],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq])
    VALUES(@UserID,@RoleID,'dbo',GetDate(),'dbo',GetDate(),1,0,0)
END
GO