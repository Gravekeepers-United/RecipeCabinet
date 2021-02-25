CREATE TABLE CabinetItem (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    Ingredient INT NOT NULL,
    [Type] VARCHAR (50), -- e.g. Manufacturer, fruit type (Granny Smith apple, Red Delicious, etc.), Maker
    Measurement INT NOT NULL,
    CONSTRAINT FK_Ingredient FOREIGN KEY (Ingredient) REFERENCES Ingredient (Id),
    CONSTRAINT FK_Measurement FOREIGN KEY (Measurement) REFERENCES Measurement (Id)
);
