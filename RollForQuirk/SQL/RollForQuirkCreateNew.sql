USE [master]

IF db_id('RollForQuirk') IS NULl
  CREATE DATABASE [RollForQuirk]
GO

USE [RollForQuirk]
GO

DROP TABLE IF EXISTS [Character];
DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [Trait];
DROP TABLE IF EXISTS [Profession];
DROP TABLE IF EXISTS [Race];
DROP TABLE IF EXISTS [Quirk];
DROP TABLE IF EXISTS [Stress];
DROP TABLE IF EXISTS [Fear];
DROP TABLE IF EXISTS [Flaw];
DROP TABLE IF EXISTS [QuirkFragment];
DROP TABLE IF EXISTS [Drive];
DROP TABLE IF EXISTS [DriveFragment];
DROP TABLE IF EXISTS [Alignment];

GO

CREATE TABLE [UserProfile] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Email] nvarchar(255) NOT NULL,
  [FirebaseId] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Profession] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [CharacterProfession] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Race] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [CharacterRace] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Alignment] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [CharacterAlignment] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Quirk] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [CharacterQuirk] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Stress] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [StressedCharacteristic] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Fear] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [FearCharacteristic] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Flaw] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [FlawCharacteristic] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [QuirkFragment] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [FragmentOne] nvarchar(255),
  [FragmentTwo] nvarchar(255),
)
GO

CREATE TABLE [Drive] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [DriveTrait] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [DriveFragment] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [FragmentOne] nvarchar(255),
  [FragmentTwo] nvarchar(255),
)
GO

CREATE TABLE [Character] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [CharacterName] nvarchar(255) NOT NULL,
  [ProfessionId] int NOT NULL,
  [RaceId] int NOT NULL,
  [AlignmentId] int NOT NULL,
  [StressId] int NOT NULL,
  [FearId] int NOT NULL,
  [FlawId] int NOT NULL,
  [UserProfileId] int NOT NULL,
  [CharacterDrive] nvarchar(255),
  [QuirkOne] nvarchar(255),
  [QuirkTwo] nvarchar(255),
  [QuirkThree] nvarchar(255)
)
GO

ALTER TABLE [Character] ADD FOREIGN KEY ([ProfessionId]) REFERENCES [Profession] ([Id])
GO

ALTER TABLE [Character] ADD FOREIGN KEY ([RaceId]) REFERENCES [Race] ([Id])
GO

ALTER TABLE [Character] ADD FOREIGN KEY ([AlignmentId]) REFERENCES [Alignment] ([Id])
GO

ALTER TABLE [Character] ADD FOREIGN KEY ([StressId]) REFERENCES [Stress] ([Id])
GO

ALTER TABLE [Character] ADD FOREIGN KEY ([FearId]) REFERENCES [Fear] ([Id])
GO

ALTER TABLE [Character] ADD FOREIGN KEY ([FlawId]) REFERENCES [Flaw] ([Id])
GO

ALTER TABLE [Character] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO
