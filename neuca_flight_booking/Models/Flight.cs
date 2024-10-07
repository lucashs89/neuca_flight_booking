namespace neuca_flight_booking.Models
{
	public class Flight
	{
		public string FlightID { get; private set; }
		public string Destination { get; private set; }
		public string Departure { get; private set; }
		public decimal Price { get; private set; }
		public DateTime Date { get; private set; }
		public DayOfWeek DayOfWeek => Date.DayOfWeek; // Day of week is based on current time ( don't need to be stored in repo )

		public Flight(string id, string departure, string destination, decimal price, DateTime date)
		{
			FlightID = id;
			Price = price;
			Destination = destination;
			Departure = departure;
			Date = date;
		}
	}
}
