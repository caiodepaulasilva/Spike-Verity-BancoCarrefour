using Domain;
using Domain.Aggregations;
using Domain.Services;
using Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class BookEntryService : IBookEntryService
    {
        private readonly FluxoDeCaixaDataContext _fluxoCaixaDb;

        public BookEntryService(FluxoDeCaixaDataContext fluxoCaixaDb) => this._fluxoCaixaDb = fluxoCaixaDb;

        public async Task<BookEntry?> Update(int id, Release release)
        {
            var releaseToUpdate = await _fluxoCaixaDb.BookEntries.FindAsync(id);

            if (releaseToUpdate is null)
            {
                return null;
            }
            releaseToUpdate.UpdateBookEntry(release.Description, release.TransactionType, release.CreatedAt, release.Amount);

            await _fluxoCaixaDb.SaveChangesAsync();
            return releaseToUpdate;
        }

        public async Task<BookEntry> Create(Release release)
        {
            ArgumentNullException.ThrowIfNull(release);            

            var bookEntry = new BookEntry(release.Description, release.TransactionType, release.CreatedAt, release.Amount);

            await _fluxoCaixaDb.BookEntries.AddAsync(bookEntry);
            await _fluxoCaixaDb.SaveChangesAsync();
            return bookEntry;
        }

        public async Task<BookEntry?> Remove(int id)
        {
            var lancamentoToRemove = await _fluxoCaixaDb.BookEntries.FindAsync(id);
            if (lancamentoToRemove is null) return null;

            _fluxoCaixaDb.BookEntries.Remove(lancamentoToRemove);
            await _fluxoCaixaDb.SaveChangesAsync();
            return lancamentoToRemove;
        }

        public async Task<List<BookEntry>> Search(int mes, int ano, int pagina)
        {
            int tamanhoPagina = 1000;
            int pular = tamanhoPagina * (pagina == 0 ? 0 : pagina - 1);
            return await _fluxoCaixaDb.BookEntries.Where(x => x.CreatedAt.Year == ano && x.CreatedAt.Month == mes).Skip(pular).Take(tamanhoPagina).ToListAsync();
        }


        public async Task<BookEntry?> Search(int id)
        {
            return await _fluxoCaixaDb.BookEntries.FindAsync(id);
        }
    }
}
