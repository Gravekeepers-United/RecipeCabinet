CREATE PROCEDURE [Image_GetById]
	@Id INT
AS
BEGIN
SELECT [Name], [MimeType]
FROM [Image]
WHERE [Id] = @Id
END
