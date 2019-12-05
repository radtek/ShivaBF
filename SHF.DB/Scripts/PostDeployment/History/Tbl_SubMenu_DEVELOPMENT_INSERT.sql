


DECLARE	@Name VARCHAR(100)='Configurations', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=1, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO


DECLARE	@Name VARCHAR(100)='Dashboard', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=1, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO

DECLARE	@Name VARCHAR(100)='Masters', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=2, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO

DECLARE	@Name VARCHAR(100)='Settings', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=3, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO


DECLARE	@Name VARCHAR(100)='Service Type 1', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO

DECLARE	@Name VARCHAR(100)='Service Type 2', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO
DECLARE	@Name VARCHAR(100)='Service Type 3', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO

DECLARE	@Name VARCHAR(100)='Service Type 4', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO

DECLARE	@Name VARCHAR(100)='Service Type 5', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO


DECLARE	@Name VARCHAR(100)='Service Type 6', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO


DECLARE	@Name VARCHAR(100)='Service Type 7', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO


DECLARE	@Name VARCHAR(100)='Service Type 8', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO

DECLARE	@Name VARCHAR(100)='Blog', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO

DECLARE	@Name VARCHAR(100)='Home Page', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO


DECLARE	@Name VARCHAR(100)='Footer', 
        @Url VARCHAR(150)=NULL, 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-gears"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'


	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url] IS NULL AND SM.ParrentMenu_ID IS NULL AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END

GO
-----------------------------------------------------Configuration Parrent------------------------------------------------------


DECLARE	@ParrentName VARCHAR(100)='Configurations', 
		@Name VARCHAR(100)='Tenants', 
        @Url VARCHAR(150)='/Configurations/Master/Tenant/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=1, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO



DECLARE	@ParrentName VARCHAR(100)='Configurations', 
		@Name VARCHAR(100)='Documents', 
        @Url VARCHAR(150)='/Configurations/Document/Home/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=9, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Configurations', 
		@Name VARCHAR(100)='Navigations', 
        @Url VARCHAR(150)='/Configurations/Master/Navigation/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=10, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Configurations', 
		@Name VARCHAR(100)='Menu Access Policy', 
        @Url VARCHAR(150)='/Configurations/Security/MenuAccessPolicy/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=11, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Configurations', 
		@Name VARCHAR(100)='Message', 
        @Url VARCHAR(150)='/Configurations/Master/Message/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END		
GO

-----------------------------------------------------Configuration Parrent------------------------------------------------------


DECLARE	@ParrentName VARCHAR(100)='Settings', 
		@Name VARCHAR(100)='Roles', 
        @Url VARCHAR(150)='/Configurations/Security/Roles/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=2, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO




DECLARE	@ParrentName VARCHAR(100)='Settings', 
		@Name VARCHAR(100)='Users', 
        @Url VARCHAR(150)='/Configurations/Security/Users/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=3, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO





DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Bank', 
        @Url VARCHAR(150)='/Configurations/Master/Bank/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Categories', 
        @Url VARCHAR(150)='/Configurations/Master/Categories/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Sub Cat', 
        @Url VARCHAR(150)='/Configurations/Master/SubCategories/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Sub Sub Cat', 
        @Url VARCHAR(150)='/Configurations/Master/SubSubCategories/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='FAQ', 
        @Url VARCHAR(150)='/Configurations/Master/FAQ/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Price Features Master', 
        @Url VARCHAR(150)='/Configurations/Master/PriceFeaturesMaster/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Banner Master', 
        @Url VARCHAR(150)='/Configurations/Master/Banner/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=4, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO




/*********************service 1***********************************/

DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='S1 Services', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType1/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='S1 Section 1', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType1/Section1', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO





DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='S1 Section 4', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType1/Section4', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO




DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='S1 Section 5', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType1/Section5', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='S1 Section 6', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType1/Section6', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='S1 Price Mapping', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType1/PriceMapping', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='S1 Section 8', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType1/Section8', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='S1 Section 10', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType1/Section10', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

/*********************End service 1***********************************/

/*********************service 2***********************************/

DECLARE	@ParrentName VARCHAR(100)='Service Type 2', 
		@Name VARCHAR(100)='S2 Services', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType2/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 2', 
		@Name VARCHAR(100)='S2 Section 2', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType2/Section2', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO





DECLARE	@ParrentName VARCHAR(100)='Service Type 2', 
		@Name VARCHAR(100)='S2 Section 3', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType2/Section3', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO




DECLARE	@ParrentName VARCHAR(100)='Service Type 2', 
		@Name VARCHAR(100)='S2 Section 4', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType2/Section4', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO



/****************************End Service 2*************************/
/*********************service 3***********************************/

DECLARE	@ParrentName VARCHAR(100)='Service Type 3', 
		@Name VARCHAR(100)='S3 Services', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType3/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 3', 
		@Name VARCHAR(100)='S3 Section Heading Buttons', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType3/SectionHeadingButtons', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO





DECLARE	@ParrentName VARCHAR(100)='Service Type 3', 
		@Name VARCHAR(100)='S3 Section 4', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType3/Section4', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO




DECLARE	@ParrentName VARCHAR(100)='Service Type 3', 
		@Name VARCHAR(100)='S3 Section 6', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType3/Section6', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO



/****************************End Service 3*************************/

/*********************service 4***********************************/

DECLARE	@ParrentName VARCHAR(100)='Service Type 4', 
		@Name VARCHAR(100)='S4 Services', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType4/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 4', 
		@Name VARCHAR(100)='S4 Section 2 FAQ', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType4/Section2FAQ', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO





DECLARE	@ParrentName VARCHAR(100)='Service Type 4', 
		@Name VARCHAR(100)='S4 Section 345 Master', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType4/Section345Master', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO




DECLARE	@ParrentName VARCHAR(100)='Service Type 4', 
		@Name VARCHAR(100)='S4 Section 345 Buttons Child', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType4/Section345ButtonsChild', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 4', 
		@Name VARCHAR(100)='S4 Section 345 Features Details', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType4/Section345FeaturesDetails', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Service Type 4', 
		@Name VARCHAR(100)='S4 Section678 FieldMaster', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType4/Section678FieldMaster', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Service Type 4', 
		@Name VARCHAR(100)='S4 Section678 FieldValues', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType4/Section678FieldValues', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO
/*********************End service 4***********************************/

/*********************service 5***********************************/

DECLARE	@ParrentName VARCHAR(100)='Service Type 5', 
		@Name VARCHAR(100)='S5 Services', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType5/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 5', 
		@Name VARCHAR(100)='S5 Section 2 Master', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType5/Section2Master', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 5', 
		@Name VARCHAR(100)='S5 Section 2 Features', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType5/Section2Features', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


/*********************End service 5***********************************/


/*********************service 6***********************************/

DECLARE	@ParrentName VARCHAR(100)='Service Type 6', 
		@Name VARCHAR(100)='S6 Services', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType6/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 6', 
		@Name VARCHAR(100)='S6 Section 2 Master', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType6/Section2Master', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 6', 
		@Name VARCHAR(100)='S6 Section 2 Features', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType6/Section2Features', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


/*********************End service 6***********************************/

/*********************service 7***********************************/

DECLARE	@ParrentName VARCHAR(100)='Service Type 7', 
		@Name VARCHAR(100)='S7 Services', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType7/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO
DECLARE	@ParrentName VARCHAR(100)='Service Type 7', 
		@Name VARCHAR(100)='S7 Section HeadingButtons', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType7/SectionHeadingButtons', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO
DECLARE	@ParrentName VARCHAR(100)='Service Type 7', 
		@Name VARCHAR(100)='S7 Section 4', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType7/Section4', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 7', 
		@Name VARCHAR(100)='S7 Section 6', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType7/Section6', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


/*********************End service 7***********************************/

/*********************service 8***********************************/

DECLARE	@ParrentName VARCHAR(100)='Service Type 8', 
		@Name VARCHAR(100)='S8 Services', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType8/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 8', 
		@Name VARCHAR(100)='S8 Section HeadingButtons', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType8/SectionHeadingButtons', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 8', 
		@Name VARCHAR(100)='S8 Section 6', 
        @Url VARCHAR(150)='/Configurations/Master/ServiceType8/Section6', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


/*********************End service 8***********************************/



/*********************Home Page***********************************/

DECLARE	@ParrentName VARCHAR(100)='Home Page', 
		@Name VARCHAR(100)='HomePage Banner', 
        @Url VARCHAR(150)='/Configurations/Master/HomePage/HomePageBanner', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Home Page', 
		@Name VARCHAR(100)='Section 1', 
        @Url VARCHAR(150)='/Configurations/Master/HomePage/Section1', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Home Page', 
		@Name VARCHAR(100)='Section 2', 
        @Url VARCHAR(150)='/Configurations/Master/HomePage/Section2', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Home Page', 
		@Name VARCHAR(100)='Section 3', 
        @Url VARCHAR(150)='/Configurations/Master/HomePage/Section3', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Home Page', 
		@Name VARCHAR(100)='Section 3 Features', 
        @Url VARCHAR(150)='/Configurations/Master/HomePage/Section3Features', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Home Page', 
		@Name VARCHAR(100)='Section 4 Testimonials', 
        @Url VARCHAR(150)='/Configurations/Master/HomePage/Section4Testimonials', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Home Page', 
		@Name VARCHAR(100)='Section 4', 
        @Url VARCHAR(150)='/Configurations/Master/HomePage/Section4', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Home Page', 
		@Name VARCHAR(100)='Section 5', 
        @Url VARCHAR(150)='/Configurations/Master/HomePage/Section5', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO
/*********************End Home Page***********************************/


/**********************************Blog****************************************/


DECLARE	@ParrentName VARCHAR(100)='Blog', 
		@Name VARCHAR(100)='Blog Master', 
        @Url VARCHAR(150)='/Configurations/Master/Blog/BlogMaster', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Blog', 
		@Name VARCHAR(100)='Banner Navigations Details', 
        @Url VARCHAR(150)='/Configurations/Master/Blog/BannerNavigationsDetails', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Blog', 
		@Name VARCHAR(100)='Related Blogs Details', 
        @Url VARCHAR(150)='/Configurations/Master/Blog/RelatedBlogsDetails', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Blog', 
		@Name VARCHAR(100)='Blog Comments Details', 
        @Url VARCHAR(150)='/Configurations/Master/Blog/BlogCommentsDetails', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Blog', 
		@Name VARCHAR(100)='Comments Reply', 
        @Url VARCHAR(150)='/Configurations/Master/Blog/CommentsReply', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO
/*********************End Home Page***********************************/

/**********************************Footer****************************************/


DECLARE	@ParrentName VARCHAR(100)='Footer', 
		@Name VARCHAR(100)='Footer Block Master', 
        @Url VARCHAR(150)='/Configurations/Master/Footer/FooterBlockMaster', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Footer', 
		@Name VARCHAR(100)='Footer Links Details', 
        @Url VARCHAR(150)='/Configurations/Master/Footer/FooterLinksDetails', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO
/**************************************************Footer End*******************************************************/

DECLARE	@ParrentName VARCHAR(100)='Dashboard', 
		@Name VARCHAR(100)='Visited IP', 
        @Url VARCHAR(150)='/Configurations/Master/Dashboard/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Dashboard', 
		@Name VARCHAR(100)='Page Views Report', 
        @Url VARCHAR(150)='/Configurations/Master/PageViewsReport/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Dashboard', 
		@Name VARCHAR(100)='Customer', 
        @Url VARCHAR(150)='/Configurations/Master/Customer/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Dashboard', 
		@Name VARCHAR(100)='Customer Login Info', 
        @Url VARCHAR(150)='/Configurations/Master/CustomerInfo/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Dashboard', 
		@Name VARCHAR(100)='Customer IP Info Mapping', 
        @Url VARCHAR(150)='/Configurations/Master/CustomerIPInfoMapping/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Dashboard', 
		@Name VARCHAR(100)='Customer Surfing', 
        @Url VARCHAR(150)='/Configurations/Master/CustomerSurfing/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Dashboard', 
		@Name VARCHAR(100)='Customer Orders', 
        @Url VARCHAR(150)='/Configurations/Master/CustomerOrders/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Dashboard', 
		@Name VARCHAR(100)='Customer Payment', 
        @Url VARCHAR(150)='/Configurations/Master/CustomerPayment/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=8, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


/**************************************************Dashboard End*******************************************************/

