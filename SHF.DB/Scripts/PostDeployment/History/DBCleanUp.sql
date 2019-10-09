
DECLARE @sql1 NVARCHAR(MAX) = N'';
SELECT @sql1 += N'ALTER TABLE ' + QUOTENAME(OBJECT_SCHEMA_NAME(parent_object_id)) + '.' + QUOTENAME(OBJECT_NAME(parent_object_id)) + ' DROP CONSTRAINT ' + QUOTENAME(name) + '; ' FROM sys.foreign_keys;
PRINT @sql1;
EXEC sp_executesql @sql1;


DECLARE @sql2 NVARCHAR(MAX) = N'';
SELECT @sql2 += N'DROP TABLE dbo.' + sobjects.name + '; ' FROM sysobjects sobjects WHERE sobjects.xtype='U';
PRINT @sql2;
EXEC sp_executesql @sql2;


DECLARE @sql3 NVARCHAR(MAX) = N'';
SELECT @sql3 += N'DROP PROCEDURE dbo.' + SPECIFIC_NAME + '; ' FROM information_schema.routines WHERE routine_type = 'PROCEDURE' and Left(Routine_Name, 3) NOT IN ('sp_', 'xp_', 'ms_');
PRINT @sql3;
EXEC sp_executesql @sql3;
