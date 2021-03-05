CREATE PROCEDURE [Rating_Update]
	@Id INT,
	@Message TEXT,
    @Rating INT,
    @Recipe INT
AS
BEGIN
UPDATE [Rating]
SET 
    [LastUpdatedOn] = GETDATE(),
    [Message] = @Message,
    [Rating] = @Rating,
    [Recipe] = @Recipe
    
    WHERE [Id] = @Id;
END
