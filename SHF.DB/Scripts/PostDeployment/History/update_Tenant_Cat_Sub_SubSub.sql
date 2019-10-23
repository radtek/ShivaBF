declare @Tenant_ID bigint
 SELECT @Tenant_ID=T.Id FROM dbo.Tbl_Tenant T WITH(NOLOCK) WHERE T.[Name]='ShivaBF';
 update [dbo].[Tbl_CategoriesMaster]
set Tenant_ID=@Tenant_ID

update [dbo].[Tbl_SubCategoriesMaster]
set Tenant_ID=@Tenant_ID

update [dbo].[Tbl_SubSubCategoriesMaster]
set Tenant_ID=@Tenant_ID