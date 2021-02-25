using Microsoft.Extensions.Configuration;
using RecipeCabinet.DataAccess.Common;
using RecipeCabinet.Domain.Ingredient;
using System.Data.SqlClient;

namespace RecipeCabinet.DataAccess.Ingredient
{
    public class IngredientRepository : BaseRepository, IIngredientRepository
    {
        // SPROCS
        private const string INGREDIENT_CREATE_SPROC = "Ingredient_Create";
        private const string INGREDIENT_GETBYID_SPROC = "Ingredient_GetById";
        private const string INGREDIENT_UPDATE_SPROC = "Ingredient_Update";
        private const string INGREDIENT_DELETE_SPROC = "Ingredient_Delete";

        public IngredientRepository(IConfiguration configuration) : base(configuration) { }

        public IngredientModel Create(IngredientModel ingredient)
        {
            SqlParameter nameParam = new SqlParameter("Name", ingredient.Name);
            SqlParameter typeParam = new SqlParameter("Type", ingredient.Type);
            SqlDataReader reader = ExecuteReader(INGREDIENT_CREATE_SPROC, System.Data.CommandType.StoredProcedure, nameParam, typeParam);
            while (reader.Read())
            {
                // This might not be right.
                ingredient.Id = int.Parse(reader["Id"].ToString());
            }
            return ingredient;
        }

        public IngredientModel GetById(int id)
        {
            IngredientModel model = null;
            SqlParameter param = new SqlParameter("Id", id);
            SqlDataReader reader = ExecuteReader(INGREDIENT_GETBYID_SPROC, System.Data.CommandType.StoredProcedure, param);
            while (reader.Read())
            {
                model = new IngredientModel
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    Type = int.Parse(reader["Type"].ToString())
                };
            }
            return model;
        }

        public IngredientModel Update(IngredientModel ingredient)
        {
            SqlParameter param = new SqlParameter("Id", ingredient.Id);
            SqlParameter nameParam = new SqlParameter("Name", ingredient.Name);
            SqlParameter typeParam = new SqlParameter("Type", ingredient.Type);
            ExecuteNonReader(INGREDIENT_UPDATE_SPROC, System.Data.CommandType.StoredProcedure, param, nameParam, typeParam);

            return ingredient;
        }

        public void Delete (int id)
        {
            SqlParameter param = new SqlParameter("Id", id);
            ExecuteNonReader(INGREDIENT_DELETE_SPROC, System.Data.CommandType.StoredProcedure, param);
        }
    }
}
