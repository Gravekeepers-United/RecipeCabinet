CREATE PROCEDURE [MetadataTagging_Create]
	@MetadataType INT,
	@Recipe INT = NULL,
	@Ingredient INT = NULL
AS
BEGIN
INSERT INTO [MetadataTagging] (
    [MetadataType],
    [Recipe],
    [Ingredient]
) OUTPUT Inserted.Id
VALUES (
    @MetadataType,
    @Recipe,
    @Ingredient
)
END
