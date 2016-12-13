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

if(db_id(N'RevaShareDB') is not null)
begin
	drop database RevaShareDB;
end;

create database RevaShareDB;
go

use RevaShareDB;
go