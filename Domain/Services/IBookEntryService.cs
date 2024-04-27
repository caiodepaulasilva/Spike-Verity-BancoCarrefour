using Domain.Aggregations;

namespace Domain.Services;

public interface IBookEntryService
{
    Task<BookEntry> Create(Release release);
    Task<BookEntry?> Update(int id, Release release);
    Task<BookEntry?> Remove(int id);
    Task<List<BookEntry>> Search(int month, int year, int page);
    Task<BookEntry?> Search(int id);
}