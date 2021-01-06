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



        public async Task<bool> AddContactGroup(ContactGroup contactGroup)
        {
            try
            {
                Create(contactGroup);
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public async Task<bool> EditContactGroup(ContactGroup contactGroup)
        {
            try
            {
                var dbContactGroup = FindByCondition(contact => contact.ContactGroupId.Equals(contactGroup.ContactGroupId))
               .DefaultIfEmpty(new ContactGroup())
               .FirstOrDefault();
                dbContactGroup.ContactGroupName = contactGroup.ContactGroupName;
                
                Update(dbContactGroup);
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public async Task<ContactGroup> GetContactGroup(int contactGroupId)
        {
            return FindByCondition(contactGroup => contactGroup.ContactGroupId.Equals(contactGroupId))
                .DefaultIfEmpty(new ContactGroup())
                .FirstOrDefault();
        }

        public async Task<ContactGroup> GetContactGroups(Func<ContactGroup, bool> condition)
        {
            return FindByCondition(contactGroup => contactGroup.ContactGroupId.Equals(condition))
               .DefaultIfEmpty(new ContactGroup())
               .FirstOrDefault();
        }

        public async Task<ContactGroup> GetContactGroupById(int contactGroupId)
        {
            return FindByCondition(contactGroup => contactGroup.ContactGroupId.Equals(contactGroupId))
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
