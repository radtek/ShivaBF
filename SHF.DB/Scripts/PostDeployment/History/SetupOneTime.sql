/*Category Master Load*/

IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_CategoriesMaster] WITH(NOLOCK) WHERE [CategoryName]='Form New Business')
BEGIN
	INSERT INTO [dbo].[Tbl_CategoriesMaster]
           ([CategoryName],[DisplayIndex],[DisplayOnHome],[IsActive],[TotalViews],[Url],[Metadata],[Keyword],[MetaDescription],[Tenant_ID],[Created_By]
		    ,[Created_On] ,[Modified_By],[Modified_On],[Is_Deleted])
    VALUES('Form New Business',1,1,1,1,'/formnewbusiness','Form New Business','Form New Business','Form New Business',
	null,'dbo',GetDate(),'dbo',GetDate(),0)
END
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_CategoriesMaster] WITH(NOLOCK) WHERE [CategoryName]='Goods & Services Tax')
BEGIN
	INSERT INTO [dbo].[Tbl_CategoriesMaster]
           ([CategoryName],[DisplayIndex],[DisplayOnHome],[IsActive],[TotalViews],[Url],[Metadata],[Keyword],[MetaDescription],[Tenant_ID],[Created_By]
		    ,[Created_On] ,[Modified_By],[Modified_On],[Is_Deleted])
    VALUES('Goods & Services Tax',2,1,1,1,'/goodsservicestax','Goods & Services Tax','Goods & Services Tax','Goods & Services Tax',
	null,'dbo',GetDate(),'dbo',GetDate(),0)
END
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_CategoriesMaster] WITH(NOLOCK) WHERE [CategoryName]='Income Tax')
BEGIN
	INSERT INTO [dbo].[Tbl_CategoriesMaster]
           ([CategoryName],[DisplayIndex],[DisplayOnHome],[IsActive],[TotalViews],[Url],[Metadata],[Keyword],[MetaDescription],[Tenant_ID],[Created_By]
		    ,[Created_On] ,[Modified_By],[Modified_On],[Is_Deleted])
    VALUES('Income Tax',3,1,1,1,'/incometax','Income Tax','Income Tax','Income Tax',
	null,'dbo',GetDate(),'dbo',GetDate(),0)
END
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_CategoriesMaster] WITH(NOLOCK) WHERE [CategoryName]='Intellectual Property')
BEGIN
	INSERT INTO [dbo].[Tbl_CategoriesMaster]
           ([CategoryName],[DisplayIndex],[DisplayOnHome],[IsActive],[TotalViews],[Url],[Metadata],[Keyword],[MetaDescription],[Tenant_ID],[Created_By]
		    ,[Created_On] ,[Modified_By],[Modified_On],[Is_Deleted])
    VALUES('Intellectual Property',4,1,1,1,'/intellectualproperty','Intellectual Property','Intellectual Property','Intellectual Property',
	null,'dbo',GetDate(),'dbo',GetDate(),0)
END
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_CategoriesMaster] WITH(NOLOCK) WHERE [CategoryName]='Legal Compliance')
BEGIN
	INSERT INTO [dbo].[Tbl_CategoriesMaster]
           ([CategoryName],[DisplayIndex],[DisplayOnHome],[IsActive],[TotalViews],[Url],[Metadata],[Keyword],[MetaDescription],[Tenant_ID],[Created_By]
		    ,[Created_On] ,[Modified_By],[Modified_On],[Is_Deleted])
    VALUES('Legal Compliance',5,1,1,1,'/legalcompliance','Legal Compliance','Legal Compliance','Legal Compliance',
	null,'dbo',GetDate(),'dbo',GetDate(),0)
END
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_CategoriesMaster] WITH(NOLOCK) WHERE [CategoryName]='Miscellaneous')
BEGIN
	INSERT INTO [dbo].[Tbl_CategoriesMaster]
           ([CategoryName],[DisplayIndex],[DisplayOnHome],[IsActive],[TotalViews],[Url],[Metadata],[Keyword],[MetaDescription],[Tenant_ID],[Created_By]
		    ,[Created_On] ,[Modified_By],[Modified_On],[Is_Deleted])
    VALUES('Miscellaneous',6,1,1,1,'/miscellaneous','Miscellaneous','Miscellaneous','Miscellaneous',
	null,'dbo',GetDate(),'dbo',GetDate(),0)
END
GO
/*End Category Master Load*/


DECLARE @Cat_Id INT
SELECT @Cat_Id=Id FROM [dbo].[Tbl_CategoriesMaster] WITH(NOLOCK) WHERE [CategoryName]='Form New Business'
IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_SubCategoriesMaster] WITH(NOLOCK) WHERE [SubCategoryName]='BUSINESS REGISTRATIONS')
BEGIN
	INSERT INTO [dbo].[AspNetUserRoles]([UserId],[RoleId],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Active],[Is_Deleted],[Update_Seq])
    VALUES(@UserID,@RoleID,'dbo',GetDate(),'dbo',GetDate(),1,0,0)
END
GO
@Cat_Id=select CategoryName from [dbo].[Tbl_CategoriesMaster] where 

INSERT INTO [dbo].[Tbl_SubCategoriesMaster]
           ([Cat_Id]
           ,[SubCategoryName]
           ,[DisplayIndex]
           ,[DisplayOnHome]
           ,[IsActive]
           ,[TotalViews]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           ,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES
           (<Cat_Id, bigint,>
           ,<SubCategoryName, nvarchar(max),>
           ,<DisplayIndex, int,>
           ,<DisplayOnHome, bit,>
           ,<IsActive, bit,>
           ,<TotalViews, int,>
           ,<Url, nvarchar(max),>
           ,<Metadata, nvarchar(max),>
           ,<Keyword, nvarchar(max),>
           ,<MetaDescription, nvarchar(max),>
           ,<Tenant_ID, bigint,>
           ,<Created_By, nvarchar(max),>
           ,<Created_On, datetime,>
           ,<Modified_By, nvarchar(max),>
           ,<Modified_On, datetime,>
           ,<Is_Deleted, bit,>)
GO


USE [SFApp]
GO

INSERT INTO [dbo].[Tbl_SubSubCategoriesMaster]
           ([Cat_Id]
           ,[SubCat_Id]
           ,[SubSubCategoryName]
           ,[DisplayIndex]
           ,[DisplayOnHome]
           ,[IsActive]
           ,[ServiceType_ID]
           ,[ServiceType]
           ,[TotalViews]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           ,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES
           (<Cat_Id, bigint,>
           ,<SubCat_Id, bigint,>
           ,<SubSubCategoryName, nvarchar(max),>
           ,<DisplayIndex, int,>
           ,<DisplayOnHome, bit,>
           ,<IsActive, bit,>
           ,<ServiceType_ID, bigint,>
           ,<ServiceType, nvarchar(max),>
           ,<TotalViews, int,>
           ,<Url, nvarchar(max),>
           ,<Metadata, nvarchar(max),>
           ,<Keyword, nvarchar(max),>
           ,<MetaDescription, nvarchar(max),>
           ,<Tenant_ID, bigint,>
           ,<Created_By, nvarchar(max),>
           ,<Created_On, datetime,>
           ,<Modified_By, nvarchar(max),>
           ,<Modified_On, datetime,>
           ,<Is_Deleted, bit,>)
GO


