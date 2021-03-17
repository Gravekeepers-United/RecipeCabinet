namespace RecipeCabinet.Domain.Recipe
{
    /// <summary>
    /// Cooking recipe with steps, 
    /// </summary>

    public class RecipeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
