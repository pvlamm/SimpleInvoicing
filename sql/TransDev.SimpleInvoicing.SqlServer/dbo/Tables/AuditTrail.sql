CREATE TABLE [dbo].[AuditTrail] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    [Note]        NVARCHAR (1024) NULL,
    CONSTRAINT [PK_AuditTrail] PRIMARY KEY CLUSTERED ([Id] ASC)
);

