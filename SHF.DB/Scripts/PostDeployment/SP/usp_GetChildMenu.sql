IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_GetChildMenu')  
DROP PROCEDURE dbo.usp_GetChildMenu  
GO
CREATE PROCEDURE [dbo].[usp_GetChildMenu]
(
@UserId BIGINT=NULL,
@ParrentMenu_ID BIGINT=NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Distinct CM.* FROM dbo.Tbl_SubMenu PM WITH(NOLOCK) INNER JOIN dbo.Tbl_SubMenu CM WITH(NOLOCK) ON PM.ID=CM.ParrentMenu_ID
		INNER JOIN dbo.Tbl_AspNetRoles_SubMenu RM WITH(NOLOCK) ON RM.SubMenu_ID = CM.ID
		INNER JOIN dbo.AspNetRoles R WITH(NOLOCK) ON RM.AspNetRole_ID=R.Id
		INNER JOIN dbo.AspNetUserRoles UR WITH(NOLOCK) ON r.Id=UR.RoleId
		WHERE UR.UserId=@UserId AND RM.[HasAccess] = 1 AND CM.ParrentMenu_ID=@ParrentMenu_ID
		ORDER BY CM.OrderBy ASC
END
Go