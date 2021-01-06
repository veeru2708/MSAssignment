using Contacts.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Data.Repositories
{
    class ContactGroupRepository : RepositoryBase<ContactGroup>, IContactGroupRepository
    {

        public ContactRepository(ApplicationDbContext context) : base(context)
        {

        }



        public async Task<bool> AddContact(Contact contact)
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

        public async Task<bool> EditContact(Contact cont)
        {
            try
            {
                var dbContact = FindByCondition(contact => contact.Id.Equals(cont.Id))
               .DefaultIfEmpty(new Contact())
               .FirstOrDefault();
                dbContact.FirstName = cont.FirstName;
                dbContact.LastName = cont.LastName;
                dbContact.PhoneNumber = cont.PhoneNumber;
                Update(dbContact);
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public async Task<Contact> GetContactById(int contactId)
        {
            return FindByCondition(contact => contact.Id.Equals(contactId))
                .DefaultIfEmpty(new Contact())
                .FirstOrDefault();
        }

        public async Task<Contact> GetContact(Func<Contact, bool> condition)
        {
            return FindByCondition(contact => contact.Id.Equals(condition))
               .DefaultIfEmpty(new Contact())
               .FirstOrDefault();
        }

        public async Task<PagedList<Contact>> GetContacts(ContactQueryParameters contactQueryParameters)
        {
            return PagedList<Contact>.ToPagedList(FindAll(),
                     contactQueryParameters.PageNumber,
                     contactQueryParameters.PageSize);
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            try
            {
                var dbContact = FindByCondition(contact => contact.Id.Equals(contactId))
               .DefaultIfEmpty(new Contact())
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
