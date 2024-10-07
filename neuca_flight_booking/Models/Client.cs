namespace neuca_flight_booking.Models
{
	public class Client
	{
		public DateTime BirthDate { get; private set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Tenant TenantType { get; set; }

		public Client(string firstName, string lastName, DateTime birthdayDate, Tenant tenantType)
		{
			FirstName = firstName;
			LastName = lastName;
			TenantType = tenantType;
			BirthDate = birthdayDate;
		}
	}
}
