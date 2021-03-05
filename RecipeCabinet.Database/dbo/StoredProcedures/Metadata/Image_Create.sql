CREATE PROCEDURE [Image_Create]
	@MimeType VARCHAR(255),
    @Name VARCHAR(255)
AS
BEGIN
INSERT INTO [Image] (
    [MimeType],
    [Name]
) OUTPUT Inserted.Id
VALUES (
    @MimeType,
    @Name
)
END
