using Contacts.Api.Models;
using Contacts.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories.Interface
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
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

            var contacts = FindAll();
            if(!string.IsNullOrEmpty(contactQueryParameters.FirstName))
                SearchByFirstName(ref contacts, contactQueryParameters.FirstName);
            if (!string.IsNullOrEmpty(contactQueryParameters.LastName))
                SearchByLastName(ref contacts, contactQueryParameters.LastName);
            if (contactQueryParameters.PhoneNumber > 0 )
                SearchByNumber(ref contacts, contactQueryParameters.PhoneNumber);

            return PagedList<Contact>.ToPagedList(contacts,
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

        private void SearchByFirstName(ref IQueryable<Contact> contacts, string firstName)
        {
            if (!contacts.Any() || string.IsNullOrWhiteSpace(firstName))
                return;
            contacts = contacts.Where(c => c.FirstName.ToLower().Contains(firstName.Trim().ToLower()));
        }

        private void SearchByLastName(ref IQueryable<Contact> contacts, string LastName)
        {
            if (!contacts.Any() || string.IsNullOrWhiteSpace(LastName))
                return;
            contacts = contacts.Where(c => c.LastName.ToLower().Contains(LastName.Trim().ToLower()));
        }

        private void SearchByNumber(ref IQueryable<Contact> contacts, double phoneNumber)
        {
            if (!contacts.Any() || phoneNumber == 0)
                return;
            contacts = contacts.Where(c => c.PhoneNumber == phoneNumber);
        }

    }
}
