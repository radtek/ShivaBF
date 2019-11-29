IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteService7')  
DROP PROCEDURE dbo.usp_DeleteService7  
GO
CREATE PROCEDURE [dbo].[usp_DeleteService7]
(
@serviceId BIGINT=NULL
)
AS
BEGIN
DECLARE @NumDeleted AS int;
    SET @NumDeleted = 0;
	SET NOCOUNT ON;
	 BEGIN TRANSACTION ucDelCand
	delete from Tbl_Services7Section4 where Service_Id=@serviceId;
	delete from Tbl_Services7HeadingButtons where Service_Id=@serviceId;
	delete from Tbl_Services7Section6PriceMaster where Service_Id=@serviceId;
	delete from Tbl_Services7Master where Service_Id=@serviceId;
	SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go