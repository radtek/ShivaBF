IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_GetUpLineMenu')  
DROP PROCEDURE dbo.usp_GetUpLineMenu  
GO
CREATE PROCEDURE dbo.usp_GetUpLineMenu
(
@Url VARCHAR(100)=null
) 
AS 
BEGIN

SET NOCOUNT ON;

;WITH UpLine(ID,MenuName, ParrentMenuID,[Url], [Level])
AS(
SELECT SM.ID,SM.[Name], SM.ParrentMenu_ID,sm.[Url],1 AS [Level] FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) WHERE SM.[Url]=@Url
UNION ALL 
SELECT SM.ID,SM.[NAME],SM.ParrentMenu_ID,sm.[Url],UpLine.[Level]+1 FROM dbo.Tbl_SubMenu SM WITH(NOLOCK) INNER JOIN UpLine ON SM.ID = UpLine.ParrentMenuID
)
SELECT ID,MenuName, ParrentMenuID,[Url],[Level] FROM  UpLine ORDER BY [Level] DESC

END
GO