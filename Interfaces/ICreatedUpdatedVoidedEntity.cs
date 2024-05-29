using NaLibApi.Models;

namespace NaLibApi.Interfaces
{
    public interface ICreatedUpdatedVoidedEntity
    {
        int CreatedBy { get; set; }
        int? UpdatedBy { get; set; }
        int? VoidedBy { get; set; }
        User CreatedByUser { get; set; }
        User UpdatedByUser { get; set; }
        User VoidedByUser { get; set; }
    }
}
