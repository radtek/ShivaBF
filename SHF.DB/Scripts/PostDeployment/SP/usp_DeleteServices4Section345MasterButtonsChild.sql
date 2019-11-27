IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteServices4Section345MasterButtonsChild')  
DROP PROCEDURE dbo.usp_DeleteServices4Section345MasterButtonsChild  
GO
CREATE PROCEDURE [dbo].[usp_DeleteServices4Section345MasterButtonsChild]
(
@serviceId BIGINT=NULL
)
AS
BEGIN
DECLARE @NumDeleted AS int;
    SET @NumDeleted = 0;
	SET NOCOUNT ON;
	 BEGIN TRANSACTION ucDelCand

	delete from Tbl_Services4Section345MasterButtonsChild where Service_Id=@serviceId;

	delete from Tbl_Services4Master where ID=@serviceId;
	SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go