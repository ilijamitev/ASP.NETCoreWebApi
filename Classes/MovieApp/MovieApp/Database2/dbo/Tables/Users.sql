CREATE TABLE [dbo].[Users] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Username]  NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    [Password]  NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    [FirstName] NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    [LastName]  NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

