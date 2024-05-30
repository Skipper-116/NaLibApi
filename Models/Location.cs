using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace  NaLibApi.Models;

public class Location : Interfaces.ICreatedUpdatedVoidedEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required(ErrorMessage = "Location name is required"),
     StringLength(150, MinimumLength = 6, ErrorMessage = "Location name must be between 3 and 150 characters")]
    public string? Name { get; set; }
    [StringLength(150, MinimumLength = 2)]
    public string? Description { get; set; }
    [Required(ErrorMessage = "Creator is required"), JsonIgnore]
    public int CreatedBy { get; set; }
    [JsonIgnore]
    public int? UpdatedBy { get; set; }
    [JsonIgnore]
    public bool Voided { get; set; }
    [JsonIgnore]
    public int? VoidedBy { get; set; }
    [JsonIgnore]
    public DateTime? VoidedOn { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation properties
    [ForeignKey("CreatedBy"), JsonIgnore] public User CreatedByUser { get; set; }

    [ForeignKey("UpdatedBy"), JsonIgnore] public User UpdatedByUser { get; set; }

    [ForeignKey("VoidedBy"), JsonIgnore] public User VoidedByUser { get; set; }
}

