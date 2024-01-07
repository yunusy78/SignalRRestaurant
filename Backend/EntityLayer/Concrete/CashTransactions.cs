namespace EntityLayer.Concrete;

public class CashTransaction
{
    public int CashTransactionId { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
}