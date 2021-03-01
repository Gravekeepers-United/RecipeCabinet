CREATE PROCEDURE IngredientType_Create
	@Name VARCHAR (50)
AS
BEGIN
INSERT INTO IngredientType (
    [Name]
    )
OUTPUT Inserted.Id
VALUES (
    @Name
)
END
