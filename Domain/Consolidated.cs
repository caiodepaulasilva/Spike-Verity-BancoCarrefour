namespace Domain
{
    public class Consolidated
    {
        public DateTime CreatedAt { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public decimal Balance { get { return Credit - Debit; } }
    }
}