namespace RecipeCabinet.Domain.Ingredient
{
    /// <summary>
    /// Ingredient item, used for Cabinet and Recipe components.
    /// </summary>
    public class IngredientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        
    }
}
