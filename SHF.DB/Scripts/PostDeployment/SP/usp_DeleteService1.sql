IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteService1')  
DROP PROCEDURE dbo.usp_DeleteService1  
GO
CREATE PROCEDURE [dbo].[usp_DeleteService1]
(
@serviceId BIGINT=NULL
)
AS
BEGIN
DECLARE @NumDeleted AS int;
    SET @NumDeleted = 0;
	SET NOCOUNT ON;
	 BEGIN TRANSACTION ucDelCand
	delete from Tbl_Services1Section10BankMapping where Service_Id=@serviceId;
	delete from Tbl_Services1Section1Master where Service_Id=@serviceId;
	delete from Tbl_Services1Section4Master where Service_Id=@serviceId;
	delete from Tbl_Services1Section5Master where Service_Id=@serviceId;
	delete from Tbl_Services1Section6PriceMaster where Service_Id=@serviceId;
	delete from Tbl_Services1Section8FAQMapping where Service_Id=@serviceId;
	SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go