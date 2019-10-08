


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


DECLARE	@Name VARCHAR(100)='Purchase', 
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

DECLARE	@Name VARCHAR(100)='Sale', 
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
		@Name VARCHAR(100)='Vendors', 
        @Url VARCHAR(150)='/Configurations/Master/Vendor/Index', 
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
		@Name VARCHAR(100)='Customers', 
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


DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Taxes', 
        @Url VARCHAR(150)='/Configurations/Master/Tax/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=5, 
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
		@Name VARCHAR(100)='UOM', 
        @Url VARCHAR(150)='/Configurations/Master/UOM/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=6, 
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
		@Name VARCHAR(100)='Products', 
        @Url VARCHAR(150)='/Configurations/Master/Product/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=7, 
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
		@Name VARCHAR(100)='Barcodes', 
        @Url VARCHAR(150)='/Configurations/Master/Barcode/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=7, 
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
		@Name VARCHAR(100)='Vendor-Product Config', 
        @Url VARCHAR(150)='/Configurations/Master/VendorProduct/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=7, 
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
		@Name VARCHAR(100)='UOM-Product Config', 
        @Url VARCHAR(150)='/Configurations/Master/ProductUnitOfMeasurement/Index',
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=7, 
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
		@Name VARCHAR(100)='Tax-Product Config', 
        @Url VARCHAR(150)='/Configurations/Master/ProductTax/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=7, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO



DECLARE	@ParrentName VARCHAR(100)='Purchase', 
		@Name VARCHAR(100)='Purchase Orders', 
        @Url VARCHAR(150)='/Configurations/Master/Purchase/Orders', 
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





DECLARE	@ParrentName VARCHAR(100)='Purchase', 
		@Name VARCHAR(100)='Inwards', 
        @Url VARCHAR(150)='/Configurations/Master/Purchase/Inwards', 
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




DECLARE	@ParrentName VARCHAR(100)='Purchase', 
		@Name VARCHAR(100)='Inward History', 
        @Url VARCHAR(150)='/Configurations/Master/Purchase/InwardHistory', 
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





DECLARE	@ParrentName VARCHAR(100)='Sale', 
		@Name VARCHAR(100)='Sales Orders', 
        @Url VARCHAR(150)='/Configurations/Master/Sales/SalesOrder', 
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


DECLARE	@ParrentName VARCHAR(100)='Sale', 
		@Name VARCHAR(100)='Outwards', 
        @Url VARCHAR(150)='/Configurations/Master/Sales/Outwards', 
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


DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Contacts', 
        @Url VARCHAR(150)='/Configurations/Master/Contact/Index', 
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


DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Tax Rate', 
        @Url VARCHAR(150)='/Configurations/Master/TaxRate/Index', 
        @Is_Active BIT=1, 
        @Update_Seq INT=0,
        @Created_By VARCHAR(10)='dbo',
        @Created_On DATETIME=GETDATE(),
        @Modified_By VARCHAR(10)='dbo',
        @Modified_On DATETIME=GETDATE(),
        @Is_Deleted BIT=0, 
        @Icon_Class varchar(50)='"fa fa-circle-o"', 
        @Order_By INT=7, 
        @ParrentMenu_ID INT=NULL,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO