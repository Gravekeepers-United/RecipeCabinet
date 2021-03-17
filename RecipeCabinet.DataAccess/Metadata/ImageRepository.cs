using System.Data.SqlClient;
using System;
using RecipeCabinet.Domain.Metadata;
using RecipeCabinet.DataAccess.Common;
using RecipeCabinet.DataAccess.Metadata;

namespace RecipeCabinet.DataAccess.Rating
{
    public class ImageRepository : IImageRepository
    {
        // SPROCS
        private const string IMAGE_CREATE_SPROC = "Image_Create";
        private const string IMAGE_GETBYID_SPROC = "Image_GetById";
        private const string IMAGE_UPDATE_SPROC = "Image_Update";
        private const string IMAGE_DELETE_SPROC = "Image_Delete";

        private IDatabaseContext _dbContext;

        public ImageRepository(IDatabaseContext sqlDatabaseContext)
        {
            _dbContext = sqlDatabaseContext;
        }

        public ImageModel Create(ImageModel image)
        {
            SqlParameter nameParam = new SqlParameter("Name", image.Name);
            SqlParameter mimeTypeParam = new SqlParameter("MimeType", image.MimeType);
            SqlDataReader reader = _dbContext.ExecuteReader(IMAGE_CREATE_SPROC, System.Data.CommandType.StoredProcedure, nameParam, mimeTypeParam);
            while (reader.Read())
            {
                // This might not be right.
                image.Id = int.Parse(reader["Id"].ToString());
            }
            return image;
        }

        public ImageModel GetById(int id)
        {
            ImageModel model = null;
            SqlParameter param = new SqlParameter("Id", id);
            SqlDataReader reader = _dbContext.ExecuteReader(IMAGE_GETBYID_SPROC, System.Data.CommandType.StoredProcedure, param);
            while (reader.Read())
            {
                model = new ImageModel
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    MimeType = reader["MimeType"].ToString()
                };
            }
            return model;
        }

        public ImageModel Update(ImageModel image)
        {
            SqlParameter param = new SqlParameter("Id", image.Id);
            SqlParameter nameParam = new SqlParameter("Name", image.Name);
            SqlParameter mimeTypeParam = new SqlParameter("MimeType", image.MimeType);
            _dbContext.ExecuteNonReader(IMAGE_UPDATE_SPROC, System.Data.CommandType.StoredProcedure, param, nameParam, mimeTypeParam);

            return image;
        }

        public void Delete(int id)
        {
            SqlParameter param = new SqlParameter("Id", id);
            _dbContext.ExecuteNonReader(IMAGE_DELETE_SPROC, System.Data.CommandType.StoredProcedure, param);
        }
    }
}
}
