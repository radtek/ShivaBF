

DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='INDI' ,
@Description VARCHAR(100)='India' ,
@Data_1_Type nvarchar(4) = NULL,
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Country'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq )
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='MH00' ,
@Description VARCHAR(100)='Maharashtra' ,
@Data_1_Type nvarchar(4) = 'INDI',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='State'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq )
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='GJ00' ,
@Description VARCHAR(100)='Gujrat' ,
@Data_1_Type nvarchar(4) = 'INDI',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='State'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq )
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='DL00' ,
@Description VARCHAR(100)='Dehli' ,
@Data_1_Type nvarchar(4) = 'INDI',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='State'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq )
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='PUNE' ,
@Description VARCHAR(100)='Pune' ,
@Data_1_Type nvarchar(4) = 'MH00',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='CityOrDistrict'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq )
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='NSHK' ,
@Description VARCHAR(100)='Nashik' ,
@Data_1_Type nvarchar(4) = 'MH00',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='CityOrDistrict'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq )
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='MUMB' ,
@Description VARCHAR(100)='Mumbai' ,
@Data_1_Type nvarchar(4) = 'MH00',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='CityOrDistrict'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq )
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='NGPR' ,
@Description VARCHAR(100)='Nagpur' ,
@Data_1_Type nvarchar(4) = 'MH00',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='CityOrDistrict'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq )
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='BILL' ,
@Description VARCHAR(100)='Billing' ,
@Data_1_Type nvarchar(4) = NULL,
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='AddressType'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq )
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='SHIP' ,
@Description VARCHAR(100)='Shipping' ,
@Data_1_Type nvarchar(4) = NULL,
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='AddressType'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq )
END
GO

DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='PRIM' ,
@Description VARCHAR(100)='Primary' ,
@Data_1_Type nvarchar(4) = NULL,
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='ContactPersonType'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq )
END
GO

DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='SECO' ,
@Description VARCHAR(100)='Secondary' ,
@Data_1_Type nvarchar(4) = NULL,
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='ContactPersonType'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq )
END
GO
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='CUST' ,
@Description VARCHAR(100)='Customer' ,
@Data_1_Type nvarchar(4) = NULL,
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='ContactType'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='VEND' ,
@Description VARCHAR(100)='Vendor' ,
@Data_1_Type nvarchar(4) = NULL,
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='ContactType'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO




/************************Service Type*****************************************/
DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='SER1' ,
@Description VARCHAR(100)='Service Type 1' ,
@Data_1_Type nvarchar(4) = 'Service Type 1',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='ServiceType'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO

DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='SER2' ,
@Description VARCHAR(100)='Service Type 2' ,
@Data_1_Type nvarchar(4) = 'Service Type 2',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='ServiceType'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO

DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='SER3',
@Description VARCHAR(100)='Service Type 3' ,
@Data_1_Type nvarchar(4) = 'Service Type 3',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='ServiceType'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO

DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='SER4',
@Description VARCHAR(100)='Service Type 4',
@Data_1_Type nvarchar(4) = 'Service Type 4',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='ServiceType'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO

DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='SER5',
@Description VARCHAR(100)='Service Type 5' ,
@Data_1_Type nvarchar(4) = 'Service Type 5',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='ServiceType'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO
DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='SER6' ,
@Description VARCHAR(100)='Service Type 6' ,
@Data_1_Type nvarchar(4) = 'Service Type 6',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='ServiceType'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO

DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='SER7' ,
@Description VARCHAR(100)='Service Type 7' ,
@Data_1_Type nvarchar(4) = 'Service Type 7',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='ServiceType'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO

DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='SER8' ,
@Description VARCHAR(100)='Service Type 8' ,
@Data_1_Type nvarchar(4) = 'Service Type 8',
@Data_2_Caption nvarchar(100) = NULL,
@Data_2_Type  nvarchar(4) = NULL,
@Data_3_Caption  nvarchar(100) = NULL,
@Data_3_Type  nvarchar(4) = NULL,
@Comments  nvarchar(max) = NULL,
@Is_Active  bit = 1,
@Created_By  nvarchar(max) = 'SYSTEM',
@Created_On  datetime = GETDATE(),
@Modified_By  nvarchar(max) = 'SYSTEM',
@Modified_On  datetime = GETDATE(),
@Is_Deleted  bit = 0,
@Update_Seq INT= 0

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='ServiceType'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO

/**********************************************End*********************************************************/