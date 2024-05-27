public sealed class UserExperience
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required string Company { get; set; }
    public required string Position { get; set; }
    public required string Description { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public required int CreatedBy { get; set; }
    public required int? UpdatedBy { get; set; }
    public bool Voided { get; set; }
    public int? VoidedBy { get; set; }
    public DateTime? VoidedOn { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}