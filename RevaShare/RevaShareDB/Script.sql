
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
  [IsAmRide] BIT NOT NULL,
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

CREATE TABLE [dbo].[UserInfo](
  [UserID]  NVARCHAR(128) PRIMARY KEY NOT NULL,
  [ApartmentID] INT NOT NULL,
  [Name]  NVARCHAR(50)  NOT NULL,
  [Email] NVARCHAR(50)  NOT NULL,
  [Phone] NVARCHAR(20)  NOT NULL
);
GO

ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [FK_dbo.UserInfo_dbo.Apartments_ApartmentId] FOREIGN KEY ([ApartmentID]) REFERENCES [dbo].[Apartment] ([ID]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Vehicle]
ADD CONSTRAINT [FK_dbo.Vehicle_dbo.UserInfo_UserId] FOREIGN KEY ([OwnerID]) REFERENCES [dbo].[UserInfo] ([UserID]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Ride]
ADD CONSTRAINT [FK_dbo.Ride_dbo.Vehicle_VehicleID] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([ID]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[RideRiders]
ADD CONSTRAINT [FK_dbo.RideRiders_dbo.Ride_ID] FOREIGN KEY ([RideID]) REFERENCES [dbo].[Ride] ([ID]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[RideRiders]
ADD CONSTRAINT [FK_dbo.RideRiders_dbo.UserInfo_UserId] FOREIGN KEY ([RiderID]) REFERENCES [dbo].[UserInfo] ([UserID])
GO

ALTER TABLE [dbo].[Flag]
ADD CONSTRAINT [FK_dbo.Flag_dbo.UserInfo_DriverId] FOREIGN KEY ([DriverID]) REFERENCES [dbo].[UserInfo]([UserID]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Flag]
ADD CONSTRAINT [FK_dbo.Flag_dbo.UserInfo_RiderId] FOREIGN KEY ([RiderID]) REFERENCES [dbo].[UserInfo]([UserID])
GO