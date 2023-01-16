CREATE TABLE [dbo].[ClientHistory]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [ParentId] INT NOT NULL, 
    [PrimarySystemAddressId] BIGINT NULL, 
    [BillingSystemAddressId] BIGINT NULL, 
    [PrimaryContactId] INT NOT NULL, 
    [PrimaryBillingContactId] INT NOT NULL, 
    [IsActive] BIT NOT NULL, 
    [Name] NVARCHAR(512) NULL
)
