--USE [localdb]
--GO
CREATE PROCEDURE Ingredient_Create
    @Name VARCHAR (50),
    @Type INT
AS
BEGIN
INSERT INTO Ingredient (
    Name,
    Type
)
OUTPUT Inserted.Id
VALUES (
    @Name,
    @Type
)
END
