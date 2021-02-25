namespace RecipeCabinet.Domain.Recipe
{
    /// <summary>
    /// Cooking recipe with steps, 
    /// </summary>

    public class RecipeModel
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        private RecipeStepModel[] Steps { get; set; }
        private CookingTypeModel Type { get; set; }
        private RecipeIngredientModel[] Ingredients { get; set; }
    }
}
