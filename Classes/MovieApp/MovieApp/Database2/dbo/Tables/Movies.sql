CREATE TABLE [dbo].[Movies] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    [Description] NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    [Year]        INT            NOT NULL,
    [Genre]       INT            NOT NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED ([Id] ASC)
);

