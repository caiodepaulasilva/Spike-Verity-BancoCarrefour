using Domain.Aggregations;
using Domain.Enum;
using Domain.Services;
using Infra.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class ReportService(StoreContext fluxoCaixaDb, ILogger<ReportService> logger) : IReportService
    {
        private readonly StoreContext _fluxoCaixaDb = fluxoCaixaDb;
        private readonly ILogger<ReportService> _logger = logger;

        public async Task<ICollection<Consolidated>?> GetConsolidated(DateOnly date)
        {
            var lancamentos = await _fluxoCaixaDb.Accounting.Where(x => x.CreatedAt.Day == date.Day && x.CreatedAt.Month == date.Month && x.CreatedAt.Year == date.Year).ToListAsync();

            if (!lancamentos.IsNullOrEmpty())
            {
                _logger.LogInformation($"The daily consolidated data is available. Date:{0}", date);

                return lancamentos.GroupBy(release => release.CreatedAt)
                .Select(x => new Consolidated
                {
                    CreatedAt = x.First().CreatedAt,
                    Credit = x.Sum(x => x.TransactionType == TransactionType.Credit.ToString() ? x.Amount : 0),
                    Debit = x.Sum(x => x.TransactionType == TransactionType.Debit.ToString() ? x.Amount : 0)
                }).ToList();
            }
            return default;
        }
    }
}
