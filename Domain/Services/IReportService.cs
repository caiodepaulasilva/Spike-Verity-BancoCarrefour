namespace Domain.Services;

public interface IReportService
{
    Task<ICollection<Consolidated>> GetConsolidated(int month, int year);
}