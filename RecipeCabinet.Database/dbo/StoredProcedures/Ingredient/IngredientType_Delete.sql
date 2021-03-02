CREATE PROCEDURE [IngredientType_Delete]
	@Id INT
AS
BEGIN
DELETE FROM [IngredientType]
WHERE [Id] = @Id;
END
