
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
		@SubMenuName VARCHAR(100)='FAQ',			
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
		@SubMenuName VARCHAR(100)='Price Features Master',			
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

/***************** Start Services 1 Menus*************************/

DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Services',			
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
		@SubMenuName VARCHAR(100)='Section 1',			
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
		@SubMenuName VARCHAR(100)='Section 4',			
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
		@SubMenuName VARCHAR(100)='Section 5',			
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
		@SubMenuName VARCHAR(100)='Section 6',			
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
		@SubMenuName VARCHAR(100)='Price Mapping',			
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
		@SubMenuName VARCHAR(100)='Section 8',			
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
		@SubMenuName VARCHAR(100)='Section 10',			
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


/***************** End Services 1 Menus*************************/






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

