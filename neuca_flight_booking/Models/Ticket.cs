namespace neuca_flight_booking.Models
{
	public class Ticket
	{
		public DateTime Date { get; private set; }
		public Client Client { get; set; }
		public Flight Flight { get; set; }
		public decimal Price { get; set; }
		public List<string> DiscountsIncluded { get; set; }

		public Ticket(Client client, Flight flight, DateTime date)
		{
			Client = client;
			Flight = flight;
			Date = date;
			DiscountsIncluded = new List<string>();
		}

		public void ApplyDiscount(string discountName)
		{
			DiscountsIncluded.Add(discountName);
		}
	}
}
