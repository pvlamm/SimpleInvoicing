IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AuditTrail] (
    [Id] bigint NOT NULL IDENTITY,
    [CreatedDate] datetime2 NOT NULL,
    [Note] nvarchar(1024) NULL,
    CONSTRAINT [PK_AuditTrail] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Client] (
    [Id] int NOT NULL IDENTITY,
    [ClientType] int NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Item] (
    [Id] int NOT NULL IDENTITY,
    [Code] nvarchar(16) NOT NULL,
    [Type] int NOT NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [SystemState] (
    [Id] nvarchar(2) NOT NULL,
    [Name] nvarchar(26) NOT NULL,
    CONSTRAINT [PK_SystemState] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Contact] (
    [Id] int NOT NULL IDENTITY,
    [ClientId] int NOT NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contact_Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Client] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [ItemHistory] (
    [Id] bigint NOT NULL IDENTITY,
    [ParentId] int NOT NULL,
    [Description] nvarchar(2048) NULL,
    [Price] int NOT NULL,
    [AuditTrailId] bigint NOT NULL,
    [UpdatedAuditTrailId] bigint NULL,
    CONSTRAINT [PK_ItemHistory] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ItemHistory_AuditTrail_AuditTrailId] FOREIGN KEY ([AuditTrailId]) REFERENCES [AuditTrail] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ItemHistory_AuditTrail_UpdatedAuditTrailId] FOREIGN KEY ([UpdatedAuditTrailId]) REFERENCES [AuditTrail] ([Id]),
    CONSTRAINT [FK_ItemHistory_Item_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [Item] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [SystemCity] (
    [Id] int NOT NULL IDENTITY,
    [SystemStateId] nvarchar(2) NULL,
    [Name] nvarchar(85) NOT NULL,
    CONSTRAINT [PK_SystemCity] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SystemCity_SystemState_SystemStateId] FOREIGN KEY ([SystemStateId]) REFERENCES [SystemState] ([Id])
);
GO

CREATE TABLE [SystemAddress] (
    [Id] bigint NOT NULL IDENTITY,
    [SystemCityId] int NOT NULL,
    [SystemStateId] nvarchar(2) NULL,
    [Address] nvarchar(50) NOT NULL,
    [ZipCode] nvarchar(10) NOT NULL,
    CONSTRAINT [PK_SystemAddress] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SystemAddress_SystemCity_SystemCityId] FOREIGN KEY ([SystemCityId]) REFERENCES [SystemCity] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SystemAddress_SystemState_SystemStateId] FOREIGN KEY ([SystemStateId]) REFERENCES [SystemState] ([Id])
);
GO

CREATE TABLE [ClientHistory] (
    [Id] bigint NOT NULL IDENTITY,
    [ParentId] int NOT NULL,
    [PrimarySystemAddressId] bigint NOT NULL,
    [BillingSystemAddressId] bigint NOT NULL,
    [PrimaryContactId] int NOT NULL,
    [PrimaryBillingContactId] int NOT NULL,
    [IsActive] bit NOT NULL,
    [Name] nvarchar(65) NOT NULL,
    [AuditTrailId] bigint NOT NULL,
    [UpdatedAuditTrailId] bigint NULL,
    CONSTRAINT [PK_ClientHistory] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ClientHistory_AuditTrail_AuditTrailId] FOREIGN KEY ([AuditTrailId]) REFERENCES [AuditTrail] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ClientHistory_AuditTrail_UpdatedAuditTrailId] FOREIGN KEY ([UpdatedAuditTrailId]) REFERENCES [AuditTrail] ([Id]),
    CONSTRAINT [FK_ClientHistory_Client_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [Client] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ClientHistory_Contact_PrimaryBillingContactId] FOREIGN KEY ([PrimaryBillingContactId]) REFERENCES [Contact] ([Id]),
    CONSTRAINT [FK_ClientHistory_Contact_PrimaryContactId] FOREIGN KEY ([PrimaryContactId]) REFERENCES [Contact] ([Id]),
    CONSTRAINT [FK_ClientHistory_SystemAddress_BillingSystemAddressId] FOREIGN KEY ([BillingSystemAddressId]) REFERENCES [SystemAddress] ([Id]),
    CONSTRAINT [FK_ClientHistory_SystemAddress_PrimarySystemAddressId] FOREIGN KEY ([PrimarySystemAddressId]) REFERENCES [SystemAddress] ([Id])
);
GO

CREATE TABLE [ContactHistory] (
    [Id] bigint NOT NULL IDENTITY,
    [ParentId] int NOT NULL,
    [SystemAddressId] bigint NOT NULL,
    [FirstName] nvarchar(55) NOT NULL,
    [MiddleName] nvarchar(55) NOT NULL,
    [LastName] nvarchar(55) NOT NULL,
    [EmailAddress] nvarchar(120) NOT NULL,
    [PhoneNumber] nvarchar(15) NOT NULL,
    [AuditTrailId] bigint NOT NULL,
    [UpdatedAuditTrailId] bigint NULL,
    CONSTRAINT [PK_ContactHistory] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ContactHistory_AuditTrail_AuditTrailId] FOREIGN KEY ([AuditTrailId]) REFERENCES [AuditTrail] ([Id]),
    CONSTRAINT [FK_ContactHistory_AuditTrail_UpdatedAuditTrailId] FOREIGN KEY ([UpdatedAuditTrailId]) REFERENCES [AuditTrail] ([Id]),
    CONSTRAINT [FK_ContactHistory_Contact_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [Contact] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ContactHistory_SystemAddress_SystemAddressId] FOREIGN KEY ([SystemAddressId]) REFERENCES [SystemAddress] ([Id])
);
GO

CREATE INDEX [IX_ClientHistory_AuditTrailId] ON [ClientHistory] ([AuditTrailId]);
GO

CREATE INDEX [IX_ClientHistory_BillingSystemAddressId] ON [ClientHistory] ([BillingSystemAddressId]);
GO

CREATE INDEX [IX_ClientHistory_ParentId] ON [ClientHistory] ([ParentId]);
GO

CREATE INDEX [IX_ClientHistory_PrimaryBillingContactId] ON [ClientHistory] ([PrimaryBillingContactId]);
GO

CREATE INDEX [IX_ClientHistory_PrimaryContactId] ON [ClientHistory] ([PrimaryContactId]);
GO

CREATE INDEX [IX_ClientHistory_PrimarySystemAddressId] ON [ClientHistory] ([PrimarySystemAddressId]);
GO

CREATE INDEX [IX_ClientHistory_UpdatedAuditTrailId] ON [ClientHistory] ([UpdatedAuditTrailId]);
GO

CREATE INDEX [IX_Contact_ClientId] ON [Contact] ([ClientId]);
GO

CREATE INDEX [IX_ContactHistory_AuditTrailId] ON [ContactHistory] ([AuditTrailId]);
GO

CREATE INDEX [IX_ContactHistory_ParentId] ON [ContactHistory] ([ParentId]);
GO

CREATE INDEX [IX_ContactHistory_SystemAddressId] ON [ContactHistory] ([SystemAddressId]);
GO

CREATE INDEX [IX_ContactHistory_UpdatedAuditTrailId] ON [ContactHistory] ([UpdatedAuditTrailId]);
GO

CREATE INDEX [IX_ItemHistory_AuditTrailId] ON [ItemHistory] ([AuditTrailId]);
GO

CREATE INDEX [IX_ItemHistory_ParentId] ON [ItemHistory] ([ParentId]);
GO

CREATE INDEX [IX_ItemHistory_UpdatedAuditTrailId] ON [ItemHistory] ([UpdatedAuditTrailId]);
GO

CREATE INDEX [IX_SystemAddress_SystemCityId] ON [SystemAddress] ([SystemCityId]);
GO

CREATE INDEX [IX_SystemAddress_SystemStateId] ON [SystemAddress] ([SystemStateId]);
GO

CREATE INDEX [IX_SystemCity_SystemStateId] ON [SystemCity] ([SystemStateId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220925193422_001-Init', N'6.0.8');
GO

COMMIT;
GO

