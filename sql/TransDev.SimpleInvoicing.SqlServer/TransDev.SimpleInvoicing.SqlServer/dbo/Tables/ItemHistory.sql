CREATE TABLE [dbo].[ItemHistory] (
    [Id]                  BIGINT          IDENTITY (1, 1) NOT NULL,
    [ParentId]            INT             NOT NULL,
    [AuditTrailId]        BIGINT          NOT NULL,
    [UpdatedAuditTrailId] BIGINT          NULL,
    [Description]         NVARCHAR (2048) NULL,
    [Price]               INT             NOT NULL,
    CONSTRAINT [PK_ItemHistory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ItemHistory_AuditTrail_AuditTrailId] FOREIGN KEY ([AuditTrailId]) REFERENCES [dbo].[AuditTrail] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ItemHistory_AuditTrail_UpdatedAuditTrailId] FOREIGN KEY ([UpdatedAuditTrailId]) REFERENCES [dbo].[AuditTrail] ([Id]),
    CONSTRAINT [FK_ItemHistory_Item_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Item] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ItemHistory_UpdatedAuditTrailId]
    ON [dbo].[ItemHistory]([UpdatedAuditTrailId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ItemHistory_ParentId]
    ON [dbo].[ItemHistory]([ParentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ItemHistory_AuditTrailId]
    ON [dbo].[ItemHistory]([AuditTrailId] ASC);

