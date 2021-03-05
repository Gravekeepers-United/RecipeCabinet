CREATE PROCEDURE [CookingType_Create]
	@Name VARCHAR(50),
    @Description TEXT
AS
BEGIN
INSERT INTO [CookingType] (
    [Name],
    [Description]
) OUTPUT Inserted.Id
VALUES (
    @Name,
    @Description
)
END
