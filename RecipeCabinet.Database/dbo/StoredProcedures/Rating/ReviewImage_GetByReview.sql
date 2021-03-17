CREATE PROCEDURE [dbo].[ReviewImage_GetByReview]
	@review Int
AS
BEGIN
SELECT [Review], [Image]
FROM [ReviewImage]
WHERE [Review] = @Review
END
