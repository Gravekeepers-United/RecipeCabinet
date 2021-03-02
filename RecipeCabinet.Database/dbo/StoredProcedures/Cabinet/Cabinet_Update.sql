CREATE PROCEDURE [Cabinet_Update]
	@Id INT,
    @CabinetItem INT,
    @Quantity DECIMAL,
    @QuantityMeasurement INT
AS
BEGIN
UPDATE [Cabinet]
SET 
    CabinetItem = @CabinetItem,
    Quantity = @Quantity,
    QuantityMeasurement = @QuantityMeasurement

WHERE Id = @Id;
END
