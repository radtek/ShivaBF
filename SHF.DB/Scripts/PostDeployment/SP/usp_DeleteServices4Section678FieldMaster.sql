IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteServices4Section678FieldMaster')  
DROP PROCEDURE dbo.usp_DeleteServices4Section678FieldMaster  
GO
CREATE PROCEDURE [dbo].[usp_DeleteServices4Section678FieldMaster]
(
@serviceId BIGINT=NULL
)
AS
BEGIN
DECLARE @NumDeleted AS int;
    SET @NumDeleted = 0;
	SET NOCOUNT ON;
	 BEGIN TRANSACTION ucDelCand
	
	delete from Tbl_Services4Section678FieldValues where Service_Id=@serviceId;
	delete from Tbl_Services4Section678FieldMaster where Service_Id=@serviceId;
	
	SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go