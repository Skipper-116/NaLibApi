using System.ComponentModel.DataAnnotations.Schema;

namespace NaLibApi.Models
{
    [NotMapped]
    public class PublicationHistory
    {
        public string Edition { get; set; }
        public int Year { get; set; }
    }
}
