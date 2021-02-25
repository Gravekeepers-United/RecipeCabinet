CREATE TABLE Cabinet (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    CabinetItem INT NOT NULL,
    Quantity DECIMAL (2) NOT NULL,
    QuantityMeasurement INT NOT NULL,
    CONSTRAINT [FK_CabinetItem] FOREIGN KEY ([CabinetItem]) REFERENCES CabinetItem([Id])
);
