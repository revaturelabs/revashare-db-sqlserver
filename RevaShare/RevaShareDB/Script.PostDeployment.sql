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
insert into dbo.AspNetUsers(Id, Name, Email, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName) values
(N'754a9286-5759-47ae-9178-767d30720301', N'Admin',N'fred@revature.com', 1, 1, 0, 0, 0, N'fred@revature.com');
GO
insert into dbo.AspNetRoles(Id, Name) values (1, N'Admin');
GO
insert into dbo.AspNetUserRoles(UserId, RoleId) values (N'754a9286-5759-47ae-9178-767d30720301', 1);
GO