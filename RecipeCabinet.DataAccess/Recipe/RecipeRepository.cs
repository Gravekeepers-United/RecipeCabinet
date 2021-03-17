using System.Data.SqlClient;
using System;
using RecipeCabinet.DataAccess.Common;
using RecipeCabinet.Domain.Recipe;
using RecipeCabinet.DataAccess.Recipe;

namespace RecipeCabinet.DataAccess.Rating
{
    public class RecipeRepository : IRecipeRepository
    {
        // SPROCS
        private const string RECIPE_CREATE_SPROC = "Recipe_Create";
        private const string RECIPE_GETBYID_SPROC = "Recipe_GetById";
        private const string RECIPE_UPDATE_SPROC = "Recipe_Update";
        private const string RECIPE_DELETE_SPROC = "Recipe_Delete";

        private IDatabaseContext _dbContext;

        public RecipeRepository(IDatabaseContext sqlDatabaseContext)
        {
            _dbContext = sqlDatabaseContext;
        }

        public RecipeModel Create(RecipeModel recipe)
        {
            SqlParameter nameParam = new SqlParameter("Name", recipe.Name);
            SqlParameter descriptionParam = new SqlParameter("Recipe", recipe.Description);
            SqlDataReader reader = _dbContext.ExecuteReader(RECIPE_CREATE_SPROC, System.Data.CommandType.StoredProcedure, nameParam, descriptionParam);
            while (reader.Read())
            {
                // This might not be right.
                recipe.Id = int.Parse(reader["Id"].ToString());
            }
            return recipe;
        }

        public RecipeModel GetById(int id)
        {
            RecipeModel model = null;
            SqlParameter param = new SqlParameter("Id", id);
            SqlDataReader reader = _dbContext.ExecuteReader(RECIPE_GETBYID_SPROC, System.Data.CommandType.StoredProcedure, param);
            while (reader.Read())
            {
                model = new RecipeModel
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString()
                };
            }
            return model;
        }

        public RecipeModel Update(RecipeModel recipe)
        {
            SqlParameter param = new SqlParameter("Id", recipe.Id);
            SqlParameter nameParam = new SqlParameter("Name", recipe.Name);
            SqlParameter descriptionParam = new SqlParameter("Description", recipe.Description);
            _dbContext.ExecuteNonReader(RECIPE_UPDATE_SPROC, System.Data.CommandType.StoredProcedure, param, nameParam, descriptionParam);

            return recipe;
        }

        public void Delete(int id)
        {
            SqlParameter param = new SqlParameter("Id", id);
            _dbContext.ExecuteNonReader(RECIPE_DELETE_SPROC, System.Data.CommandType.StoredProcedure, param);
        }
    }
}
}
