using RecipeCabinet.Domain.Recipe;

namespace RecipeCabinet.DataAccess.Recipe
{
    internal interface IRecipeIngredientRepository
    {
        public RecipeIngredientModel Create(RecipeIngredientModel rating);

        public RecipeIngredientModel GetById(int id);

        public RecipeIngredientModel Update(RecipeIngredientModel rating);

        public void Delete(int id);
    }
}
}
