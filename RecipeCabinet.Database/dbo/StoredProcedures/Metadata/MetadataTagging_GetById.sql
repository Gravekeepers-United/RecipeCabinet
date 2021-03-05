CREATE PROCEDURE [dbo].[MetadataTagging_GetById]
	@Id INT
AS
BEGIN
SELECT [MetadataType], [Recipe], [Ingredient]
FROM [MetadataTagging] 
WHERE [Id] = @Id
END
