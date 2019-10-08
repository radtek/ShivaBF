DECLARE    @Message_Code int=1,
		   @Description nvarchar(max)='Record saved successfully.', 
           @Title nvarchar(max)='Success', 
           @Type nvarchar(max)='Response', 
           @Icon nvarchar(max)='success', 
           @Is_Active bit=1, 
           @Update_Seq int=0, 
           @Created_By nvarchar(max)='SYSTEM', 
           @Created_On datetime=GETDATE(), 
           @Modified_By nvarchar(max)='SYSTEM', 
           @Modified_On datetime=GETDATE(), 
           @Is_Deleted bit=0 

IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_Message] M WITH(NOLOCK) WHERE M.Message_Code=@Message_Code)
BEGIN
	INSERT INTO [dbo].[Tbl_Message]([Message_Code],[Description],[Title],[Type],[Icon],[Is_Active],[Update_Seq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
     VALUES(@Message_Code,@Description,@Title,@Type,@Icon,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted)
END
GO

DECLARE    @Message_Code int=2,
		   @Description nvarchar(max)='SKU already exists.', 
           @Title nvarchar(max)='Error', 
           @Type nvarchar(max)='Validation', 
           @Icon nvarchar(max)='error', 
           @Is_Active bit=1, 
           @Update_Seq int=0, 
           @Created_By nvarchar(max)='SYSTEM', 
           @Created_On datetime=GETDATE(), 
           @Modified_By nvarchar(max)='SYSTEM', 
           @Modified_On datetime=GETDATE(), 
           @Is_Deleted bit=0 

IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_Message] M WITH(NOLOCK) WHERE M.Message_Code=@Message_Code)
BEGIN
	INSERT INTO [dbo].[Tbl_Message]([Message_Code],[Description],[Title],[Type],[Icon],[Is_Active],[Update_Seq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
     VALUES(@Message_Code,@Description,@Title,@Type,@Icon,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted)
END
GO

DECLARE    @Message_Code int=3,
		   @Description nvarchar(max)='Role already exists.', 
           @Title nvarchar(max)='Error', 
           @Type nvarchar(max)='Validation', 
           @Icon nvarchar(max)='error', 
           @Is_Active bit=1, 
           @Update_Seq int=0, 
           @Created_By nvarchar(max)='SYSTEM', 
           @Created_On datetime=GETDATE(), 
           @Modified_By nvarchar(max)='SYSTEM', 
           @Modified_On datetime=GETDATE(), 
           @Is_Deleted bit=0 

IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_Message] M WITH(NOLOCK) WHERE M.Message_Code=@Message_Code)
BEGIN
	INSERT INTO [dbo].[Tbl_Message]([Message_Code],[Description],[Title],[Type],[Icon],[Is_Active],[Update_Seq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
     VALUES(@Message_Code,@Description,@Title,@Type,@Icon,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted)
END
GO


DECLARE    @Message_Code int=4,
		   @Description nvarchar(max)='UOM already exists.', 
           @Title nvarchar(max)='Error', 
           @Type nvarchar(max)='Validation', 
           @Icon nvarchar(max)='error', 
           @Is_Active bit=1, 
           @Update_Seq int=0, 
           @Created_By nvarchar(max)='SYSTEM', 
           @Created_On datetime=GETDATE(), 
           @Modified_By nvarchar(max)='SYSTEM', 
           @Modified_On datetime=GETDATE(), 
           @Is_Deleted bit=0 

IF NOT EXISTS(SELECT 1 FROM [dbo].[Tbl_Message] M WITH(NOLOCK) WHERE M.Message_Code=@Message_Code)
BEGIN
	INSERT INTO [dbo].[Tbl_Message]([Message_Code],[Description],[Title],[Type],[Icon],[Is_Active],[Update_Seq],[Created_By],[Created_On],[Modified_By],[Modified_On],[Is_Deleted])
     VALUES(@Message_Code,@Description,@Title,@Type,@Icon,@Is_Active,@Update_Seq,@Created_By,@Created_On,@Modified_By,@Modified_On,@Is_Deleted)
END
GO
