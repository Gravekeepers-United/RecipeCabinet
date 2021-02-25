CREATE TABLE RecipeIngredient (
	Id INT PRIMARY KEY IDENTITY (1, 1),
	Recipe INT NOT NULL,
	Ingredient INT NOT NULL,
    Amount DECIMAL (2) NOT NULL,
    Measurement INT NOT NULL,
	CONSTRAINT FK_Recipe FOREIGN KEY (Recipe) REFERENCES Recipe (Id),
	CONSTRAINT FK_Ingredient_RecipeIngredient FOREIGN KEY (Ingredient) REFERENCES Ingredient (Id),
    CONSTRAINT FK_Measurement_RecipeIngredient FOREIGN KEY (Measurement) REFERENCES Measurement (Id)
);
