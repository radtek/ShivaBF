IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteServices6Section2Master')  
DROP PROCEDURE dbo.usp_DeleteServices6Section2Master  
GO
CREATE PROCEDURE [dbo].[usp_DeleteServices6Section2Master]
(
@serviceId BIGINT=NULL
)
AS
BEGIN
DECLARE @NumDeleted AS int;
    SET @NumDeleted = 0;
	SET NOCOUNT ON;
	 BEGIN TRANSACTION ucDelCand
	delete from Tbl_Services6Section2MasterFeaturesDetails where S6S2M_Id in (select Id as S6S2M_Id from Tbl_Services6Section2Master where Service_Id=@serviceId );
	delete from Tbl_Services6Section2Master where Service_Id=@serviceId;
	SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go