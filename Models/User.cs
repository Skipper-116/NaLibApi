public sealed class User
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Salt { get; set; }
    public required int LibraryId { get; set; }
    public required int CreatedBy { get; set; }
    public required int? UpdatedBy { get; set; }
    public bool Voided { get; set; }
    public int? VoidedBy { get; set; }
    public DateTime? VoidedOn { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}