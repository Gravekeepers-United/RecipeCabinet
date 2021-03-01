CREATE PROCEDURE [CabinetItem_GetById]
	@Id INT
AS
BEGIN
SELECT [Id], [Ingredient], [Type], [Measurement]
FROM [CabinetItem]
WHERE Id = @Id;
END
