IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteServices4Section345Master')  
DROP PROCEDURE dbo.usp_DeleteServices4Section345Master  
GO
CREATE PROCEDURE [dbo].[usp_DeleteServices4Section345Master]
(
@serviceId BIGINT=NULL
)
AS
BEGIN
DECLARE @NumDeleted AS int;
    SET @NumDeleted = 0;
	SET NOCOUNT ON;
	 BEGIN TRANSACTION ucDelCand
	delete from Tbl_Services4Section345MasterButtonsChild where S4S345M_id in (select Id as S4S345M_id from Tbl_Services4Section345Master where Service_Id=@serviceId );
	delete from Tbl_Services4Section345MasterFeaturesDetails where S4S345M_id in (select Id as S4S345M_id from Tbl_Services4Section345Master where Service_Id=@serviceId );
	delete from Tbl_Services4Section345Master where Service_Id=@serviceId;
		SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go