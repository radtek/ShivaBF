DECLARE @ID BIGINT =1001,
@Data_1_Caption VARCHAR(100)='Purchase Order Status',
@Description VARCHAR(1000)='Purchase Order Status Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT=0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO


DECLARE @ID BIGINT =1002,
@Data_1_Caption VARCHAR(100)='Expected Delivery Of Purchase Order',
@Description VARCHAR(1000)='Expected Delivery Of Purchase Order Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT=0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO




DECLARE @ID BIGINT =1003,
@Data_1_Caption VARCHAR(100)='Quality Of Inward Item',
@Description VARCHAR(1000)='Quality Of Inward Item Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT=0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO



DECLARE @ID BIGINT =1004,
@Data_1_Caption VARCHAR(100)='Barcode Type',
@Description VARCHAR(1000)='Barcode Type Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT=0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO



DECLARE @ID BIGINT =1005,
@Data_1_Caption VARCHAR(100)='Source Of Supply',
@Description VARCHAR(1000)='Source Of Supply Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT=0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO



DECLARE @ID BIGINT =1006,
@Data_1_Caption VARCHAR(100)='Reference Type',
@Description VARCHAR(1000)='Reference Type Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT=0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO



DECLARE @ID BIGINT =1007,
@Data_1_Caption VARCHAR(100)='Delivery Method',
@Description VARCHAR(1000)='Delivery Method Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT=0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO



DECLARE @ID BIGINT =1008,
@Data_1_Caption VARCHAR(100)='Sales Order Status',
@Description VARCHAR(1000)='Sales Order Status Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT=0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO



DECLARE @ID BIGINT =1009,
@Data_1_Caption VARCHAR(100)='Country',
@Description VARCHAR(1000)='Country Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT= 0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO



DECLARE @ID BIGINT =1010,
@Data_1_Caption VARCHAR(100)='State',
@Description VARCHAR(1000)='State Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT= 0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO


DECLARE @ID BIGINT =1011,
@Data_1_Caption VARCHAR(100)='CityOrDistrict',
@Description VARCHAR(1000)='City Or District Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT= 0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO



DECLARE @ID BIGINT =1012,
@Data_1_Caption VARCHAR(100)='AddressType',
@Description VARCHAR(1000)='Address Type Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT= 0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO


DECLARE @ID BIGINT =1013,
@Data_1_Caption VARCHAR(100)='ContactPersonType',
@Description VARCHAR(1000)='Contact Person Type ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT= 0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO


DECLARE @ID BIGINT =1014,
@Data_1_Caption VARCHAR(100)='ContactType ',
@Description VARCHAR(1000)='Contact Type Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT=0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO


DECLARE @ID BIGINT =1015,
@Data_1_Caption VARCHAR(100)='BarcodeCategory',
@Description VARCHAR(1000)='Barcode Category Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT=0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO


DECLARE @ID BIGINT =1016,
@Data_1_Caption VARCHAR(100)='BarcodeSubCategory',
@Description VARCHAR(1000)='Barcode Sub Category Code ID',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT=0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO

DECLARE @ID BIGINT =1020,
@Data_1_Caption VARCHAR(100)='ServiceType',
@Description VARCHAR(1000)='Service Type For SubSubCategories',
@Data_1_Type VARCHAR(10) = NULL,
@Data_2_Caption VARCHAR(10) = NULL,
@Data_2_Type VARCHAR(10) = NULL,
@Data_3_Caption VARCHAR(10) = NULL,
@Data_3_Type VARCHAR(10) = NULL,
@Comments VARCHAR(10) = NULL,
@Is_Active BIT = 1,
@Created_By VARCHAR(10) = 'SYSTEM',
@Created_On DATETIME = GETDATE(),
@Modified_By VARCHAR(10) = 'SYSTEM',
@Modified_On DATETIME = GETDATE(),
@Is_Deleted BIT = 0,
@Update_Seq INT=0

IF NOT EXISTS(SELECT 1 FROM dbo.Tbl_Code C WHERE C.ID=@ID AND C.Data_1_Caption=@Data_1_Caption)
BEGIN
	INSERT INTO [dbo].[Tbl_Code]([ID],[Data_1_Caption],[Description],[Data_1_Type],[Data_2_Caption],[Data_2_Type],[Data_3_Caption],[Data_3_Type]
	           ,[Comments],[Is_Active],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted],[Update_Seq])
	VALUES(@ID,@Data_1_Caption,@Description,@Data_1_Type,@Data_2_Caption,@Data_2_Type,@Data_3_Caption,@Data_3_Type,@Comments,@Is_Active,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted,@Update_Seq)
END
GO