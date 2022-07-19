USE [master]

IF db_id('RollForQuirk') IS NULl
  CREATE DATABASE [RollForQuirk]
GO

USE [RollForQuirk]
GO

DROP TABLE IF EXISTS [CharacterTrait];
DROP TABLE IF EXISTS [Character];
DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [Trait];
DROP TABLE IF EXISTS [Profession];
DROP TABLE IF EXISTS [Race];
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

CREATE TABLE [Trait] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [CharacterTrait] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Character] (
  [Id] int PRIMARY KEY NOT NULL,
  [CharacterName] nvarchar(255) NOT NULL,
  [ProfessionId] int NOT NULL,
  [RaceId] int NOT NULL,
  [AlignmentId] int NOT NULL,
  [UserProfileId] int NOT NULL
)
GO

CREATE TABLE [CharacterTrait] (
  [Id] int PRIMARY KEY,
  [TraitId] int NOT NULL,
  [CharacterId] int NOT NULL
)
GO

ALTER TABLE [Character] ADD FOREIGN KEY ([ProfessionId]) REFERENCES [Profession] ([Id])
GO

ALTER TABLE [Character] ADD FOREIGN KEY ([RaceId]) REFERENCES [Race] ([Id])
GO

ALTER TABLE [Character] ADD FOREIGN KEY ([AlignmentId]) REFERENCES [Alignment] ([Id])
GO

ALTER TABLE [CharacterTrait] ADD FOREIGN KEY ([TraitId]) REFERENCES [Trait] ([Id])
GO

ALTER TABLE [Character] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

ALTER TABLE [CharacterTrait] ADD FOREIGN KEY ([CharacterId]) REFERENCES [Character] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO
