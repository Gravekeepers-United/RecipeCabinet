CREATE PROCEDURE IngredientType_Create
	@Name VARCHAR (50)
AS
BEGIN
INSERT INTO IngredientType (
    [Name]
    )
OUTPUT Inserted.Id
SELECT @Name
WHERE NOT EXISTS (SELECT * FROM IngredientType WHERE [Name] = @Name)
--VALUES (
--    @Name
--)
END
