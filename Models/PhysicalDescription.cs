using System.ComponentModel.DataAnnotations.Schema;

namespace NaLibApi.Models
{
    [NotMapped]
    public class PhysicalDescription
    {
        public string Binding { get; set; }
        public int Pages { get; set; }
        public string Dimensions { get; set; }
    }
}
