/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]	
--------------------------------------------------------------------------------------
*/

:r .\History\Tbl_Code_INSERT.sql
go

:r .\History\Tbl_CodeValue_INSERT.sql
go

:r .\History\Tbl_Message_INSERT.sql
go

:r .\History\AspNetRoles_INSERT.sql
go

:r .\History\AspNetUsers_INSERT.sql
go

:r .\History\AspNetUserRoles_INSERT.sql
go

:r .\History\Tbl_SubMenu_DEVELOPMENT_INSERT.sql
go

:r .\History\Tbl_SubMenu_TENANT_INSERT.sql
go

:r .\History\Tbl_AspNetRoles_SubMenu_INSERT.sql
go

:r .\History\Update_Or_Delete_Statements.sql
go

:r .\History\load_tempservices.sql
go

:r .\History\Tbl_StateMaster_INSERT.sql
go

:r .\History\load_Cat_Sub_SubSub.sql
go










:r .\SP\usp_GetChildMenu.sql
go

:r .\SP\usp_GetNavigationMenu.sql
go

:r .\SP\usp_HasAccess.sql
go

:r .\SP\usp_GetUpLineMenu.sql
go

:r .\SP\usp_DeleteService1.sql
go

:r .\SP\usp_UpdatePageViewsReport.sql
go