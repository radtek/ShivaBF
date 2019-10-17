

DECLARE @Email NVARCHAR(256)='vikram.pawar@live.com', @UserName NVARCHAR(256)='delmon.vikram', @PhoneNumber NVARCHAR(MAX)='7588594795', @FirstName NVARCHAR(MAX)='Vikram', @LastName NVARCHAR(MAX)='Pawar',
		@PasswordHash NVARCHAR(MAX)='ADBLPNujMcaLOnRl5vtnXvyUToHYnWJskmrJU5XKIDxs0KIgzfFTyd9ucNXkASjKdw==',@SecurityStamp NVARCHAR(MAX)='bb9b5bee-5196-4654-b57b-1710e8aa9366'
		--Sai@123
IF NOT EXISTS(SELECT 1 FROM dbo.AspNetUsers WITH(NOLOCK) WHERE UserName=@UserName)
BEGIN
	INSERT INTO [dbo].[AspNetUsers]
           ([Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq],[Email],[EmailConfirmed],[PasswordHash],[SecurityStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnabled],[UserName],[First_Name],[Last_Name],[AccessFailedCount])
    VALUES('dbo',GetDate(),'dbo',GetDate(),1,0,0,@Email,1,@PasswordHash,@SecurityStamp,@PhoneNumber,1,0,0,@UserName,@FirstName,@LastName,0)
END
GO


DECLARE @Email NVARCHAR(256)='atul.sharma@delmonsolutions.com', @UserName NVARCHAR(256)='atul009', @PhoneNumber NVARCHAR(MAX)='9112884369', @FirstName NVARCHAR(MAX)='Atul', @LastName NVARCHAR(MAX)='Sharma',
		@PasswordHash NVARCHAR(MAX)='ADBLPNujMcaLOnRl5vtnXvyUToHYnWJskmrJU5XKIDxs0KIgzfFTyd9ucNXkASjKdw==',@SecurityStamp NVARCHAR(MAX)='bb9b5bee-5196-4654-b57b-1710e8aa9366'
		--Sai@123
IF NOT EXISTS(SELECT 1 FROM dbo.AspNetUsers WITH(NOLOCK) WHERE UserName=@UserName)
BEGIN
	INSERT INTO [dbo].[AspNetUsers]
           ([Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq],[Email],[EmailConfirmed],[PasswordHash],[SecurityStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnabled],[UserName],[First_Name],[Last_Name],[AccessFailedCount])
    VALUES('dbo',GetDate(),'dbo',GetDate(),1,0,0,@Email,1,@PasswordHash,@SecurityStamp,@PhoneNumber,1,0,0,@UserName,@FirstName,@LastName,0)
END
GO


DECLARE @Email NVARCHAR(256)='user.user@delmonsolutions.com', @UserName NVARCHAR(256)='delmon', @PhoneNumber NVARCHAR(MAX)='9112884369', @FirstName NVARCHAR(MAX)='User', @LastName NVARCHAR(MAX)='User',
		@PasswordHash NVARCHAR(MAX)='ADBLPNujMcaLOnRl5vtnXvyUToHYnWJskmrJU5XKIDxs0KIgzfFTyd9ucNXkASjKdw==',@SecurityStamp NVARCHAR(MAX)='bb9b5bee-5196-4654-b57b-1710e8aa9366'
		--Sai@123
IF NOT EXISTS(SELECT 1 FROM dbo.AspNetUsers WITH(NOLOCK) WHERE UserName=@UserName)
BEGIN
	INSERT INTO [dbo].[AspNetUsers]
           ([Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq],[Email],[EmailConfirmed],[PasswordHash],[SecurityStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnabled],[UserName],[First_Name],[Last_Name],[AccessFailedCount])
    VALUES('dbo',GetDate(),'dbo',GetDate(),1,0,0,@Email,1,@PasswordHash,@SecurityStamp,@PhoneNumber,1,0,0,@UserName,@FirstName,@LastName,0)
END
GO


DECLARE @Email NVARCHAR(256)='ajinath.kashid@delmonsolutions.com', @UserName NVARCHAR(256)='delmon.ajinath', @PhoneNumber NVARCHAR(MAX)='9527236565', @FirstName NVARCHAR(MAX)='Ajinath', @LastName NVARCHAR(MAX)='Kashid',
		@PasswordHash NVARCHAR(MAX)='ADBLPNujMcaLOnRl5vtnXvyUToHYnWJskmrJU5XKIDxs0KIgzfFTyd9ucNXkASjKdw==',@SecurityStamp NVARCHAR(MAX)='bb9b5bee-5196-4654-b57b-1710e8aa9366'
		--Sai@123
IF NOT EXISTS(SELECT 1 FROM dbo.AspNetUsers WITH(NOLOCK) WHERE UserName=@UserName)
BEGIN
	INSERT INTO [dbo].[AspNetUsers]
           ([Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq],[Email],[EmailConfirmed],[PasswordHash],[SecurityStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnabled],[UserName],[First_Name],[Last_Name],[AccessFailedCount])
    VALUES('dbo',GetDate(),'dbo',GetDate(),1,0,0,@Email,1,@PasswordHash,@SecurityStamp,@PhoneNumber,1,0,0,@UserName,@FirstName,@LastName,0)
END
GO



DECLARE @Email NVARCHAR(256)='snehal.jangade@delmonsolutions.com', @UserName NVARCHAR(256)='delmon.snehal', @PhoneNumber NVARCHAR(MAX)='9130948588', @FirstName NVARCHAR(MAX)='Snehal', @LastName NVARCHAR(MAX)='Jangade',
		@PasswordHash NVARCHAR(MAX)='ADBLPNujMcaLOnRl5vtnXvyUToHYnWJskmrJU5XKIDxs0KIgzfFTyd9ucNXkASjKdw==',@SecurityStamp NVARCHAR(MAX)='bb9b5bee-5196-4654-b57b-1710e8aa9366'
		--Sai@123
IF NOT EXISTS(SELECT 1 FROM dbo.AspNetUsers WITH(NOLOCK) WHERE UserName=@UserName)
BEGIN
	INSERT INTO [dbo].[AspNetUsers]
           ([Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq],[Email],[EmailConfirmed],[PasswordHash],[SecurityStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnabled],[UserName],[First_Name],[Last_Name],[AccessFailedCount])
    VALUES('dbo',GetDate(),'dbo',GetDate(),1,0,0,@Email,1,@PasswordHash,@SecurityStamp,@PhoneNumber,1,0,0,@UserName,@FirstName,@LastName,0)
END
GO

DECLARE @Email NVARCHAR(256)='user.user@shivabusinessfilings.com', @UserName NVARCHAR(256)='shivabf', @PhoneNumber NVARCHAR(MAX)='9112884369', @FirstName NVARCHAR(MAX)='User', @LastName NVARCHAR(MAX)='User',
		@PasswordHash NVARCHAR(MAX)='ADBLPNujMcaLOnRl5vtnXvyUToHYnWJskmrJU5XKIDxs0KIgzfFTyd9ucNXkASjKdw==',@SecurityStamp NVARCHAR(MAX)='bb9b5bee-5196-4654-b57b-1710e8aa9366'
		--Sai@123
IF NOT EXISTS(SELECT 1 FROM dbo.AspNetUsers WITH(NOLOCK) WHERE UserName=@UserName)
BEGIN
	INSERT INTO [dbo].[AspNetUsers]
           ([Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq],[Email],[EmailConfirmed],[PasswordHash],[SecurityStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnabled],[UserName],[First_Name],[Last_Name],[AccessFailedCount])
    VALUES('dbo',GetDate(),'dbo',GetDate(),1,0,0,@Email,1,@PasswordHash,@SecurityStamp,@PhoneNumber,1,0,0,@UserName,@FirstName,@LastName,0)
END
GO