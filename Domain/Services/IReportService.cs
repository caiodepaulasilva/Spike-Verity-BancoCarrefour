using Domain.Aggregations;

namespace Domain.Services;

public interface IReportService
{
    Task<ICollection<Consolidated>?> GetConsolidated(DateOnly date);
}