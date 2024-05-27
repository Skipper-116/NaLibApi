public sealed class MemberRent
{
    public int Id { get; set; }
    public required int MemberId { get; set; }
    public required Bson Resource { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public DateTime? ReturnedDate { get; set; }
    public bool Overdue { get; set; }
    public string Remarks { get; set; }
    public string ReturnRemarks { get; set; }
    // To capture who processed the return of the resource
    public int ProcessedBy { get; set; }
    public required int CreatedBy { get; set; }
    public required int UpdatedBy { get; set; }
    public bool Voided { get; set; }
    public int? VoidedBy { get; set; }
    public DateTime? VoidedOn { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}