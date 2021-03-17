using RecipeCabinet.DataAccess.Common;
using RecipeCabinet.Domain.Rating;
using System.Data.SqlClient;

namespace RecipeCabinet.DataAccess.Rating
{
    public class ReviewImageRepository : IReviewImageRepository
    {
        // SPROCS
        private const string RATING_CREATE_SPROC = "Rating_Create";

        private const string RATING_GETBYID_SPROC = "Rating_GetById";
        private const string RATING_UPDATE_SPROC = "Rating_Update";
        private const string RATING_DELETE_SPROC = "Rating_Delete";

        private IDatabaseContext _dbContext;

        public ReviewImageRepository(IDatabaseContext sqlDatabaseContext)
        {
            _dbContext = sqlDatabaseContext;
        }

        public ReviewImageModel Create(ReviewImageModel reviewImage)
        {
            SqlParameter reviewParam = new SqlParameter("Review", reviewImage.Review);
            SqlParameter imageParam = new SqlParameter("Image", reviewImage.Image);
            _ = _dbContext.ExecuteReader(RATING_CREATE_SPROC, System.Data.CommandType.StoredProcedure, reviewParam, imageParam);

            return reviewImage;
        }

        public ReviewImageModel GetByReview(int review)
        {
            ReviewImageModel model = null;
            SqlParameter param = new SqlParameter("Review", review);
            SqlDataReader reader = _dbContext.ExecuteReader(RATING_GETBYID_SPROC, System.Data.CommandType.StoredProcedure, param);
            while (reader.Read())
            {
                model = new ReviewImageModel
                {
                    Review = int.Parse(reader["Review"].ToString()),
                    Image = int.Parse(reader["Image"].ToString())
                };
            }
            return model;
        }

        public void Delete(int review, int image)
        {
            SqlParameter reviewParam = new SqlParameter("Review", review);
            SqlParameter imageParam = new SqlParameter("Image", image);
            _dbContext.ExecuteNonReader(RATING_DELETE_SPROC, System.Data.CommandType.StoredProcedure, reviewParam, imageParam);
        }
    }
}
}
