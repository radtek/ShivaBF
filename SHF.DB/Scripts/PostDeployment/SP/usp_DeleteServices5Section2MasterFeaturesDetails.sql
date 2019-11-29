IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteServices5Section2MasterFeaturesDetails')  
DROP PROCEDURE dbo.usp_DeleteServices5Section2MasterFeaturesDetails  
GO
CREATE PROCEDURE [dbo].[usp_DeleteServices5Section2MasterFeaturesDetails]
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
	
	SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go