
DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Tenants',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO


DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Roles',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO



DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Users',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO
DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Bank',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO
DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Categories',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO

DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Sub Cat',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO

DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Sub Sub Cat',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO



DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='UOM',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO



DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Products',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO



DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Vendor-Product Config',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO




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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO



DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Purchase Orders',
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO



DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Inwards',
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO



DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Inward History',
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO


DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Sales Orders',
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO


DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Outwards',
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO



DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Barcodes',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO




DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Documents',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO


DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Navigations',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO


DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Menu Access Policy',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO


DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Message',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO

DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Contacts',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO

DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Tax Rate',			
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
IF NOT EXISTS (SELECT 1 FROM dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) WHERE RM.AspNetRole_ID=@RoleID AND RM.SubMenu_ID=@SubMenuID)
BEGIN
	
	INSERT INTO [dbo].[Tbl_AspNetRoles_SubMenu]
	           ([SubMenu_ID],[AspNetRole_ID],[HasAccess],[IsActive],[UpdateSeq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
	VALUES (@SubMenuID,@RoleID,@Has_Access,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted) 

END
GO