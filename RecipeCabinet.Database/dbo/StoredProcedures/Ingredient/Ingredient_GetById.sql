--USE [localdb]
--GO
CREATE PROCEDURE Ingredient_GetById
    @Id INT
AS
BEGIN
SELECT i.[Id], i.[Name], it.[Name] FROM Ingredient i INNER JOIN IngredientType it ON i.Type = it.Id
WHERE i.[Id] = @Id
END
