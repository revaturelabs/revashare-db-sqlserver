/*
 Pre-Deployment Script Template              
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.  
 Use SQLCMD syntax to include a file in the pre-deployment script.      
 Example:      :r .\myfile.sql                
 Use SQLCMD syntax to reference a variable in the pre-deployment script.    
 Example:      :setvar TableName MyTable              
               SELECT * FROM [$(TableName)]          
--------------------------------------------------------------------------------------
*/
use master;
go

if(db_id(N'RevashareDB_DEV') is not null)
begin
	drop database RevashareDB_DEV;
end;

create database RevashareDB_DEV;
go

use RevashareDB_DEV;
go

create user sqlshare for login sqlshare;
exec sp_addrolemember N'db_owner', N'sqlshare';
go
