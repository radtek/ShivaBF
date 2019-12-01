/*Insert Default Customer */
SET IDENTITY_INSERT [dbo].[Tbl_CustomerMaster] ON
INSERT INTO [dbo].[Tbl_CustomerMaster]
           ([ID]
		   ,[Gender]
           ,[FirstName]
           ,[LastName]
           ,[DOB]
           ,[EmailID]
           ,[FullStreetAddress]
           ,[Telephone]
           ,[Fax]
           ,[Password]
           ,[Newsletter]
           ,[IsActive]
           ,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES
           (
		   -1
		   ,'Unknown'
           ,'Unknown'
           ,'Unknown'
           ,getdate()
           ,'Unknown'
           ,'Unknown'
           ,'Unknown'
           ,'Unknown'
           ,'Unknown'
           ,'Unknown'
           ,1
           ,1
           ,'SYSTEM'
           ,getdate()
           ,'SYSTEM'
           ,getdate()
           ,1)
GO
SET IDENTITY_INSERT [dbo].[Tbl_CustomerMaster] OFF
GO




DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Vendors',			
		@RoleName VARCHAR(100)='DEVLOPMENT',
		@Has_Access BIT=1,
		@Is_Active BIT=1,
		@Update_Seq INT=0,
		@Created_By VARCHAR(10)='dbo',
		@Created_On DATETIME=GETDATE(),
		@Modified_By VARCHAR(10)='dbo',
		@Modified_On DATETIME=GETDATE(),
		@Is_Deleted BIT=0,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @RoleID=R.Id FROM dbo.AspNetRoles R WITH(NOLOCK) WHERE R.[Name]=@RoleName;
SELECT @SubMenuID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@SubMenuName AND SM.[UseOnlyFor]=@UseOnlyFor AND SM.ParrentMenu_ID IS NOT NULL;
IF  EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	DELETE FROM dbo.Tbl_AspNetRoles_SubMenu WHERE AspNetRole_ID=@RoleID AND SubMenu_ID=@SubMenuID
END
GO

DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Customers',			
		@RoleName VARCHAR(100)='DEVLOPMENT',
		@Has_Access BIT=1,
		@Is_Active BIT=1,
		@Update_Seq INT=0,
		@Created_By VARCHAR(10)='dbo',
		@Created_On DATETIME=GETDATE(),
		@Modified_By VARCHAR(10)='dbo',
		@Modified_On DATETIME=GETDATE(),
		@Is_Deleted BIT=0,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @RoleID=R.Id FROM dbo.AspNetRoles R WITH(NOLOCK) WHERE R.[Name]=@RoleName;
SELECT @SubMenuID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@SubMenuName AND SM.[UseOnlyFor]=@UseOnlyFor AND SM.ParrentMenu_ID IS NOT NULL;
IF  EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	DELETE FROM dbo.Tbl_AspNetRoles_SubMenu WHERE AspNetRole_ID=@RoleID AND SubMenu_ID=@SubMenuID
END
GO



DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Taxes',			
		@RoleName VARCHAR(100)='DEVLOPMENT',
		@Has_Access BIT=1,
		@Is_Active BIT=1,
		@Update_Seq INT=0,
		@Created_By VARCHAR(10)='dbo',
		@Created_On DATETIME=GETDATE(),
		@Modified_By VARCHAR(10)='dbo',
		@Modified_On DATETIME=GETDATE(),
		@Is_Deleted BIT=0,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @RoleID=R.Id FROM dbo.AspNetRoles R WITH(NOLOCK) WHERE R.[Name]=@RoleName;
SELECT @SubMenuID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@SubMenuName AND SM.[UseOnlyFor]=@UseOnlyFor AND SM.ParrentMenu_ID IS NOT NULL;
IF  EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	DELETE FROM dbo.Tbl_AspNetRoles_SubMenu WHERE AspNetRole_ID=@RoleID AND SubMenu_ID=@SubMenuID
END
GO



--DECLARE @RoleID BIGINT=NULL , 
--		@SubMenuID BIGINT=NULL, 
--		@SubMenuName VARCHAR(100)='UOM',			
--		@RoleName VARCHAR(100)='DEVLOPMENT',
--		@Has_Access BIT=1,
--		@Is_Active BIT=1,
--		@Update_Seq INT=0,
--		@Created_By VARCHAR(10)='dbo',
--		@Created_On DATETIME=GETDATE(),
--		@Modified_By VARCHAR(10)='dbo',
--		@Modified_On DATETIME=GETDATE(),
--		@Is_Deleted BIT=0,
--		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

--SELECT @RoleID=R.Id FROM dbo.AspNetRoles R WITH(NOLOCK) WHERE R.[Name]=@RoleName;
--SELECT @SubMenuID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@SubMenuName AND SM.[UseOnlyFor]=@UseOnlyFor AND SM.ParrentMenu_ID IS NOT NULL;
--IF  EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
--BEGIN
--	DELETE FROM dbo.Tbl_AspNetRoles_SubMenu WHERE AspNetRole_ID=@RoleID AND SubMenu_ID=@SubMenuID
--END
--GO



DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='UOM-Product Config',
		@RoleName VARCHAR(100)='DEVLOPMENT',
		@Has_Access BIT=1,
		@Is_Active BIT=1,
		@Update_Seq INT=0,
		@Created_By VARCHAR(10)='dbo',
		@Created_On DATETIME=GETDATE(),
		@Modified_By VARCHAR(10)='dbo',
		@Modified_On DATETIME=GETDATE(),
		@Is_Deleted BIT=0,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @RoleID=R.Id FROM dbo.AspNetRoles R WITH(NOLOCK) WHERE R.[Name]=@RoleName;
SELECT @SubMenuID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@SubMenuName AND SM.[UseOnlyFor]=@UseOnlyFor AND SM.ParrentMenu_ID IS NOT NULL;
IF EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	DELETE FROM dbo.Tbl_AspNetRoles_SubMenu WHERE AspNetRole_ID=@RoleID AND SubMenu_ID=@SubMenuID
END
GO



DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Tax-Product Config',
		@RoleName VARCHAR(100)='DEVLOPMENT',
		@Has_Access BIT=1,
		@Is_Active BIT=1,
		@Update_Seq INT=0,
		@Created_By VARCHAR(10)='dbo',
		@Created_On DATETIME=GETDATE(),
		@Modified_By VARCHAR(10)='dbo',
		@Modified_On DATETIME=GETDATE(),
		@Is_Deleted BIT=0,
		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

SELECT @RoleID=R.Id FROM dbo.AspNetRoles R WITH(NOLOCK) WHERE R.[Name]=@RoleName;
SELECT @SubMenuID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@SubMenuName AND SM.[UseOnlyFor]=@UseOnlyFor AND SM.ParrentMenu_ID IS NOT NULL;
IF EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	DELETE FROM dbo.Tbl_AspNetRoles_SubMenu WHERE AspNetRole_ID=@RoleID AND SubMenu_ID=@SubMenuID
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

	IF EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.[ParrentMenu_ID]=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			DELETE FROM dbo.Tbl_SubMenu  WHERE [Name]=@Name AND [Url]=@Url AND [ParrentMenu_ID]=@ParrentMenu_ID AND [UseOnlyFor]=@UseOnlyFor
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

	IF EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.[ParrentMenu_ID]=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			DELETE FROM dbo.Tbl_SubMenu  WHERE [Name]=@Name AND [Url]=@Url AND [ParrentMenu_ID]=@ParrentMenu_ID AND [UseOnlyFor]=@UseOnlyFor
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

	IF EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.[ParrentMenu_ID]=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			DELETE FROM dbo.Tbl_SubMenu  WHERE [Name]=@Name AND [Url]=@Url AND [ParrentMenu_ID]=@ParrentMenu_ID AND [UseOnlyFor]=@UseOnlyFor
		END	
GO



--DECLARE	@ParrentName VARCHAR(100)='Masters', 
--		@Name VARCHAR(100)='UOM', 
--        @Url VARCHAR(150)='/Configurations/Master/UOM/Index', 
--        @Is_Active BIT=1, 
--        @Update_Seq INT=0,
--        @Created_By VARCHAR(10)='dbo',
--        @Created_On DATETIME=GETDATE(),
--        @Modified_By VARCHAR(10)='dbo',
--        @Modified_On DATETIME=GETDATE(),
--        @Is_Deleted BIT=0, 
--        @Icon_Class varchar(50)='"fa fa-circle-o"', 
--        @Order_By INT=6, 
--        @ParrentMenu_ID INT=NULL,
--		@UseOnlyFor VARCHAR(10)='DEVLOPMENT'

--SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

--	IF EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.[ParrentMenu_ID]=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
--		BEGIN
--			DELETE FROM dbo.Tbl_SubMenu  WHERE [Name]=@Name AND [Url]=@Url AND [ParrentMenu_ID]=@ParrentMenu_ID AND [UseOnlyFor]=@UseOnlyFor
--		END	
--GO


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

	IF EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.[ParrentMenu_ID]=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			DELETE FROM dbo.Tbl_SubMenu  WHERE [Name]=@Name AND [Url]=@Url AND [ParrentMenu_ID]=@ParrentMenu_ID AND [UseOnlyFor]=@UseOnlyFor
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

	IF EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.[ParrentMenu_ID]=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			DELETE FROM dbo.Tbl_SubMenu  WHERE [Name]=@Name AND [Url]=@Url AND [ParrentMenu_ID]=@ParrentMenu_ID AND [UseOnlyFor]=@UseOnlyFor
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

	IF EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			DELETE FROM dbo.Tbl_SubMenu  WHERE [Name]=@Name AND [Url]=@Url AND [ParrentMenu_ID]=@ParrentMenu_ID AND [UseOnlyFor]=@UseOnlyFor			
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

	IF EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			DELETE FROM dbo.Tbl_SubMenu  WHERE [Name]=@Name AND [Url]=@Url AND [ParrentMenu_ID]=@ParrentMenu_ID AND [UseOnlyFor]=@UseOnlyFor			
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

	IF EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			DELETE FROM dbo.Tbl_SubMenu  WHERE [Name]=@Name AND [Url]=@Url AND [ParrentMenu_ID]=@ParrentMenu_ID AND [UseOnlyFor]=@UseOnlyFor			
		END
GO



--DECLARE	@ParrentName VARCHAR(100)='Masters', 
--		@Name VARCHAR(100)='UOM', 
--        @Url VARCHAR(150)='/Settings/Master/UOM/MyUOM', 
--        @Is_Active BIT=1, 
--        @Update_Seq INT=0,
--        @Created_By VARCHAR(10)='dbo',
--        @Created_On DATETIME=GETDATE(),
--        @Modified_By VARCHAR(10)='dbo',
--        @Modified_On DATETIME=GETDATE(),
--        @Is_Deleted BIT=0, 
--        @Icon_Class varchar(50)='"fa fa-circle-o"', 
--        @Order_By INT=6, 
--        @ParrentMenu_ID INT=NULL,
--		@UseOnlyFor VARCHAR(10)='TENANT'

--SELECT @ParrentMenu_ID=SM.ID FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@ParrentName 

--	IF EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
--		BEGIN
--			DELETE FROM dbo.Tbl_SubMenu  WHERE [Name]=@Name AND [Url]=@Url AND [ParrentMenu_ID]=@ParrentMenu_ID AND [UseOnlyFor]=@UseOnlyFor			
--		END
--GO


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

	IF EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			DELETE FROM dbo.Tbl_SubMenu  WHERE [Name]=@Name AND [Url]=@Url AND [ParrentMenu_ID]=@ParrentMenu_ID AND [UseOnlyFor]=@UseOnlyFor			
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

	IF EXISTS(SELECT 1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Name]=@Name AND SM.[Url]=@Url AND SM.ParrentMenu_ID=@ParrentMenu_ID AND SM.[UseOnlyFor]=@UseOnlyFor)
		BEGIN
			DELETE FROM dbo.Tbl_SubMenu  WHERE [Name]=@Name AND [Url]=@Url AND [ParrentMenu_ID]=@ParrentMenu_ID AND [UseOnlyFor]=@UseOnlyFor			
		END
GO


DECLARE	@Data_1_Type VARCHAR(4)='LINE', @Code_ID INT=1004
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Data_1_Type=@Data_1_Type WHERE Code_ID=@Code_ID
		END
Go

--DECLARE	@Data_1_Type VARCHAR(4)='QRCD', @CodeValue_New VARCHAR(4)='QCOD',@CodeValue_Old VARCHAR(4)='PHCD',@Code_ID INT=1004
--		BEGIN
--			UPDATE dbo.Tbl_CodeValue SET Data_1_Type=@Data_1_Type,CodeValue=@CodeValue_New  WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue_Old
--		END
--Go


DECLARE @CodeValue VARCHAR(4)='128A',@Code_ID INT=1004,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

DECLARE @CodeValue VARCHAR(4)='128B',@Code_ID INT=1004,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

DECLARE @CodeValue VARCHAR(4)='128C',@Code_ID INT=1004,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

DECLARE @CodeValue VARCHAR(4)='EN13',@Code_ID INT=1004,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

DECLARE @CodeValue VARCHAR(4)='EAN8',@Code_ID INT=1004,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

DECLARE @CodeValue VARCHAR(4)='UPC',@Code_ID INT=1004,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

DECLARE @CodeValue VARCHAR(4)='CD39',@Code_ID INT=1004,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

DECLARE @CodeValue VARCHAR(4)='IF14',@Code_ID INT=1004,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

DECLARE @CodeValue VARCHAR(4)='ITF',@Code_ID INT=1004,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

DECLARE @CodeValue VARCHAR(4)='MSI',@Code_ID INT=1004,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

DECLARE @CodeValue VARCHAR(4)='MI10',@Code_ID INT=1004,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

DECLARE @CodeValue VARCHAR(4)='MI11',@Code_ID INT=1004,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

DECLARE @CodeValue VARCHAR(4)='MS10',@Code_ID INT=1004,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

DECLARE @CodeValue VARCHAR(4)='MS11',@Code_ID INT=1004,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

 DECLARE @CodeValue VARCHAR(4)='P417',@Code_ID INT=1015,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go


 DECLARE @CodeValue VARCHAR(4)='DTMT',@Code_ID INT=1015,@Is_Active BIT=0
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET Is_Active=@Is_Active WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue
		END
Go

 DECLARE @CodeValue_New VARCHAR(4)='QCOD',@Description VARCHAR(100)='QR Code',@Code_ID INT=1004
		BEGIN
			UPDATE dbo.Tbl_CodeValue SET CodeValue=@CodeValue_New, [Description]=@Description WHERE Code_ID=@Code_ID AND CodeValue=@CodeValue_New
		END
Go
