IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteService5')  
DROP PROCEDURE dbo.usp_DeleteService5  
GO
CREATE PROCEDURE [dbo].[usp_DeleteService5]
(
@serviceId BIGINT=NULL
)
AS
BEGIN
DECLARE @NumDeleted AS int;
    SET @NumDeleted = 0;
	SET NOCOUNT ON;
	 BEGIN TRANSACTION ucDelCand
	delete from Tbl_Services5Section2MasterFeaturesDetails where Service_Id=@serviceId;
	delete from Tbl_Services5Section2Master where Service_Id=@serviceId;
	delete from Tbl_Services5Master where ID=@serviceId;
	SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go