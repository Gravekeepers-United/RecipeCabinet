using RecipeCabinet.Domain.Recipe;

namespace RecipeCabinet.DataAccess.Recipe
{
    internal interface IRecipeRepository
    {
        public RecipeModel Create(RecipeModel rating);

        public RecipeModel GetById(int id);

        public RecipeModel Update(RecipeModel rating);

        public void Delete(int id);
    }
}
}
