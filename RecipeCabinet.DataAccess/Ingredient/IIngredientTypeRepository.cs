using RecipeCabinet.Domain.Ingredient;


namespace RecipeCabinet.DataAccess.Ingredient
{
    public interface IIngredientTypeRepository
    {
        public IngredientTypeModel Create(IngredientTypeModel ingredient);

        public IngredientTypeModel GetById(int id);

        public IngredientTypeModel Update(IngredientTypeModel ingredient);

        public void Delete(int id);
    }
}
