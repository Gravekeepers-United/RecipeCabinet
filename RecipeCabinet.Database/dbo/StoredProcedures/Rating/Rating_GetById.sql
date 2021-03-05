CREATE PROCEDURE [Rating_GetById]
	@Id INT
AS
BEGIN
SELECT [Id], [CreatedOn], [LastUpdatedOn], [Message], [Rating], [Recipe] FROM [Rating]
WHERE [Id] = @Id
END
