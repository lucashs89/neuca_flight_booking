using neuca_flight_booking.Models;

namespace neuca_flight_booking.Repositories
{
	public interface ITicketPurchaseRepository
	{
		bool Save(Ticket ticket);
		List<Ticket> GetTicketHistory();
	}
}
