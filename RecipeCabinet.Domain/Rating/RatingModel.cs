using System;

namespace RecipeCabinet.Domain.Rating
{
    /// <summary>
    /// Rating with image.
    /// </summary>
    public class RatingModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set;}
        public string Message { get; set; }
        public int Rating { get; set; }
        public int Recipe { get; set; }
    }
}
