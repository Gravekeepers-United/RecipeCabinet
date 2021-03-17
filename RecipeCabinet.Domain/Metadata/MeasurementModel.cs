namespace RecipeCabinet.Domain.Metadata
{
    /// <summary>
    /// Measurement reference values
    /// </summary>
    public class MeasurementModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Imperial { get; set; }
    }
}
