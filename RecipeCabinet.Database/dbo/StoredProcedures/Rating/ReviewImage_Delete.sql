CREATE PROCEDURE [ReviewImage_Delete]
	@Image INT,
    @Review INT
AS
BEGIN
DELETE FROM ReviewImage
WHERE [Image] = @Image
AND [Review] = @Review
END
