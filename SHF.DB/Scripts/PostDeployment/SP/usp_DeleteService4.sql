IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteService4')  
DROP PROCEDURE dbo.usp_DeleteService4  
GO
CREATE PROCEDURE [dbo].[usp_DeleteService4]
(
@serviceId BIGINT=NULL
)
AS
BEGIN
DECLARE @NumDeleted AS int;
    SET @NumDeleted = 0;
	SET NOCOUNT ON;
	 BEGIN TRANSACTION ucDelCand
	delete from Tbl_Services4Section2FAQMapping where Service_Id=@serviceId;
	delete from Tbl_Services4Section345MasterButtonsChild where Service_Id=@serviceId;
	delete from Tbl_Services4Section345MasterFeaturesDetails where Service_Id=@serviceId;
	delete from Tbl_Services4Section345Master where Service_Id=@serviceId;
	delete from Tbl_Services4Section678FieldValues where Service_Id=@serviceId;
	delete from Tbl_Services4Section678FieldMaster where Service_Id=@serviceId;
	delete from Tbl_Services4Master where ID=@serviceId;
	SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go