using RecipeCabinet.Domain.Recipe;

namespace RecipeCabinet.DataAccess.Recipe
{
    internal interface IRecipeStepRepository
    {
        public RecipeStepModel Create(RecipeStepModel rating);

        public RecipeStepModel GetById(int id);

        public RecipeStepModel Update(RecipeStepModel rating);

        public void Delete(int id);
    }
}
}
