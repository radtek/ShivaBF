﻿IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_DeleteServices1Section8FAQMapping')  
DROP PROCEDURE dbo.usp_DeleteServices1Section8FAQMapping  
GO
CREATE PROCEDURE [dbo].[usp_DeleteServices1Section8FAQMapping]
(
@serviceId BIGINT=NULL
)
AS
BEGIN
DECLARE @NumDeleted AS int;
    SET @NumDeleted = 0;
	SET NOCOUNT ON;
	 BEGIN TRANSACTION ucDelCand
	
	delete from Tbl_Services1Section8FAQMapping where Service_Id=@serviceId;
	
	SET @NumDeleted = @@ROWCOUNT;

    COMMIT TRANSACTION ucDelCand

    SELECT @NumDeleted;
END
Go