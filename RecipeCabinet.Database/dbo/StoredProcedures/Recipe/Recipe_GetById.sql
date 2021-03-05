CREATE PROCEDURE [Recipe_GetById]
	@Id INT
AS
BEGIN
SELECT [Name], [Description], [Servings]
FROM [Recipe]
WHERE [Id] = @Id
END
