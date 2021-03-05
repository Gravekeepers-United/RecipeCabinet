CREATE PROCEDURE [RecipeIngredient_Delete]
	@Id INT
AS
BEGIN
DELETE FROM [RecipeIngredient]
WHERE [Id] = @Id
END
