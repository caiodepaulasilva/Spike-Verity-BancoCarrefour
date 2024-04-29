using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregations
{
    public class Consolidated
    {
        public DateOnly CreatedAt { get; set; }
        
        public decimal Credit { get; set; }     
        
        public decimal Debit { get; set; }

        public decimal Balance { get { return Credit - Debit; } }
    }
}