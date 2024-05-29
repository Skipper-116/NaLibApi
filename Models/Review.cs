using System.ComponentModel.DataAnnotations.Schema;

namespace NaLibApi.Models
{
    [NotMapped]
    public class Review
    {
        public int Rating { get; set; }
        public string Reviewer { get; set; }
        public string Comments { get; set; }
    }
}
