using Contacts.Api.Domain;
using Contacts.Api.Models;
using Contacts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Api.Services.Interfaces
{
    public interface IContactGroupService
    {

        Task<bool> AddContactGroup(ContactGroupDomain contact);

        Task<bool> EditContactGroup(ContactGroupDomain contact);

        Task<PagedList<ContactGroup>> GetContactGroups(ContactGroupQueryParameters contactQueryParameters);

        Task<bool> ContactGroupExists(ContactGroupDomain contact);

        Task<ContactGroupDomain> GetContactGroupById(int contactId);

        Task<bool> DeleteContactGroup(int contactId);
    }
}
