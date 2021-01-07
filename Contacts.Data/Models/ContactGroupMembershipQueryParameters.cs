using Contacts.Api.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Data.Models
{
    public class ContactGroupMembershipQueryParameters : QueryStringParameters
    {
        public string ContactGroupName { get; set; }
    }
}
