CREATE PROCEDURE [MetadataTagging_Update]
	@Id INT,
    @MetadataType INT,
	@Recipe INT = NULL,
	@Ingredient INT = NULL
AS
BEGIN
UPDATE [MetadataTagging]
SET
    [MetadataType] = @MetadataType,
    [Recipe] = @Recipe,
    [Ingredient] = @Ingredient
WHERE [Id] = @Id
END
