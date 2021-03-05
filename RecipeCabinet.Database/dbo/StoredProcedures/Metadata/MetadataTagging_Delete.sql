CREATE PROCEDURE [MetadataTagging_Delete]
	@Id INT
AS
BEGIN
DELETE FROM [MetadataTagging]
WHERE [Id] = @Id
END
