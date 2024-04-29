using Domain.Enum;

namespace Domain.Aggregations;

public class Accounting
{
    public Guid Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateOnly CreatedAt { get; set; }

    public string TransactionType { get; set; }
  
    public decimal Amount { get; set; }

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