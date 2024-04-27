using Domain.Enum;

namespace Domain;

public record Release
{
    public string Description { get; set; } = string.Empty;
    public TransactionType TransactionType { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now.Date;
    public decimal Amount { get; set; }
}

