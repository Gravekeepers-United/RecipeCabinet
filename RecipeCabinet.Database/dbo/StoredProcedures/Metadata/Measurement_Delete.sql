CREATE PROCEDURE [Measurement_Delete]
	@Id INT
AS
BEGIN
DELETE FROM [Measurement]
WHERE [Id] = @Id
END
