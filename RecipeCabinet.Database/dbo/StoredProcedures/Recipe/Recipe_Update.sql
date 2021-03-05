CREATE PROCEDURE [Recipe_Update]
	@Id INT,
    @Name VARCHAR(50),
    @Description TEXT,
    @Servings INT
AS
BEGIN
UPDATE [Recipe]
SET 
    [Name] = @Name,
    [Description] = @Description,
    [Servings] = @Servings
WHERE [Id] = @Id
END
