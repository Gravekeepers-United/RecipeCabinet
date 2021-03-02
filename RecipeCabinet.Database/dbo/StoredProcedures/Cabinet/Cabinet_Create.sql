CREATE PROCEDURE [Cabinet_Create]
	@CabinetItem INT,
	@Quantity DECIMAL,
    @QuantityMeasurement INT
AS
BEGIN
INSERT INTO [Cabinet] (
    CabinetItem,
    Quantity,
    QuantityMeasurement
)
OUTPUT Inserted.Id
VALUES (
    @CabinetItem,
    @Quantity,
    @QuantityMeasurement
)
END
