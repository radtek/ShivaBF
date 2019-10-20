
IF NOT EXISTS(SELECT 1 FROM dbo.AspNetRoles WITH(NOLOCK) WHERE Display_Name='Development')
BEGIN
	INSERT INTO [dbo].[AspNetRoles] ([Display_Name],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq],[Name])
     VALUES('Development','dbo',GetDate(),'dbo',GetDate(),1,0,0,'DEVLOPMENT')
END
GO

IF NOT EXISTS(SELECT 1 FROM dbo.AspNetRoles WITH(NOLOCK) WHERE Display_Name='Support')
BEGIN
	INSERT INTO [dbo].[AspNetRoles] ([Display_Name],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq],[Name])
     VALUES('Support','dbo',GetDate(),'dbo',GetDate(),1,0,0,'SUPPORT')
END
GO

--IF NOT EXISTS(SELECT 1 FROM dbo.AspNetRoles WITH(NOLOCK) WHERE Display_Name='Admin')
--BEGIN
--	INSERT INTO [dbo].[AspNetRoles] ([Display_Name],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq],[Name])
--     VALUES('Admin','dbo',GetDate(),'dbo',GetDate(),1,0,0,'Admin')
--END
--GO



