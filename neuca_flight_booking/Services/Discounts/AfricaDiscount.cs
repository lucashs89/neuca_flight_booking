using neuca_flight_booking.Models;

namespace neuca_flight_booking.Services.Discounts
{
	public class AfricaDiscount : IDiscount
	{
		public decimal Apply(decimal price) => price - 5;
		public string GetDiscountName() => "Africa";
		public bool IsDiscountAvailable(Flight flight, Client client) => flight.Destination == "Africa" && flight.DayOfWeek == DayOfWeek.Thursday;
	}
}
