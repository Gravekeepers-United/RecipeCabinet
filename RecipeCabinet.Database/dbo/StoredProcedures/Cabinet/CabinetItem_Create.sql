CREATE PROCEDURE [CabinetItem_Create]
	@Ingredient INT,
    @Type VARCHAR(50),
    @Measurement INT
AS
BEGIN
INSERT INTO CabinetItem (
    Ingredient,
    [Type],
    Measurement
)
OUTPUT Inserted.Id
VALUES (
    @Ingredient,
    @Type,
    @Measurement
)
END
