CREATE PROCEDURE [Measurement_Create]
	@Name VARCHAR (50),
    @Imperial BINARY
AS
BEGIN
INSERT INTO [Measurement] (
    [Name],
    [Imperial]
) OUTPUT Inserted.Id
VALUES (
    @Name,
    @Imperial
)
END
