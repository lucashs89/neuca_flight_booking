using neuca_flight_booking.Models;
using System.Text.RegularExpressions;

namespace neuca_flight_booking.Repositories
{
	public class FlightRepository : IFlightRepository
	{
		private readonly List<Flight> _flightRepository = new List<Flight>();

		public FlightRepository()
		{
			// Add temporary flights there, normally will be pulled from db 
			_flightRepository.Add(new Flight("KLM00001AFR", "Krakow", "Africa", 50, new DateTime(2024, 12, 12))); // Thursday
			_flightRepository.Add(new Flight("KLM00002KRK", "Warsaw", "Krakow", 70, new DateTime(2024, 12, 12))); // Thursday
			_flightRepository.Add(new Flight("KLM00003AFR", "Krakow", "Africa", 80, new DateTime(2024, 12, 13))); // Friday
		}

		public Flight GetById(string id)
		{
			return _flightRepository.FirstOrDefault(x => x.FlightID == id);
		}


		public bool AddFlight(Flight flight)
		{
			// Validate flightID as per requirements
			if (!ValidateFlightId(flight.FlightID)) return false;

			if (GetById(flight.FlightID) == null)
			{
				_flightRepository.Add(flight);
				return true;
			}
			else
			{
				return false;
			}

		}

		public List<Flight> GetFlights()
		{
			return _flightRepository;
		}

		private bool ValidateFlightId(string flightId)
		{
			string pattern = @"^[A-Z]{3} \d{5} [A-Z]{3}$";
			return Regex.IsMatch(flightId, pattern);
		}
	}
}
