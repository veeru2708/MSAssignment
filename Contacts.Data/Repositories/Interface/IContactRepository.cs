using Contacts.Api.Models;
using Contacts.Data.Models;
using System;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories.Interface
{
    public interface IContactRepository
    {
        Task<bool> AddContact(Contact contact);

        Task<bool> EditContact(Contact cont);

        Task<PagedList<Contact>> GetContacts(ContactQueryParameters contactQueryParameters);

        Task<Contact> GetContact(Func<Contact, bool> condition);

        Task<Contact> GetContactById(int contactId);

        Task<bool> DeleteContact(int contactId);
    }
}
