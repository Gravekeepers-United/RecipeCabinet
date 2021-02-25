--USE [localdb]
--GO
CREATE PROCEDURE Ingredient_GetById
    @Id INT
AS
BEGIN
SELECT [Id], [Name], [Type] FROM Ingredient
WHERE [Id] = @Id
END
