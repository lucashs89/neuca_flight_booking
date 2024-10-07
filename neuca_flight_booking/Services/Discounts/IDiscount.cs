using neuca_flight_booking.Models;

namespace neuca_flight_booking.Services.Discounts
{
	public interface IDiscount
	{
		string GetDiscountName();
		bool IsDiscountAvailable(Flight flight, Client client);
		public decimal Apply(decimal price);
	}
}
