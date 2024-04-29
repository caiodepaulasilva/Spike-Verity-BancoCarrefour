using Domain.Aggregations;

namespace Domain.Services;

public interface IAccountingService
{
    Task<Accounting> Create(Release release);    
    Task<Accounting?> Remove(int id);    
    Task<Accounting?> Get(int id);
}