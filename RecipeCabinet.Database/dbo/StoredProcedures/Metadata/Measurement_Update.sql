CREATE PROCEDURE [dbo].[Measurement_Update]
	@Id INT,
	@Name VARCHAR (50),
    @Imperial BINARY
AS
BEGIN
UPDATE [Measurement]
SET
    [Name] = @Name,
    [Imperial] = @Imperial
WHERE [Id] = @Id
END
