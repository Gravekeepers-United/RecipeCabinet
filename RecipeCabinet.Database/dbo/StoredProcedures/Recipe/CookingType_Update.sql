CREATE PROCEDURE [CookingType_Update]
	@Id INT,
    @Name VARCHAR(50),
    @Description TEXT
AS
BEGIN
UPDATE [CookingType]
SET
    Name = @Name,
    Description = @Description
WHERE Id = @Id
END
