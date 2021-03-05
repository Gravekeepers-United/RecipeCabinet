CREATE PROCEDURE [RecipeIngredient_Update]
	@Id INT,
	@Recipe INT,
    @Ingredient INT,
    @Amount DECIMAL (2),
    @Measurement INT
AS
BEGIN
UPDATE RecipeIngredient
SET
    [Recipe] = @Recipe,
    [Ingredient] = @Ingredient,
    [Amount] = @Amount,
    [Measurement] = @Measurement
WHERE [Id] = @Id
END
