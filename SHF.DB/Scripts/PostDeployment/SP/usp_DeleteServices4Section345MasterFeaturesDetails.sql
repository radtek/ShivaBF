IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteServices4Section345MasterFeaturesDetails')  
DROP PROCEDURE dbo.usp_DeleteServices4Section345MasterFeaturesDetails  
GO
CREATE PROCEDURE [dbo].[usp_DeleteServices4Section345MasterFeaturesDetails]
(
@serviceId BIGINT=NULL
)
AS
BEGIN
DECLARE @NumDeleted AS int;
    SET @NumDeleted = 0;
	SET NOCOUNT ON;
	 BEGIN TRANSACTION ucDelCand
	
	delete from Tbl_Services4Section345MasterFeaturesDetails where Service_Id=@serviceId;

	SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go