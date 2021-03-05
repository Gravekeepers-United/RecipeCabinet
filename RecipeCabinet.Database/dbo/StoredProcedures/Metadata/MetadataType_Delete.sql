CREATE PROCEDURE [MetadataType_Delete]
	@Id INT
AS
BEGIN
DELETE FROM [MetadataType]
WHERE [Id] = @Id
END
