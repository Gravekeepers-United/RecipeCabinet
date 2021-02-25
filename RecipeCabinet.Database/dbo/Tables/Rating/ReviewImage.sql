CREATE TABLE ReviewImage
(
    [Image] INT NOT NULL,
    [Review] INT NOT NULL, 
    CONSTRAINT [FK_ReviewImage] FOREIGN KEY ([Review]) REFERENCES [Review]([Id]), 
    CONSTRAINT [FK_ImageReview] FOREIGN KEY ([Image]) REFERENCES [Image]([Id])
)
