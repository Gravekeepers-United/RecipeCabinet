CREATE TABLE MetadataTagging (
	Id INT PRIMARY KEY IDENTITY (1, 1),
	MetadataType INT NOT NULL,
	Recipe INT,
	Ingredient INT,
	FOREIGN KEY (MetadataType) REFERENCES MetadataType (Id),
	FOREIGN KEY (Recipe) REFERENCES Recipe (Id),
	FOREIGN KEY (Ingredient) REFERENCES Ingredient (Id)
);
