namespace PaymentGateway.Models
{
    public class PaymentTransaction
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
