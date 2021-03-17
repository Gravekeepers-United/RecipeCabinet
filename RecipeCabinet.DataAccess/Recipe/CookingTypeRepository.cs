using System.Data.SqlClient;
using System;
using RecipeCabinet.DataAccess.Common;
using RecipeCabinet.Domain.Recipe;
using RecipeCabinet.DataAccess.Recipe;

namespace RecipeCabinet.DataAccess.Rating
{
    public class CookingTypeRepository : ICookingTypeRepository
    {
        // SPROCS
        private const string RECIPESTEP_CREATE_SPROC = "RecipeStep_Create";
        private const string RECIPESTEP_GETBYID_SPROC = "RecipeStep_GetById";
        private const string RECIPESTEP_UPDATE_SPROC = "RecipeStep_Update";
        private const string RECIPESTEP_DELETE_SPROC = "RecipeStep_Delete";

        private IDatabaseContext _dbContext;

        public CookingTypeRepository(IDatabaseContext sqlDatabaseContext)
        {
            _dbContext = sqlDatabaseContext;
        }

        public CookingTypeModel Create(CookingTypeModel cookingType)
        {
            SqlParameter nameParam = new SqlParameter("Name", cookingType.Name);
            SqlParameter descriptionParam = new SqlParameter("Description", cookingType.Description);
            SqlDataReader reader = _dbContext.ExecuteReader(RECIPESTEP_CREATE_SPROC, System.Data.CommandType.StoredProcedure, nameParam, descriptionParam);
            while (reader.Read())
            {
                // This might not be right.
                cookingType.Id = int.Parse(reader["Id"].ToString());
            }
            return cookingType;
        }

        public CookingTypeModel GetById(int id)
        {
            CookingTypeModel model = null;
            SqlParameter param = new SqlParameter("Id", id);
            SqlDataReader reader = _dbContext.ExecuteReader(RECIPESTEP_GETBYID_SPROC, System.Data.CommandType.StoredProcedure, param);
            while (reader.Read())
            {
                model = new CookingTypeModel
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Recipe"].ToString(),
                    Description = reader["Description"].ToString()
                };
            }
            return model;
        }

        public CookingTypeModel Update(CookingTypeModel cookingType)
        {
            SqlParameter param = new SqlParameter("Id", cookingType.Id);
            SqlParameter nameParam = new SqlParameter("Name", cookingType.Name);
            SqlParameter descriptionParam = new SqlParameter("Description", cookingType.Description);
            _dbContext.ExecuteNonReader(RECIPESTEP_UPDATE_SPROC, System.Data.CommandType.StoredProcedure, param, nameParam, descriptionParam);

            return cookingType;
        }

        public void Delete(int id)
        {
            SqlParameter param = new SqlParameter("Id", id);
            _dbContext.ExecuteNonReader(RECIPESTEP_DELETE_SPROC, System.Data.CommandType.StoredProcedure, param);
        }
    }
}
}
