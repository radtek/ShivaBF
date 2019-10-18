USE [SFApp]
GO

INSERT INTO [dbo].[Tbl_CategoriesMaster]
           ([CategoryName]
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
           (<CategoryName, nvarchar(max),>
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


