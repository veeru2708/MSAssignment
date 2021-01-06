using Contacts.Api.Models;
using Contacts.Data.Models;
using System;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories
{
    public interface IContactGroupRepository
    {
        Task<bool> AddContactGroup(ContactGroup contact);

        Task<bool> EditContactGroup(ContactGroup cont);

        Task<PagedList<ContactGroup>> GetContactGroups(ContactGroupQueryParameters contactQueryParameters);

        Task<ContactGroup> GetContactGroups(Func<ContactGroup, bool> condition);

        Task<ContactGroup> GetContactGroup(int contactId);

        Task<ContactGroup> GetContactGroupById(int contactGroupId);

        Task<bool> DeleteContactGroup(int contactId);
    }
}
