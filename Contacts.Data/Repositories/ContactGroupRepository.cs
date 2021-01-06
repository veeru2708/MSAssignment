using Contacts.Api.Models;
using Contacts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories
{
    class ContactGroupRepository : RepositoryBase<ContactGroup>, IContactGroupRepository
    {

        public ContactGroupRepository(ApplicationDbContext context) : base(context)
        {

        }



        public async Task<bool> AddContactGroup(ContactGroup contact)
        {
            try
            {
                Create(contact);
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public async Task<bool> EditContactGroup(ContactGroup cont)
        {
            try
            {
                var dbContactGroup = FindByCondition(contact => contact.ContactGroupId.Equals(cont.ContactGroupId))
               .DefaultIfEmpty(new ContactGroup())
               .FirstOrDefault();
                dbContactGroup.ContactGroupName = cont.ContactGroupName;
                
                Update(dbContactGroup);
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public async Task<ContactGroup> GetContactGroup(int contactId)
        {
            return FindByCondition(contact => contact.ContactGroupId.Equals(contactId))
                .DefaultIfEmpty(new ContactGroup())
                .FirstOrDefault();
        }

        public async Task<ContactGroup> GetContactGroups(Func<ContactGroup, bool> condition)
        {
            return FindByCondition(contact => contact.ContactGroupId.Equals(condition))
               .DefaultIfEmpty(new ContactGroup())
               .FirstOrDefault();
        }

        public async Task<PagedList<ContactGroup>> GetContactGroups(ContactGroupQueryParameters contactQueryParameters)
        {
            return PagedList<ContactGroup>.ToPagedList(FindAll(),
                     contactQueryParameters.PageNumber,
                     contactQueryParameters.PageSize);
        }

        public async Task<bool> DeleteContactGroup(int contactId)
        {
            try
            {
                var dbContact = FindByCondition(contactGroup => contactGroup.ContactGroupId.Equals(contactId))
               .DefaultIfEmpty(new ContactGroup())
               .FirstOrDefault();
                Delete(dbContact);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
