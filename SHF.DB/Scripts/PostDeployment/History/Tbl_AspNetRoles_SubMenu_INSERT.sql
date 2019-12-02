
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


DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Banner Master',			
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
		@SubMenuName VARCHAR(100)='S1 Services',			
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
		@SubMenuName VARCHAR(100)='S1 Section 1',			
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
		@SubMenuName VARCHAR(100)='S1 Section 4',			
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
		@SubMenuName VARCHAR(100)='S1 Section 5',			
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
		@SubMenuName VARCHAR(100)='S1 Section 6',			
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
		@SubMenuName VARCHAR(100)='S1 Price Mapping',			
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
		@SubMenuName VARCHAR(100)='S1 Section 8',			
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
		@SubMenuName VARCHAR(100)='S1 Section 10',			
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


/***************** Start Services 2 Menus*************************/

DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='S2 Services',			
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
		@SubMenuName VARCHAR(100)='S2 Section 2',			
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
		@SubMenuName VARCHAR(100)='S2 Section 3',			
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
		@SubMenuName VARCHAR(100)='S2 Section 4',			
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
/*********************************************End Services 2 **********************************************/

/***************** Start Services 3 Menus*************************/

DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='S3 Services',			
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
		@SubMenuName VARCHAR(100)='S3 Section Heading Buttons',			
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
		@SubMenuName VARCHAR(100)='S3 Section 4',			
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
		@SubMenuName VARCHAR(100)='S3 Section 6',			
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
/*********************************************End Services 3 **********************************************/
/***************** Start Services 4 Menus*************************/

DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='S4 Services',			
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
		@SubMenuName VARCHAR(100)='S4 Section 2 FAQ',			
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
		@SubMenuName VARCHAR(100)='S4 Section 345 Master',			
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
		@SubMenuName VARCHAR(100)='S4 Section 345 Buttons Child',			
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
		@SubMenuName VARCHAR(100)='S4 Section 345 Features Details',			
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
		@SubMenuName VARCHAR(100)='S4 Section678 FieldMaster',			
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
		@SubMenuName VARCHAR(100)='S4 Section678 FieldValues',			
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


/***************** End Services 4 Menus*************************/

/***************** Start Services 5 Menus*************************/

DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='S5 Services',			
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
		@SubMenuName VARCHAR(100)='S5 Section 2 Master',			
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
		@SubMenuName VARCHAR(100)='S5 Section 2 Features',			
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



/***************** End Services 5 Menus*************************/

/***************** Start Services 6 Menus*************************/

DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='S6 Services',			
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
		@SubMenuName VARCHAR(100)='S6 Section 2 Master',			
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
		@SubMenuName VARCHAR(100)='S6 Section 2 Features',			
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



/***************** End Services 6 Menus*************************/

/***************** Start Services 7 Menus*************************/

DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='S7 Services',			
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
		@SubMenuName VARCHAR(100)='S7 Section HeadingButtons',			
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
		@SubMenuName VARCHAR(100)='S7 Section 4',			
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
		@SubMenuName VARCHAR(100)='S7 Section 6',			
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



/***************** End Services 7 Menus*************************/

/***************** Start Services 8 Menus*************************/

DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='S8 Services',			
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
		@SubMenuName VARCHAR(100)='S8 Section HeadingButtons',			
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
		@SubMenuName VARCHAR(100)='S8 Section 6',			
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



/***************** End Services 8 Menus*************************/

/***************** End Home Page Menus*************************/
DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='HomePage Banner',			
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
		@SubMenuName VARCHAR(100)='Section 2',			
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
		@SubMenuName VARCHAR(100)='Section 3',			
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
		@SubMenuName VARCHAR(100)='Section 3 Features',			
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
		@SubMenuName VARCHAR(100)='Section 4 Testimonials',			
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
/***************** End Home Page Menus*************************/

/****************************Blogs*****************************/
DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Blog Master',			
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
		@SubMenuName VARCHAR(100)='Banner Navigations Details',			
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
		@SubMenuName VARCHAR(100)='Related Blogs Details',			
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
		@SubMenuName VARCHAR(100)='Blog Comments Details',			
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
		@SubMenuName VARCHAR(100)='Comments Reply',			
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
/***************** End Blogs Menus*************************/
/****************************Footer*****************************/


DECLARE @RoleID BIGINT=NULL , 
		@SubMenuID BIGINT=NULL, 
		@SubMenuName VARCHAR(100)='Footer Block Master',			
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
		@SubMenuName VARCHAR(100)='Footer Links Details',			
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
/******************************************Footer***********************/
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
		@SubMenuName VARCHAR(100)='Visited IP',			
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
		@SubMenuName VARCHAR(100)='Page Views Report',			
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
		@SubMenuName VARCHAR(100)='Customer',			
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
		@SubMenuName VARCHAR(100)='Customer Login Info',			
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
		@SubMenuName VARCHAR(100)='Customer IP Info Mapping',	
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
		@SubMenuName VARCHAR(100)='Customer Surfing',	
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

