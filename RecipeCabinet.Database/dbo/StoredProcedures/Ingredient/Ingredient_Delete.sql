CREATE PROCEDURE Ingredient_Delete
    @Id INT
AS
BEGIN
DELETE FROM Ingredient
WHERE [Id] = @Id
END
