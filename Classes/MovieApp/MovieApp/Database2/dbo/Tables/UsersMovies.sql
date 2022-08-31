CREATE TABLE [dbo].[UsersMovies] (
    [UserId]  INT NOT NULL,
    [MovieId] INT NOT NULL,
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_UsersMovies] PRIMARY KEY CLUSTERED ([MovieId] ASC, [UserId] ASC),
    CONSTRAINT [FK_UsersMovies_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movies] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UsersMovies_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UsersMovies_UserId]
    ON [dbo].[UsersMovies]([UserId] ASC);

