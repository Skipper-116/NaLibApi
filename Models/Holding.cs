using System.ComponentModel.DataAnnotations.Schema;

namespace NaLibApi.Models
{
    [NotMapped]
    public class Holding
    {
        public string Status { get; set; }
        public DateTime StatusDate { get; set; }
    }
}
