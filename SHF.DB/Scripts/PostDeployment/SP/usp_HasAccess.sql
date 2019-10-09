IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_HasAccess')  
DROP PROCEDURE dbo.usp_HasAccess  
GO
CREATE PROCEDURE  [dbo].[usp_HasAccess]
(
@UserId BIGINT = NULL,
@Url VARCHAR(MAX)=NULL,
@HasAccess BIT = 1
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from	
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 IF EXISTS(SELECT top 1 1 FROM [dbo].[Tbl_SubMenu] SM WITH(NOLOCK) INNER JOIN [dbo].[Tbl_AspNetRoles_SubMenu] RSM WITH(NOLOCK) ON SM.ID=RSM.SubMenu_ID
			   INNER JOIN [dbo].[AspNetRoles] R WITH(NOLOCK) ON RSM.AspNetRole_ID=R.Id
			   INNER JOIN [dbo].[AspNetUserRoles] UR WITH(NOLOCK) ON R.Id=UR.RoleId	
			   WHERE SM.[Url]=@Url AND UR.UserId = @UserId AND RSM.HasAccess = @HasAccess)
	BEGIN
		SELECT CAST(1 AS BIT)
	END
	ELSE
	BEGIN
		SELECT CAST(0 AS BIT)
	END
END
GO