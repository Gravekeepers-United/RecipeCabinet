CREATE PROCEDURE [Cabinet_GetById]
	@Id int
AS
BEGIN
SELECT [Id], [CabinetItem], [Quantity], [QuantityMeasurement]
FROM Cabinet
WHERE [Id] = @Id;
END
