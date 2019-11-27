IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteServices3HeadingButtons')  
DROP PROCEDURE dbo.usp_DeleteServices3HeadingButtons  
GO
CREATE PROCEDURE [dbo].[usp_DeleteServices3HeadingButtons]
(
@serviceId BIGINT=NULL
)
AS
BEGIN
DECLARE @NumDeleted AS int;
    SET @NumDeleted = 0;
	SET NOCOUNT ON;
	 BEGIN TRANSACTION ucDelCand
	delete from Tbl_Services3HeadingButtons where Service_Id=@serviceId;
	
	SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go