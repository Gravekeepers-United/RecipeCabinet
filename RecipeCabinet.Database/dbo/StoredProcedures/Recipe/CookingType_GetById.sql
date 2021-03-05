CREATE PROCEDURE [CookingType_GetById]
	@Id INT
AS
BEGIN
SELECT [Id], [Name], [Description]
FROM [CookingType]
WHERE [Id] = @Id
END
