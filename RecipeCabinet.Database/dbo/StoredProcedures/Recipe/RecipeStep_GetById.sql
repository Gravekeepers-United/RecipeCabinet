CREATE PROCEDURE [dbo].[RecipeStep_GetById]
	@Id INT
AS
BEGIN
SELECT [Recipe], [Description], [Order], [Type]
FROM [RecipeStep]
WHERE [Id] = @Id
END
