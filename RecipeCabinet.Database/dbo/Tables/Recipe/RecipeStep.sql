CREATE TABLE RecipeStep (
	Id INT PRIMARY KEY IDENTITY (1, 1),
	Recipe INT NOT NULL,
	[Description] TEXT,
	[Order] INT NOT NULL,
	[Type] INT NOT NULL,
	CONSTRAINT FK_Type_RecipeStep FOREIGN KEY ([Type]) REFERENCES CookingType (Id),
    CONSTRAINT FK_Recipe_RecipeStep FOREIGN KEY ([Recipe]) REFERENCES Recipe (Id)
);
