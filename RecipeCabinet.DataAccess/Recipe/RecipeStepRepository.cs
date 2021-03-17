using System.Data.SqlClient;
using System;
using RecipeCabinet.DataAccess.Common;
using RecipeCabinet.Domain.Recipe;
using RecipeCabinet.DataAccess.Recipe;

namespace RecipeCabinet.DataAccess.Rating
{
    public class RecipeStepRepository : IRecipeStepRepository
    {
        // SPROCS
        private const string RECIPESTEP_CREATE_SPROC = "RecipeStep_Create";
        private const string RECIPESTEP_GETBYID_SPROC = "RecipeStep_GetById";
        private const string RECIPESTEP_UPDATE_SPROC = "RecipeStep_Update";
        private const string RECIPESTEP_DELETE_SPROC = "RecipeStep_Delete";

        private IDatabaseContext _dbContext;

        public RecipeStepRepository(IDatabaseContext sqlDatabaseContext)
        {
            _dbContext = sqlDatabaseContext;
        }

        public RecipeStepModel Create(RecipeStepModel recipeStep)
        {
            SqlParameter recipeParam = new SqlParameter("Recipe", recipeStep.Recipe);
            SqlParameter descriptionParam = new SqlParameter("Description", recipeStep.Description);
            SqlParameter orderParam = new SqlParameter("Order", recipeStep.Order);
            SqlParameter typeParam = new SqlParameter("Type", recipeStep.Type);
            SqlDataReader reader = _dbContext.ExecuteReader(RECIPESTEP_CREATE_SPROC, System.Data.CommandType.StoredProcedure, recipeParam, descriptionParam, orderParam, typeParam);
            while (reader.Read())
            {
                // This might not be right.
                recipeStep.Id = int.Parse(reader["Id"].ToString());
            }
            return recipeStep;
        }

        public RecipeStepModel GetById(int id)
        {
            RecipeStepModel model = null;
            SqlParameter param = new SqlParameter("Id", id);
            SqlDataReader reader = _dbContext.ExecuteReader(RECIPESTEP_GETBYID_SPROC, System.Data.CommandType.StoredProcedure, param);
            while (reader.Read())
            {
                model = new RecipeStepModel
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Recipe = int.Parse(reader["Recipe"].ToString()),
                    Description = reader["Description"].ToString(),
                    Order = int.Parse(reader["Order"].ToString()),
                    Type = int.Parse(reader["Type"].ToString())
                };
            }
            return model;
        }

        public RecipeStepModel Update(RecipeStepModel recipeStep)
        {
            SqlParameter param = new SqlParameter("Id", recipeStep.Id);
            SqlParameter recipeParam = new SqlParameter("Recipe", recipeStep.Recipe);
            SqlParameter descriptionParam = new SqlParameter("Description", recipeStep.Description);
            SqlParameter orderParam = new SqlParameter("Order", recipeStep.Order);
            SqlParameter typeParam = new SqlParameter("Type", recipeStep.Type);
            _dbContext.ExecuteNonReader(RECIPESTEP_UPDATE_SPROC, System.Data.CommandType.StoredProcedure, param, recipeParam, descriptionParam, orderParam, typeParam);

            return recipeStep;
        }

        public void Delete(int id)
        {
            SqlParameter param = new SqlParameter("Id", id);
            _dbContext.ExecuteNonReader(RECIPESTEP_DELETE_SPROC, System.Data.CommandType.StoredProcedure, param);
        }
    }
}
}
