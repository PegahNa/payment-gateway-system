namespace PaymentGatewaySystem.Models
{
	public class Payment
	{
		public Guid Id { get; set; }
		public decimal Amount { get; set; }
		public string Currency { get; set; } = "USD";
		public string Status { get; set; } = "Pending";
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public PaymentStatus status { get; set; } = PaymentStatus.Pending;
	}
}