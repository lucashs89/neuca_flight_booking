using neuca_flight_booking.Models;

namespace neuca_flight_booking.Repositories
{
	public class LocalListPurchaseRepository : ITicketPurchaseRepository
	{
		private readonly List<Ticket> _ticketsRepository = new List<Ticket>();

		public bool Save(Ticket ticket)
		{
			try
			{
				_ticketsRepository.Add(ticket);
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString()); // Handle exception in proper logger
				return false;
			}
		}

		public List<Ticket> GetTicketHistory()
		{
			return _ticketsRepository;
		}
	}

}
