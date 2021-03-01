CREATE PROCEDURE [CabinetItem_Update]
	@Id INT,
    @Ingredient INT,
    @Type VARCHAR(50),
    @Measurement INT
AS
BEGIN
UPDATE [CabinetItem]
SET
    [Ingredient] = @Ingredient,
    [Type] = @Type,
    [Measurement] = @Measurement
WHERE [Id] = @Id;
END
