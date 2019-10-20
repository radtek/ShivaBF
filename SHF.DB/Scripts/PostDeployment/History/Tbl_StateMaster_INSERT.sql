DECLARE	    @StateFullName nvarchar(max)='Andaman and Nicobar Islands'
           ,@StateShortName nvarchar(max)='AN'
           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO


DECLARE	   @StateFullName nvarchar(max)='Andhra Pradesh'	,@StateShortName nvarchar(max)='AP'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Arunachal Pradesh'	,@StateShortName nvarchar(max)='AR'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Assam'	,@StateShortName nvarchar(max)='AS'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	   @StateFullName nvarchar(max)='Bihar'	,@StateShortName nvarchar(max)='BR'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Chandigarh'	,@StateShortName nvarchar(max)='CH'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO


DECLARE	    @StateFullName nvarchar(max)='Chhattisgarh'	,@StateShortName nvarchar(max)='CT'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	   @StateFullName nvarchar(max)='Dadra and Nagar Haveli'	,@StateShortName nvarchar(max)='DN'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	   @StateFullName nvarchar(max)='Daman and Diu'	,@StateShortName nvarchar(max)='DD'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO


DECLARE	    @StateFullName nvarchar(max)='Delhi'	,@StateShortName nvarchar(max)='DL'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	   @StateFullName nvarchar(max)='Goa'	,@StateShortName nvarchar(max)='GA'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Gujarat'	,@StateShortName nvarchar(max)='GJ'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Haryana'	,@StateShortName nvarchar(max)='HR'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	   @StateFullName nvarchar(max)='Himachal Pradesh'	,@StateShortName nvarchar(max)='HP'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Jammu and Kashmir'	,@StateShortName nvarchar(max)='JK'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	   @StateFullName nvarchar(max)='Jharkhand'	,@StateShortName nvarchar(max)='JH'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Karnataka'	,@StateShortName nvarchar(max)='KA'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Kerala'	,@StateShortName nvarchar(max)='KL'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Lakshadweep'	,@StateShortName nvarchar(max)='LD'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Madhya Pradesh'	,@StateShortName nvarchar(max)='MP'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Maharashtra'	,@StateShortName nvarchar(max)='MH'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Manipur'	,@StateShortName nvarchar(max)='MN'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Meghalaya'	,@StateShortName nvarchar(max)='ML'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	   @StateFullName nvarchar(max)='Mizoram'	,@StateShortName nvarchar(max)='MZ'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Nagaland'	,@StateShortName nvarchar(max)='NL'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	   @StateFullName nvarchar(max)='Odisha'	,@StateShortName nvarchar(max)='OR'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	   @StateFullName nvarchar(max)='Puducherry'	,@StateShortName nvarchar(max)='PY'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Punjab'	,@StateShortName nvarchar(max)='PB'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	  @StateFullName nvarchar(max)='Rajasthan'	,@StateShortName nvarchar(max)='RJ'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	   @StateFullName nvarchar(max)='Sikkim'	,@StateShortName nvarchar(max)='SK'


           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Tamil Nadu'	,@StateShortName nvarchar(max)='TN'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Telangana'	,@StateShortName nvarchar(max)='TG'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Tripura'	,@StateShortName nvarchar(max)='TR'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	   @StateFullName nvarchar(max)='Uttar Pradesh'	,@StateShortName nvarchar(max)='UP'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	    @StateFullName nvarchar(max)='Uttarakhand'	,@StateShortName nvarchar(max)='UT'


           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO

DECLARE	   @StateFullName nvarchar(max)='West Bengal'	,@StateShortName nvarchar(max)='WB'

           ,@IsActive bit=1
           ,@Url nvarchar(max)=''
           ,@Metadata nvarchar(max)=''
           ,@Keyword nvarchar(max)=''
           ,@MetaDescription nvarchar(max)=''
           ,@Created_By VARCHAR(10)='dbo'
           ,@Created_On DATETIME=GETDATE()
           ,@Modified_By VARCHAR(10)='dbo'
           ,@Modified_On DATETIME=GETDATE()
           ,@Is_Deleted BIT=0


	IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_StateMaster] SM WITH(NOLOCK) WHERE SM.[StateFullName]=@StateFullName)
		BEGIN
		INSERT INTO	[dbo].[Tbl_StateMaster]
           ([StateFullName]
           ,[StateShortName]
           ,[IsActive]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           --,[Tenant_ID]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
     VALUES(@StateFullName
           ,@StateShortName
           ,@IsActive
           ,@Url
           ,@Metadata
           ,@Keyword
           ,@MetaDescription
           --,@Tenant_ID
           ,@Created_By
           ,@Created_On
           ,@Modified_By
           ,@Modified_On
           ,@Is_Deleted)
		END
GO