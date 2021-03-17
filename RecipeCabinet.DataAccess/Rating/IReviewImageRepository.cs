using RecipeCabinet.Domain.Rating;

namespace RecipeCabinet.DataAccess.Rating
{
    internal interface IReviewImageRepository
    {
        public ReviewImageModel Create(ReviewImageModel review);

        public ReviewImageModel GetByReview(int review);

        public void Delete(int review, int image);
    }
}
}
