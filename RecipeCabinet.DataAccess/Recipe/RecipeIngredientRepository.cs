using System.Data.SqlClient;
using System;
using RecipeCabinet.DataAccess.Common;
using RecipeCabinet.Domain.Recipe;
using RecipeCabinet.DataAccess.Recipe;

namespace RecipeCabinet.DataAccess.Rating
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        // SPROCS
        private const string RECIPEINGREDIENT_CREATE_SPROC = "RecipeIngredient_Create";
        private const string RECIPEINGREDIENT_GETBYID_SPROC = "RecipeIngredient_GetById";
        private const string RECIPEINGREDIENT_UPDATE_SPROC = "RecipeIngredient_Update";
        private const string RECIPEINGREDIENT_DELETE_SPROC = "RecipeIngredient_Delete";

        private IDatabaseContext _dbContext;

        public RecipeIngredientRepository(IDatabaseContext sqlDatabaseContext)
        {
            _dbContext = sqlDatabaseContext;
        }

        public RecipeIngredientModel Create(RecipeIngredientModel recipeIngredient)
        {
            SqlParameter recipeParam = new SqlParameter("Recipe", recipeIngredient.Recipe);
            SqlParameter ingredientParam = new SqlParameter("Ingredient", recipeIngredient.Ingredient);
            SqlParameter amountParam = new SqlParameter("Amount", recipeIngredient.Amount);
            SqlParameter measurementParam = new SqlParameter("Measurement", recipeIngredient.Measurement);
            SqlDataReader reader = _dbContext.ExecuteReader(RECIPEINGREDIENT_CREATE_SPROC, System.Data.CommandType.StoredProcedure, recipeParam, ingredientParam, amountParam, measurementParam);
            while (reader.Read())
            {
                // This might not be right.
                recipeIngredient.Id = int.Parse(reader["Id"].ToString());
            }
            return recipeIngredient;
        }

        public RecipeIngredientModel GetById(int id)
        {
            RecipeIngredientModel model = null;
            SqlParameter param = new SqlParameter("Id", id);
            SqlDataReader reader = _dbContext.ExecuteReader(RECIPEINGREDIENT_GETBYID_SPROC, System.Data.CommandType.StoredProcedure, param);
            while (reader.Read())
            {
                model = new RecipeIngredientModel
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Recipe = int.Parse(reader["Recipe"].ToString()),
                    Ingredient = int.Parse(reader["Ingredient"].ToString()),
                    Amount = float.Parse(reader["Amount"].ToString()),
                    Measurement = int.Parse(reader["Measurement"].ToString())
                };
            }
            return model;
        }

        public RecipeIngredientModel Update(RecipeIngredientModel recipeIngredient)
        {
            SqlParameter param = new SqlParameter("Id", recipeIngredient.Id);
            SqlParameter recipeParam = new SqlParameter("Recipe", recipeIngredient.Recipe);
            SqlParameter ingredientParam = new SqlParameter("Ingredient", recipeIngredient.Ingredient);
            SqlParameter amountParam = new SqlParameter("Amount", recipeIngredient.Amount);
            SqlParameter measurementParam = new SqlParameter("Measurement", recipeIngredient.Measurement);
            _dbContext.ExecuteNonReader(RECIPEINGREDIENT_UPDATE_SPROC, System.Data.CommandType.StoredProcedure, param, recipeParam, ingredientParam, amountParam, measurementParam);

            return recipeIngredient;
        }

        public void Delete(int id)
        {
            SqlParameter param = new SqlParameter("Id", id);
            _dbContext.ExecuteNonReader(RECIPEINGREDIENT_DELETE_SPROC, System.Data.CommandType.StoredProcedure, param);
        }
    }
}
}
