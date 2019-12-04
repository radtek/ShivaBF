IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteService8')  
DROP PROCEDURE dbo.usp_DeleteService8  
GO
CREATE PROCEDURE [dbo].[usp_DeleteService8]
(
@serviceId BIGINT=NULL
)
AS
BEGIN
DECLARE @NumDeleted AS int;
    SET @NumDeleted = 0;
	SET NOCOUNT ON;
	 BEGIN TRANSACTION ucDelCand
	delete from Tbl_Services8HeadingButtons where Service_Id=@serviceId;
	delete from Tbl_Services8Section6Master where Service_Id=@serviceId;
    delete from Tbl_Services8Master where ID=@serviceId;
	SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go