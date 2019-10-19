
DECLARE	@ParrentName VARCHAR(100)='Settings', 
		@Name VARCHAR(100)='Roles', 
        @Url VARCHAR(150)='/Settings/Security/Roles/Index', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Settings', 
		@Name VARCHAR(100)='Users', 
        @Url VARCHAR(150)='/Settings/Security/Users/Index', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Settings', 
		@Name VARCHAR(100)='Menu Access Policy', 
        @Url VARCHAR(150)='/Settings/Security/MenuAccessPolicy/Index', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Bank', 
        @Url VARCHAR(150)='/Settings/Master/Bank/Index', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO
DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Categories', 
        @Url VARCHAR(150)='/Settings/Master/Categories/Index', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Sub Cat', 
        @Url VARCHAR(150)='/Settings/Master/SubCategories/Index', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Sub Sub Cat', 
        @Url VARCHAR(150)='/Settings/Master/SubSubCategories/Index', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO


DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Price Features Master', 
        @Url VARCHAR(150)='Configurations/Master/PriceFeaturesMaster/Index', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO



/*********************service 1***********************************/

DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='Services', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='Section 1', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO





DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='Section 4', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO




DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='Section 5', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='Section 6', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='Price Mapping', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='Section 8', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

DECLARE	@ParrentName VARCHAR(100)='Service Type 1', 
		@Name VARCHAR(100)='Section 10', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

/*********************End service 1***********************************/




DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Contacts', 
        @Url VARCHAR(150)='/Settings/Master/Contact/Index', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO

