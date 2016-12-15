CREATE TABLE [dbo].[AspNetRoles] (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO


CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    
);


GO


CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    
);


GO


CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
);


GO


CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Name]                 NVARCHAR (256) NULL,
    [Email]                NVARCHAR (256) NULL, 
    [ApartmentID]          INT  NULL,               
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([Name] ASC);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([UserName] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[AspNetUserRoles]([RoleId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserLogins]([UserId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserClaims]([UserId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserRoles]([UserId] ASC);
GO

ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO

CREATE TABLE [dbo].[Apartment] (
    [ID]  INT IDENTITY(1,1) NOT NULL,
    [Latitude] NVARCHAR (128) NOT NULL,
    [Longitude] NVARCHAR (128)  NOT NULL,
    [Name]  NVARCHAR (250) NOT NULL,    
    [Active]    BIT DEFAULT 1 NOT NULL,
    CONSTRAINT [PK_dbo.Apartment_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
);

GO

CREATE TABLE [dbo].[Vehicle](
  [ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  [OwnerID] NVARCHAR(128) NOT NULL,
  [Make]    NVARCHAR(128) NOT NULL,
  [Model]   NVARCHAR(128) NOT NULL,
  [LicensePlate] NVARCHAR(10) NOT NULL,
  [Color]   NVARCHAR (20)   NOT NULL,
  [Capacity] INT  NOT NULL,
  [Active]  BIT DEFAULT 1 NOT NULL
);
GO

CREATE TABLE[dbo].[Ride](
  [ID]  INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  [VehicleID] INT NOT NULL,
  [StartOfWeekDate] DATE  NOT NULL,
  [DepartureTime] TIME    NULL,
  [IsOnTime]  BIT         Default 1   NOT NULL,
  [Active]    BIT     DEFAULT 1 NOT NULL
);
GO

CREATE TABLE[dbo].[RideRiders](
  [RideID]   INT  NOT NULL,
  [RiderID] NVARCHAR(128) NOT NULL,
  [Accepted] BIT DEFAULT 0 NOT NULL,
  [Active]    BIT DEFAULT 1 NOT NULL,
  CONSTRAINT [PK_dbo.RideRiders] PRIMARY KEY CLUSTERED ([RideID] ASC, [RiderID] ASC),
);
GO

CREATE TABLE [dbo].[Flag](
  [ID]  INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  [DriverID] NVARCHAR(128) NOT NULL,
  [RiderID] NVARCHAR(128) NOT NULL,
  [Type]    NVARCHAR(30) NOT NULL,
  [Message] NVARCHAR(MAX) NOT NULL,
  [Active]  BIT DEFAULT 1 NOT NULL
);
GO

ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [FK_dbo.AspNetUsers_dbo.Apartments_ApartmentId] FOREIGN KEY ([ApartmentID]) REFERENCES [dbo].[Apartment] ([ID]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Vehicle]
ADD CONSTRAINT [FK_dbo.Vehicle_dbo.AspNetUsers_UserId] FOREIGN KEY ([OwnerID]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Ride]
ADD CONSTRAINT [FK_dbo.Ride_dbo.Vehicle_VehicleID] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([ID]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[RideRiders]
ADD CONSTRAINT [FK_dbo.RideRiders_dbo.Ride_ID] FOREIGN KEY ([RideID]) REFERENCES [dbo].[Ride] ([ID]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[RideRiders]
ADD CONSTRAINT [FK_dbo.RideRiders_dbo.AspNetUsers_UserId] FOREIGN KEY ([RiderID]) REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[Flag]
ADD CONSTRAINT [FK_dbo.Flag_dbo.AspNetUsers_DriverId] FOREIGN KEY ([DriverID]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Flag]
ADD CONSTRAINT [FK_dbo.Flag_dbo.AspNetUsers_RiderId] FOREIGN KEY ([RiderID]) REFERENCES [dbo].[AspNetUsers] ([Id])
GO