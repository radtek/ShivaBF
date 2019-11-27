IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteService2')  
DROP PROCEDURE dbo.usp_DeleteService2  
GO
CREATE PROCEDURE [dbo].[usp_DeleteService2]
(
@serviceId BIGINT=NULL
)
AS
BEGIN
DECLARE @NumDeleted AS int;
    SET @NumDeleted = 0;
	SET NOCOUNT ON;
	 BEGIN TRANSACTION ucDelCand
	delete from Tbl_Services2Section2FAQMapping where Service_Id=@serviceId;
	delete from Tbl_Services2Section3DownloadMaster where Service_Id=@serviceId;
	delete from Tbl_Services2Section4Master where Service_Id=@serviceId;
	delete from Tbl_Services2Master where ID=@serviceId;
	SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go