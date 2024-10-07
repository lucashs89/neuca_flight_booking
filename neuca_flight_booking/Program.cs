// See https://aka.ms/new-console-template for more information
using neuca_flight_booking.Models;
using neuca_flight_booking.Repositories;
using neuca_flight_booking.Services;
using neuca_flight_booking.Services.Discounts;


// Discounts definition
var discountCriterias = new List<IDiscount> {
			new BirthdayDiscount(),
			new AfricaDiscount()
		};


// Defined customers
var customer1 = new Client("John", "Atick", new DateTime(1980, 10, 03), Tenant.A);
var customer2 = new Client("Jane", "Broke", new DateTime(1990, 12, 12), Tenant.B);
var customer3 = new Client("Jane", "Alen", new DateTime(1990, 12, 12), Tenant.A);


// Usecase 1 - searching flight by id

// Get flight by Id with discount Aftica

IFlightRepository flightRepository = new FlightRepository();
var searchedFlight = flightRepository.GetById("KLM00001AFR");
IPurchaseTicketService service = new PurchaseTicketService();

var ticket = service.BuyTicket(customer1, searchedFlight, discountCriterias);
var ticket2 = service.BuyTicket(customer2, searchedFlight, discountCriterias);
var ticket3 = service.BuyTicket(customer3, searchedFlight, discountCriterias);


Console.WriteLine("---------------Discounts - same flight to Africa on Thursday -------------------------------");

Console.WriteLine($"Regular ticker price {searchedFlight?.Price}");
Console.WriteLine($"Customer {ticket.Client.FirstName} {ticket.Client.TenantType} ticket price: {ticket.Price} EUR; discounts: {string.Join(", ", ticket.DiscountsIncluded)}");
Console.WriteLine($"Customer2 {ticket2.Client.FirstName} {ticket2.Client.TenantType}  ticket price: {ticket2.Price} EUR; discounts: {string.Join(", ", ticket2.DiscountsIncluded)}");
Console.WriteLine($"Customer3 {ticket3.Client.FirstName} {ticket3.Client.TenantType} ticket price: {ticket3.Price} EUR; discounts: {string.Join(", ", ticket3.DiscountsIncluded)}");





searchedFlight = flightRepository.GetById("KLM00002KRK");
ticket = service.BuyTicket(customer1, searchedFlight, discountCriterias);
ticket2 = service.BuyTicket(customer2, searchedFlight, discountCriterias);
ticket3 = service.BuyTicket(customer3, searchedFlight, discountCriterias);

Console.WriteLine("---------------Discounts - same flight to Krakow on Thursday -------------------------------");
Console.WriteLine($"Regular ticker price {searchedFlight?.Price}");
Console.WriteLine($"Customer {ticket.Client.FirstName} {ticket.Client.TenantType} ticket price: {ticket.Price} EUR discounts: {string.Join(", ", ticket.DiscountsIncluded)}");
Console.WriteLine($"Customer2 {ticket2.Client.FirstName} {ticket2.Client.TenantType} ticket price: {ticket2.Price} EUR discounts: {string.Join(", ", ticket2.DiscountsIncluded)}");
Console.WriteLine($"Customer3 {ticket3.Client.FirstName} {ticket3.Client.TenantType} ticket price: {ticket3.Price} EUR discounts: {string.Join(", ", ticket3.DiscountsIncluded)}");



// Usecase 2 posibility to add flights manually
// Manually added flight
var flight1 = new Flight("KLM12345AFR", "Amsterdam", "Africa", 50, new DateTime(2024, 10, 03, 14, 0, 0));
var flight2 = new Flight("LOT67890NEW", "Warsaw", "New York", 28, new DateTime(2024, 01, 15, 12, 0, 0)); // Same date as customer 2 birthday

// Can be added to repo and then searched as above.
var hasBeenAdded1 = flightRepository.AddFlight(flight1); // can verify w/e flight has been added to repo
var hasBeenAdded2 = flightRepository.AddFlight(flight2); // can verify w/e flight has been added to repo

// Can be directly used when buing a ticket
var ticketDirect = service.BuyTicket(customer1, flight1, discountCriterias);


Console.WriteLine("---------------History so far -------------------------------");

// Get all history from the system

var history = service.GetTickets();

foreach (var item in history)
{
	Console.WriteLine($"Customer  {item.Client.FirstName} {item.Client.LastName} {item.Client.TenantType}, flightID: {item.Flight.FlightID} ticket price: {item.Price} EUR discounts: {string.Join(", ", item.DiscountsIncluded)}");
}
Console.WriteLine("---------------END History so far -------------------------------");
