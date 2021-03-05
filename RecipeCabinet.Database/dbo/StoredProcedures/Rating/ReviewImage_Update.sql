CREATE PROCEDURE [ReviewImage_Update]
	@Image INT = NULL,
    @Review INT = NULL,
    @OriginalImage INT,
    @OriginalReview INT
AS
BEGIN
UPDATE [ReviewImage]
SET
    [Image] = IsNull(@Image,[Image]),
    [Review] = IsNull(@Review,[Review])
WHERE [Image] = @OriginalImage AND [Review] = @OriginalReview
END
