IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteServices5Section2Master')  
DROP PROCEDURE dbo.usp_DeleteServices5Section2Master  
GO
CREATE PROCEDURE [dbo].[usp_DeleteServices5Section2Master]
(
@serviceId BIGINT=NULL
)
AS
BEGIN
DECLARE @NumDeleted AS int;
    SET @NumDeleted = 0;
	SET NOCOUNT ON;
	 BEGIN TRANSACTION ucDelCand
	delete from Tbl_Services5Section2MasterFeaturesDetails where S5S2M_Id in (select Id as S5S2M_Id from Tbl_Services5Section2Master where Service_Id=@serviceId );
	delete from Tbl_Services5Section2Master where Service_Id=@serviceId;
	SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go