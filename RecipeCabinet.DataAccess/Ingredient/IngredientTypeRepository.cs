using Microsoft.Extensions.Configuration;
using RecipeCabinet.DataAccess.Common;
using RecipeCabinet.Domain.Ingredient;
using System.Data.SqlClient;

namespace RecipeCabinet.DataAccess.Ingredient
{
    public class IngredientTypeRepository : BaseRepository, IIngredientTypeRepository
    {
        // SPROCS
        private const string INGREDIENTTYPE_CREATE_SPROC = "IngredientType_Create";
        private const string INGREDIENTTYPE_GETBYID_SPROC = "IngredientType_GetById";
        private const string INGREDIENTTYPE_UPDATE_SPROC = "IngredientType_Update";
        private const string INGREDIENTTYPE_DELETE_SPROC = "IngredientType_Delete";

        public IngredientTypeRepository(IConfiguration configuration) : base(configuration) { }

        public IngredientTypeModel Create(IngredientTypeModel ingredient)
        {
            SqlParameter nameParam = new SqlParameter("Name", ingredient.Name);
            SqlDataReader reader = ExecuteReader(INGREDIENTTYPE_CREATE_SPROC, System.Data.CommandType.StoredProcedure, nameParam);
            while (reader.Read())
            {
                // This might not be right.
                ingredient.Id = int.Parse(reader["Id"].ToString());
            }
            return ingredient;
        }

        public IngredientTypeModel GetById(int id)
        {
            IngredientTypeModel model = null;
            SqlParameter param = new SqlParameter("Id", id);
            SqlDataReader reader = ExecuteReader(INGREDIENTTYPE_GETBYID_SPROC, System.Data.CommandType.StoredProcedure, param);
            while (reader.Read())
            {
                model = new IngredientTypeModel
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString()
                };
            }
            return model;
        }

        public IngredientTypeModel Update(IngredientTypeModel ingredient)
        {
            SqlParameter param = new SqlParameter("Id", ingredient.Id);
            SqlParameter nameParam = new SqlParameter("Name", ingredient.Name);
            ExecuteNonReader(INGREDIENTTYPE_UPDATE_SPROC, System.Data.CommandType.StoredProcedure, param, nameParam);

            return ingredient;
        }

        public void Delete(int id)
        {
            SqlParameter param = new SqlParameter("Id", id);
            ExecuteNonReader(INGREDIENTTYPE_DELETE_SPROC, System.Data.CommandType.StoredProcedure, param);
        }
    }
}
