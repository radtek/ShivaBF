
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
		@Name VARCHAR(100)='Vendors', 
        @Url VARCHAR(150)='/Settings/Master/Vendor/MyVendors', 
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
		@Name VARCHAR(100)='Customers', 
        @Url VARCHAR(150)='/Settings/Master/Customer/Index', 
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



DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Taxes', 
        @Url VARCHAR(150)='/Settings/Master/Tax/MyTaxes', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO



DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='UOM', 
        @Url VARCHAR(150)='/Settings/Master/UOM/Index', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO




DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Products', 
        @Url VARCHAR(150)='/Settings/Master/Product/Index', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO




DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Barcodes', 
        @Url VARCHAR(150)='/Settings/Master/Barcode/Index', 
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


DECLARE	@ParrentName VARCHAR(100)='Settings', 
		@Name VARCHAR(100)='Vendor-Product Config', 
        @Url VARCHAR(150)='/Settings/Master/VendorProduct/Index', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO



DECLARE	@ParrentName VARCHAR(100)='Settings', 
		@Name VARCHAR(100)='UOM-Product Config', 
        @Url VARCHAR(150)='/Settings/Master/ProductUnitOfMeasurement/Index',
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO



DECLARE	@ParrentName VARCHAR(100)='Settings', 
		@Name VARCHAR(100)='Tax-Product Config', 
        @Url VARCHAR(150)='/Settings/Master/ProductTax/Index', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO



DECLARE	@ParrentName VARCHAR(100)='Purchase', 
		@Name VARCHAR(100)='Purchase Orders', 
        @Url VARCHAR(150)='/Settings/Master/Purchase/Orders', 
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



DECLARE	@ParrentName VARCHAR(100)='Purchase', 
		@Name VARCHAR(100)='Inwards', 
        @Url VARCHAR(150)='/Settings/Master/Purchase/Inwards', 
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



DECLARE	@ParrentName VARCHAR(100)='Purchase', 
		@Name VARCHAR(100)='Inward History', 
        @Url VARCHAR(150)='/Settings/Master/Purchase/InwardHistory', 
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



DECLARE	@ParrentName VARCHAR(100)='Sale', 
		@Name VARCHAR(100)='Sales Orders', 
        @Url VARCHAR(150)='/Settings/Master/Sales/SalesOrder', 
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

DECLARE	@ParrentName VARCHAR(100)='Sale', 
		@Name VARCHAR(100)='Outwards', 
        @Url VARCHAR(150)='/Settings/Master/Sales/Outwards', 
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

DECLARE	@ParrentName VARCHAR(100)='Masters', 
		@Name VARCHAR(100)='Tax Rate', 
        @Url VARCHAR(150)='/Settings/Master/TaxRate/Index', 
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
		@UseOnlyFor VARCHAR(10)='TENANT'

SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

	IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			INSERT INTO [dbo].[Tbl_SubMenu]([Name],[Url],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[IconClass],[OrderBy],[ParrentMenu_ID],[UseOnlyFor])
			VALUES(@Name, @Url, @Is_Active, @Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted, @Icon_Class, @Order_By, @ParrentMenu_ID,@UseOnlyFor)
		END
GO
