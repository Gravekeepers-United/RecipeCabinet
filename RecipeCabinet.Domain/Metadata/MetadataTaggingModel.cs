namespace RecipeCabinet.Domain.Metadata
{
    public class MetadataTaggingModel
    {
        public int Id { get; set; }
        public int MetadataType { get; set; }
        public int Recipe { get; set; }
        public int Ingredient { get; set; }
    }
}
