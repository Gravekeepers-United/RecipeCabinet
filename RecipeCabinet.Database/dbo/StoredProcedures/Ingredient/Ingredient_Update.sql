--USE [localdb]
--GO
CREATE PROCEDURE Ingredient_Update
    @Id INT,
    @Name VARCHAR (50),
    @Type INT
AS
BEGIN
UPDATE Ingredient
SET 
    [Name] = @Name,
    [Type] = @Type

WHERE [Id] = @Id
END
