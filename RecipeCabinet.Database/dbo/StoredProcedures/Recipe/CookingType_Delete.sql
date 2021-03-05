CREATE PROCEDURE [CookingType_Delete]
	@Id INT
AS
BEGIN
DELETE FROM [CookingType]
WHERE [Id] = @Id
END
