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

:r .\SP\usp_DeleteService2.sql
go
:r .\SP\usp_DeleteService3.sql
go
:r .\SP\usp_DeleteService4.sql
go
:r .\SP\usp_DeleteService5.sql
go
:r .\SP\usp_DeleteService6.sql
go
:r .\SP\usp_DeleteService7.sql
go
:r .\SP\usp_DeleteService8.sql
go
:r .\SP\usp_DeleteServices1Section10BankMapping.sql
go
:r .\SP\usp_DeleteServices1Section1Master.sql
go
:r .\SP\usp_DeleteServices1Section4Master.sql
go
:r .\SP\usp_DeleteServices1Section5Master.sql
go
:r .\SP\usp_DeleteServices1Section6PriceMaster.sql
go
:r .\SP\usp_DeleteServices1Section8FAQMapping.sql
go
:r .\SP\usp_DeleteServices2Section2FAQMapping.sql
go
:r .\SP\usp_DeleteServices2Section3DownloadMaster.sql
go
:r .\SP\usp_DeleteServices2Section4Master.sql
go
:r .\SP\usp_DeleteServices3HeadingButtons.sql
go
:r .\SP\usp_DeleteServices3Section4.sql
go
:r .\SP\usp_DeleteServices3Section6PriceMaster.sql
go
:r .\SP\usp_DeleteServices4Section2FAQMapping.sql
go
:r .\SP\usp_DeleteServices4Section345Master.sql
go
:r .\SP\usp_DeleteServices4Section345MasterButtonsChild.sql
go
:r .\SP\usp_DeleteServices4Section345MasterFeaturesDetails.sql
go
:r .\SP\usp_DeleteServices4Section678FieldMaster.sql
go
:r .\SP\usp_DeleteServices4Section678FieldValues.sql
go
:r .\SP\usp_DeleteServices5Section2Master.sql
go
:r .\SP\usp_DeleteServices5Section2MasterFeaturesDetails.sql
go
:r .\SP\usp_DeleteServices6Section2Master.sql
go
:r .\SP\usp_DeleteServices6Section2MasterFeaturesDetails.sql
go
:r .\SP\usp_DeleteServices7HeadingButtons.sql
go
:r .\SP\usp_DeleteServices7Section4.sql
go
:r .\SP\usp_DeleteServices7Section6PriceMaster.sql
go
:r .\SP\usp_DeleteServices8HeadingButtons.sql
go
:r .\SP\usp_DeleteServices8Section6Master.sql
go
:r .\SP\usp_UpdatePageViewsReport.sql
go