CREATE PROCEDURE [MetadataType_Create]
	@Name VARCHAR(50)
AS
BEGIN
INSERT INTO [MetadataType] (
    [Name]
) OUTPUT Inserted.Id
VALUES (
    @Name
)
END
