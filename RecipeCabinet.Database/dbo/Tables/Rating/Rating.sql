CREATE TABLE Review (
    [Id] INT NOT NULL IDENTITY,
    [CreatedOn] DATETIME2,
    [LastUpdatedOn] DATETIME2,
    [Message] TEXT NOT NULL,
    [Rating] INT NOT NULL,
    [Recipe] INT NOT NULL, 
    CONSTRAINT [PK_Id_Review] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Review_Order] FOREIGN KEY ([Recipe]) REFERENCES Recipe([Id])
)

-- FUTURE UPDATES: USER ACCOUNT/AUTHOR
