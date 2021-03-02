CREATE PROCEDURE [IngredientType_GetById]
	@Id int
AS
BEGIN
SELECT [Id], [Name]
FROM [IngredientType]
WHERE [Id] = @Id;
END
