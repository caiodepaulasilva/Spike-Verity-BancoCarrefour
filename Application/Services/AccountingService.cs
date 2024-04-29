using Domain;
using Domain.Aggregations;
using Domain.Services;
using Infra.Database;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class AccountingService(StoreContext fluxoCaixaDb, ILogger<AccountingService> logger) : IAccountingService
    {
        private readonly StoreContext _fluxoCaixaDb = fluxoCaixaDb;
        private readonly ILogger<AccountingService> _logger = logger;

        public async Task<Accounting> Create(Release release)
        {
            var accountingRecord = new Accounting(release.Description, release.TransactionType, release.Amount);

            await _fluxoCaixaDb.Accounting.AddAsync(accountingRecord);
            await _fluxoCaixaDb.SaveChangesAsync();
            
            _logger.LogInformation("New Accounting record has been registered");

            return accountingRecord;
        }

        public async Task<Accounting?> Remove(int id)
        {
            var accountingRecord = await _fluxoCaixaDb.Accounting.FindAsync(id);

            if (accountingRecord != null)
            {
                _fluxoCaixaDb.Accounting.Remove(accountingRecord);                
                await _fluxoCaixaDb.SaveChangesAsync();              
                
                _logger.LogInformation("Accounting record removal has been completed");

                return accountingRecord;
            }
            return default;
        }

        public async Task<Accounting?> Get(int id)
        {
            var accountingRecord = await _fluxoCaixaDb.Accounting.FindAsync(id);
            
            _logger.LogInformation("Accounting record has been found");

            return accountingRecord;
        }
    }
}
