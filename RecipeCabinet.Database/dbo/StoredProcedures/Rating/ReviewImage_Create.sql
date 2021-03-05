CREATE PROCEDURE [ReviewImage_Create]
	@Image INT,
    @Review INT

AS
BEGIN
INSERT INTO ReviewImage (
    [Image],
    [Review]
)
VALUES (
    @Image,
    @Review
)
END
