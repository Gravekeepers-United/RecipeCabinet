CREATE PROCEDURE [dbo].[MetadataType_Update]
	@Id INT,
	@Name VARCHAR(50)
AS
BEGIN
UPDATE [MetadataType]
SET
    [Name] = @Name
WHERE [Id] = @Id
END
