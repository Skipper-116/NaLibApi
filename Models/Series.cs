using System.ComponentModel.DataAnnotations.Schema;

namespace NaLibApi.Models
{
    [NotMapped]
    public class Series
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Volumne { get; set; }
    }
}
