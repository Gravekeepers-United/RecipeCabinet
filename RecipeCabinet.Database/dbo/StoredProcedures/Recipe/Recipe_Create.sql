CREATE PROCEDURE [Recipe_Create]
	@Name VARCHAR(50),
    @Description TEXT,
    @Servings INT
AS
BEGIN
INSERT INTO [Recipe] (
    [Name],
    [Description],
    [Servings]
) OUTPUT Inserted.Id
VALUES (
    @Name,
    @Description,
    @Servings
)
END
