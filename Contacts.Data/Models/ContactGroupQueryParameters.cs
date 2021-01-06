using Contacts.Api.Domain;

namespace Contacts.Api.Models
{
    public class ContactGroupQueryParameters : QueryStringParameters
	{
		public string ContactGroupName { get; set; }
	}
}
