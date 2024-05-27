public sealed class RoleAccess
{
    public int Id { get; set; }
    public required int RoleId { get; set; }
    public required string AccessId { get; set; }
    public required bool Allowed { get; set; }
    public required int CreatedBy { get; set; }
    public required int UpdatedBy { get; set; }
    public bool Voided { get; set; }
    public int VoidedBy { get; set; }
    public DateTime VoidedOn { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}