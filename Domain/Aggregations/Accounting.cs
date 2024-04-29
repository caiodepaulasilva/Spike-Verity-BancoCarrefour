using Domain.Enum;

namespace Domain.Aggregations;

public class Accounting
{
    public Guid Id { get; protected set; }

    public string Description { get; private set; } = string.Empty;

    public DateOnly CreatedAt { get; protected set; }

    public string TransactionType { get; private set; }
  
    public decimal Amount { get; private set; }

    public Accounting()
    {

    }

    public Accounting(string description, TransactionType transactionType, decimal amount)
    {        
        Description = description;
        TransactionType = transactionType.ToString();
        Amount = amount;    
        Id = Guid.NewGuid();
        CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
    }    
}