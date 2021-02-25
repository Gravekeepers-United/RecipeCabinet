using RecipeCabinet.Domain.Ingredient;


namespace RecipeCabinet.DataAccess.Ingredient
{
    public interface IIngredientRepository
    {
        public IngredientModel Create(IngredientModel ingredient);

        public IngredientModel GetById(int id);

        public IngredientModel Update(IngredientModel ingredient);

        public void Delete(int id);
    }
}
