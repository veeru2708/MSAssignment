using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Api.Domain
{
    public class ContactGroupMembershipDomain : QueryStringParameters
    {
        public string ContactGroupName { get; set; }
        public List<ContactDomain> Contact { get; set; }
        public List<ContactGroupDomain> ContactGroup { get; set; }
    }
}
