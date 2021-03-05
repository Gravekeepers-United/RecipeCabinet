CREATE PROCEDURE [Image_Update]
	@Id INT,
	@MimeType VARCHAR(255),
    @Name VARCHAR(255)
AS
BEGIN
UPDATE [Image]
SET
    [MimeType] = @MimeType,
    [Name] = @Name
WHERE [Id] = @Id
END
