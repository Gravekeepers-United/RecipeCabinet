CREATE PROCEDURE [IngredientType_Update]
	@Id INT,
    @Name VARCHAR (50)
AS
BEGIN
UPDATE [IngredientType]
SET [Name] = @Name
WHERE [Id] = @Id;
END
