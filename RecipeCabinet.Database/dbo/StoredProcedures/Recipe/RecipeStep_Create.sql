CREATE PROCEDURE [RecipeStep_Create]
	@Recipe INT,
	@Description TEXT,
	@Order INT,
	@Type INT
AS
BEGIN
INSERT INTO [RecipeStep]
(
    [Recipe],
    [Description],
    [Order],
    [Type]
) OUTPUT Inserted.Id
VALUES (
    @Recipe,
    @Description,
    @Order,
    @Type
)
END
