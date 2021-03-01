CREATE PROCEDURE [CabinetItem_Delete]
	@Id INT
AS
BEGIN
DELETE FROM [CabinetItem]
WHERE [Id] = @Id;
END
