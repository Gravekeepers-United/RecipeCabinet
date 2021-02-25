CREATE TABLE Ingredient (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    [Name] VARCHAR (50) NOT NULL,
    [Type] INT NOT NULL,
    CONSTRAINT FK_Type FOREIGN KEY ([Type]) REFERENCES IngredientType (Id)
);
