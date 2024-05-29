using System.ComponentModel.DataAnnotations.Schema;

namespace NaLibApi.Models
{
    [NotMapped]
    public class Content
    {
        public string Chapter { get; set; }
        public string Subject { get; set; }
    }
}
