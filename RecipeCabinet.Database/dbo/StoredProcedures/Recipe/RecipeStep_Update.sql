CREATE PROCEDURE [RecipeStep_Update]
	@Id INT,
    @Recipe INT,
	@Description TEXT,
	@Order INT,
	@Type INT
AS
BEGIN
UPDATE [RecipeStep]
SET
    [Recipe] = @Recipe,
    [Description] = @Description,
    [Order] = @Order,
    [Type] = @Type
END
