using Domain;
using Domain.Enum;
using Domain.Services;
using Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ReportService(FluxoDeCaixaDataContext fluxoCaixaDb) : IReportService
    {
        private readonly FluxoDeCaixaDataContext _fluxoCaixaDb = fluxoCaixaDb;

        public async Task<ICollection<Consolidated>> GetConsolidated(int month, int year)
        {
            var lancamentos = await _fluxoCaixaDb.BookEntries.Where(x => x.CreatedAt.Month == month && x.CreatedAt.Year == year).ToListAsync();
            return lancamentos.GroupBy(release => release.CreatedAt)
            .Select(x => new Consolidated
            {
                CreatedAt = x.First().CreatedAt.Date,
                Credit = x.Sum(x => x.EntryTransactionType == TransactionType.Credit ? x.Amount : 0),
                Debit = x.Sum(x => x.EntryTransactionType == TransactionType.Debit ? x.Amount : 0)
            }).ToList();            
        }
    }
}
