DELETE FROM dbo.Tbl_AspNetRoles_SubMenu 
DBCC CHECKIDENT ('dbo.Tbl_AspNetRoles_SubMenu', RESEED, 0)

DELETE FROM dbo.Tbl_SubMenu
DBCC CHECKIDENT ('dbo.Tbl_SubMenu', RESEED, 0)