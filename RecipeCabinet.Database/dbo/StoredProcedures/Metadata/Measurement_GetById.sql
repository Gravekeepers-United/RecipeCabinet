CREATE PROCEDURE [Measurement_GetById]
	@Id INT
AS
BEGIN
SELECT [Name], [Imperial]
FROM [Measurement]
WHERE [Id] = @Id
END
