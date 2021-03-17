using System.Data.SqlClient;
using System;
using RecipeCabinet.Domain.Metadata;
using RecipeCabinet.DataAccess.Common;

namespace RecipeCabinet.DataAccess.Metadata
{
    public class MetadataTaggingRepository : IMetadataTaggingRepository
    {
        // SPROCS
        private const string METADATA_CREATE_SPROC = "Metadata_Create";
        private const string METADATA_GETBYID_SPROC = "Metadata_GetById";
        private const string METADATA_UPDATE_SPROC = "Metadata_Update";
        private const string METADATA_DELETE_SPROC = "Metadata_Delete";

        private IDatabaseContext _dbContext;

        public MetadataTaggingRepository(IDatabaseContext sqlDatabaseContext)
        {
            _dbContext = sqlDatabaseContext;
        }

        public MetadataTaggingModel Create(MetadataTaggingModel metadataTagging)
        {
            SqlParameter metadataTypeParam = new SqlParameter("MetadataType", metadataTagging.MetadataType);
            SqlParameter recipeParam = new SqlParameter("Recipe", metadataTagging.Recipe);
            SqlParameter ingredientParam = new SqlParameter("Ingredient", metadataTagging.Ingredient);
            SqlDataReader reader = _dbContext.ExecuteReader(METADATA_CREATE_SPROC, System.Data.CommandType.StoredProcedure, metadataTypeParam, recipeParam, ingredientParam);
            while (reader.Read())
            {
                // This might not be right.
                metadataTagging.Id = int.Parse(reader["Id"].ToString());
            }
            return metadataTagging;
        }

        public MetadataTaggingModel GetById(int id)
        {
            MetadataTaggingModel model = null;
            SqlParameter param = new SqlParameter("Id", id);
            SqlDataReader reader = _dbContext.ExecuteReader(METADATA_GETBYID_SPROC, System.Data.CommandType.StoredProcedure, param);
            while (reader.Read())
            {
                model = new MetadataTaggingModel
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    MetadataType = int.Parse(reader["MetadataType"].ToString()),
                    Recipe = int.Parse(reader["Recipe"].ToString()),
                    Ingredient = int.Parse(reader["Ingredient"].ToString())
                };
            }
            return model;
        }

        public MetadataTaggingModel Update(MetadataTaggingModel metadataTagging)
        {
            SqlParameter param = new SqlParameter("Id", metadataTagging.Id);
            SqlParameter metadataTypeParam = new SqlParameter("MetadataType", metadataTagging.MetadataType);
            SqlParameter recipeParam = new SqlParameter("Recipe", metadataTagging.Recipe);
            SqlParameter ingredientParam = new SqlParameter("Ingredient", metadataTagging.Ingredient);
            _dbContext.ExecuteNonReader(METADATA_UPDATE_SPROC, System.Data.CommandType.StoredProcedure, param, metadataTypeParam, recipeParam, ingredientParam);

            return metadataTagging;
        }

        public void Delete(int id)
        {
            SqlParameter param = new SqlParameter("Id", id);
            _dbContext.ExecuteNonReader(METADATA_DELETE_SPROC, System.Data.CommandType.StoredProcedure, param);
        }
    }
}
}
