CREATE PROCEDURE [MetadataType_GetById]
	@Id INT
AS
BEGIN
SELECT [Name]
FROM [MetadataType]
WHERE [Id] = @Id
END
