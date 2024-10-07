using neuca_flight_booking.Models;

namespace neuca_flight_booking.Services.Discounts
{
	public class BirthdayDiscount : IDiscount
	{
		public decimal Apply(decimal price) => price - 5;
		public string GetDiscountName() => "Birthday";
		public bool IsDiscountAvailable(Flight flight, Client client)
		{
			return client.BirthDate.Day == flight.Date.Day &&
				   client.BirthDate.Month == flight.Date.Month;
		}
	}
}
