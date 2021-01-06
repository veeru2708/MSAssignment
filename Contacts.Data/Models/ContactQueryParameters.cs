using Contacts.Api.Domain;

namespace Contacts.Api.Models
{
    public class ContactQueryParameters : QueryStringParameters
	{
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double PhoneNumber { get; set; }
    }
}
