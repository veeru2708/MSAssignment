using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Api.Domain;
using Contacts.Api.Models;
using Contacts.Data.Models;

namespace Contacts.Api.Services.Interfaces
{
    public interface IContactService
    {
        Task<bool> AddContact(ContactDomain contact);

        Task<bool> EditContact(ContactDomain contact);
        
        Task<PagedList<Contact>> GetContacts(ContactQueryParameters contactQueryParameters);

        Task<bool> ContactExists(ContactDomain contact);

        Task<ContactDomain> GetContactById(int contactId);

        Task<bool> DeleteContact(int contactId);
    }
   
}
