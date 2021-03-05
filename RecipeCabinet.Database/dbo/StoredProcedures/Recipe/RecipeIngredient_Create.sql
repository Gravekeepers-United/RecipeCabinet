CREATE PROCEDURE [RecipeIngredient_Create]
	@Recipe INT,
    @Ingredient INT,
    @Amount DECIMAL (2),
    @Measurement INT
AS
BEGIN
INSERT INTO [RecipeIngredient]
(
    [Recipe],
    [Ingredient],
    [Amount],
    [Measurement]
) OUTPUT Inserted.Id
VALUES (
    @Recipe,
    @Ingredient,
    @Amount,
    @Measurement
)
END
