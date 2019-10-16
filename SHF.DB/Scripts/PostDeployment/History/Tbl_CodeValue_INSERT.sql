DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='INTI' ,
@Description VARCHAR(100)='Initiated' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Purchase Order Status'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='PRTL' ,
@Description VARCHAR(100)='Paritial' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Purchase Order Status'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='COMP' ,
@Description VARCHAR(100)='Completed' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Purchase Order Status'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='DAYS' ,
@Description VARCHAR(100)='Days From Purchase Order' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Expected Delivery Of Purchase Order'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='MNTH' ,
@Description VARCHAR(100)='Months From Purchase Order' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Expected Delivery Of Purchase Order'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='YEAR' ,
@Description VARCHAR(100)='Years From Purchase Order' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Expected Delivery Of Purchase Order'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='GOOD' ,
@Description VARCHAR(100)='Good' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Quality Of Inward Item'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='DFCT' ,
@Description VARCHAR(100)='Defected' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Quality Of Inward Item'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='EXPR' ,
@Description VARCHAR(100)='Expired' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Quality Of Inward Item'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO



DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='A128' ,
@Description VARCHAR(100)='Code128 auto' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO



DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='128A' ,
@Description VARCHAR(100)='Code128 A' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='128B' ,
@Description VARCHAR(100)='Code128 B' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='128C' ,
@Description VARCHAR(100)='Code128 C' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='EN13' ,
@Description VARCHAR(100)='EAN13' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='EAN8' ,
@Description VARCHAR(100)='EAN8' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='UPC' ,
@Description VARCHAR(100)='UPC' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='CD39' ,
@Description VARCHAR(100)='CODE39' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='IF14' ,
@Description VARCHAR(100)='ITF14' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='ITF' ,
@Description VARCHAR(100)='ITF' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='MSI' ,
@Description VARCHAR(100)='MSI' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='MI10' ,
@Description VARCHAR(100)='MSI10' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='MI11' ,
@Description VARCHAR(100)='MSI11' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='MS10' ,
@Description VARCHAR(100)='MSI1010' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='MS11' ,
@Description VARCHAR(100)='MSI1110' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='QCOD' ,
@Description VARCHAR(100)='QR Code' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Barcode Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='MH00' ,
@Description VARCHAR(100)='Maharashtra' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Source Of Supply'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='TLPH' ,
@Description VARCHAR(100)='Telephonic' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Reference Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO

DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='EMAL' ,
@Description VARCHAR(100)='Email' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Reference Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO

DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='PTOP' ,
@Description VARCHAR(100)='Person-To-Person' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Reference Type'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO




DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='INTI' ,
@Description VARCHAR(100)='Initiated' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Sales Order Status'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='PRTL' ,
@Description VARCHAR(100)='Paritial' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Sales Order Status'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='COMP' ,
@Description VARCHAR(100)='Completed' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Sales Order Status'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='CRUR' ,
@Description VARCHAR(100)='Courier' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Delivery Method'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='SELF' ,
@Description VARCHAR(100)='Self' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='Delivery Method'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq )
END
GO	


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


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='LINE' ,
@Description VARCHAR(100)='Linear Barcode' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='QRCD' ,
@Description VARCHAR(100)='QR Code' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='P417' ,
@Description VARCHAR(100)='Pfd 417' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='DTMT' ,
@Description VARCHAR(100)='Data Matrix' ,
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO



DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='CDBR' ,
@Description VARCHAR(100)='Coda Bar' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO



DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='C2O5' ,
@Description VARCHAR(100)='Code 2 Of 5' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='CD11' ,
@Description VARCHAR(100)='Code 11' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='CD39' ,
@Description VARCHAR(100)='Code 39' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='CD93' ,
@Description VARCHAR(100)='Code 93' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='C128' ,
@Description VARCHAR(100)='Code 128' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='EAN8' ,
@Description VARCHAR(100)='EAN 8' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='EN13' ,
@Description VARCHAR(100)='EAN 13' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='E128' ,
@Description VARCHAR(100)='GS1-128/EAN-128' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='I2O5' ,
@Description VARCHAR(100)='Interleaved 2 Of 5' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='IF14' ,
@Description VARCHAR(100)='ITF 14' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='MSIP' ,
@Description VARCHAR(100)='MSI Plessy' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='ONCD' ,
@Description VARCHAR(100)='One Code' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='PLNT' ,
@Description VARCHAR(100)='Planet' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='PONT' ,
@Description VARCHAR(100)='Postnet' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='RM4S' ,
@Description VARCHAR(100)='RM4SSC' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='UPCA' ,
@Description VARCHAR(100)='UPC-A' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_CodeValue CV WITH(NOLOCK) WHERE CV.Code_ID=@Code_ID AND CV.CodeValue=@CodeValue)
BEGIN
	INSERT INTO [dbo].[Tbl_CodeValue]([Code_ID],[CodeValue],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type],[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@Code_ID,@CodeValue ,@Description ,@Data_1_Type  ,@Data_2_Caption ,@Data_2_Type ,@Data_3_Caption ,@Data_3_Type , @Comments ,@Is_Active ,@Created_By ,@Created_On ,@Modified_By ,@Modified_On ,@Is_Deleted,@Update_Seq)
END
GO


DECLARE 
@Code_ID BIGINT=NULL ,
@CodeValue VARCHAR(4)='UPCE' ,
@Description VARCHAR(100)='UPC-E' ,
@Data_1_Type nvarchar(4) = 'LINE',
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

SELECT TOP 1 @Code_ID = C.ID FROM dbo.Tbl_Code C WITH(NOLOCK) WHERE C.Data_1_Caption ='BarcodeSubCategory'

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