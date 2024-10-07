using neuca_flight_booking.Models;

namespace neuca_flight_booking.Repositories
{
	public interface IFlightRepository
	{
		Flight GetById(string id);
		bool AddFlight(Flight flight);
		List<Flight> GetFlights();
	}
}
