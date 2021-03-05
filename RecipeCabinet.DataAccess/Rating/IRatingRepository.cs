using RecipeCabinet.Domain.Rating;

namespace RecipeCabinet.DataAccess.Rating
{
    internal interface IRatingRepository
    {
        public RatingModel Create(RatingModel rating);

        public RatingModel GetById(int id);

        public RatingModel Update(RatingModel rating);

        public void Delete(int id);
    }
}
}
