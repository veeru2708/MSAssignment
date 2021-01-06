using Contacts.Api.Models;
using Contacts.Data.Models;
using System;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories
{
    public interface IContactGroupRepository
    {
        Task<bool> AddContactGroup(Contact contact);

        Task<bool> EditContactGroup(Contact cont);

        Task<PagedList<ContactGroup>> GetContactGroups(ContactGroupQueryParameters contactQueryParameters);

        Task<Contact> GetContactGroups(Func<Contact, bool> condition);

        Task<Contact> GetContactGroup(int contactId);

        Task<bool> DeleteContact(int contactId);
    }
}
