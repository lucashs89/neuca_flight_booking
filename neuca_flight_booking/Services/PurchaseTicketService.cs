using neuca_flight_booking.Models;
using neuca_flight_booking.Repositories;
using neuca_flight_booking.Services.Discounts;

namespace neuca_flight_booking.Services
{
	public class PurchaseTicketService : IPurchaseTicketService
	{

		private readonly ITicketPurchaseRepository _repository;

		public PurchaseTicketService()
		{
			_repository = new LocalListPurchaseRepository();
		}

		public Ticket BuyTicket(Client? client, Flight? flight, IList<IDiscount> discounts)
		{
			if (client == null) throw new ArgumentNullException(nameof(client));
			if (flight == null) throw new ArgumentNullException(nameof(flight));

			decimal finalPrice = flight.Price;
			var buyDate = DateTime.Now;
			var ticket = new Ticket(client, flight, buyDate);

			foreach (var criteria in discounts)
			{
				if (criteria.IsDiscountAvailable(flight, client) && finalPrice > 20)
				{
					decimal newPrice = criteria.Apply(finalPrice);
					if (newPrice >= 20)
					{
						finalPrice = newPrice;
						ticket.ApplyDiscount(criteria.GetDiscountName());
					}
					ticket.Price = newPrice;
				}
				else
				{
					ticket.Price = finalPrice;
				}
			}

			// For group B don't show and don't save
			if (client.TenantType == Tenant.B)
			{
				ticket.DiscountsIncluded.Clear();
			}
			_repository.Save(ticket);
			return ticket;
		}

		public List<Ticket> GetTickets()
		{
			return _repository.GetTicketHistory();
		}
	}
}
