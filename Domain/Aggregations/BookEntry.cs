using Domain.Enum;
using System.Text;

namespace Domain.Aggregations;

public class BookEntry
{
    public Guid Id { get; protected set; }

    public string Description { get; private set; } = string.Empty;

    public DateTimeOffset CreatedAt { get; protected set; }

    public TransactionType EntryTransactionType { get; private set; }

    public decimal Amount { get; private set; }

    public IEnumerable<string> Errors { get; } = Enumerable.Empty<string>();

    public BookEntry()
    {
        
    }

    public BookEntry(string description, TransactionType entryTransactionType, DateTime CreatedAt, decimal amount)
    {        
        Id = Guid.NewGuid();        
        Errors = GetErrors(amount);
        UpdateBookEntry(description, entryTransactionType, CreatedAt, amount);
    }

    private static IEnumerable<string> GetErrors(decimal amount)
    {
        if (!(decimal.IsPositive(amount) || amount == decimal.Zero))
            yield return "Valor do amount inválido"; 
    }

    public void UpdateBookEntry(string description, TransactionType entryTransactionType, DateTime CreatedAt, decimal amount)
    {
        var guardClauseResult = new StringBuilder();
        if (amount < 0) guardClauseResult.AppendLine("O campo valor não pode ser negativo.");
        if (entryTransactionType != TransactionType.Debit && entryTransactionType != TransactionType.Credit) guardClauseResult.AppendLine("O campo tipo do lançamento deve ser 0 (zero) para Débito ou 1 (um) para Crédito.");
        if (string.IsNullOrWhiteSpace(description)) guardClauseResult.AppendLine("O campo descrição deve estar preenchido.");

        Amount = amount;
        Description = description;
        EntryTransactionType = entryTransactionType;
        CreatedAt = CreatedAt.Date;
    }
}