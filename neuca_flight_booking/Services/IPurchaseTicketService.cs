using neuca_flight_booking.Models;
using neuca_flight_booking.Services.Discounts;

namespace neuca_flight_booking.Services
{
	public interface IPurchaseTicketService
	{
		Ticket BuyTicket(Client? client, Flight? flight, IList<IDiscount> discounts);
		List<Ticket> GetTickets();
	}
}
