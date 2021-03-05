CREATE PROCEDURE [Rating_Create]
	@Message TEXT,
    @Rating INT,
    @Recipe INT
AS
BEGIN
INSERT INTO [Rating] (
    [CreatedOn],
    [LastUpdatedOn],
    [Message],
    [Rating],
    [Recipe]
)
OUTPUT Inserted.Id
VALUES (
    GETDATE(),
    GETDATE(),
    @Message,
    @Rating,
    @Recipe
)
END
