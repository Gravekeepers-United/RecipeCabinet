CREATE PROCEDURE [RecipeIngredient_GetById]
	@Id INT
AS
BEGIN
SELECT [Recipe], [Ingredient], [Amount], [Measurement]
FROM [RecipeIngredient]
WHERE [Id] = @Id
END
