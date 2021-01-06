using Contacts.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {
            LoadContacts();
        }

        public void LoadContacts()
        {
            var contact1 = new Contact()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                PhoneNumber = 999

            };
            var contact2 = new Contact()
            {
                Id = 2,
                FirstName = "Smith",
                LastName = "Joe",
                PhoneNumber = 888
            };
            var contact3 = new Contact()
            {
                Id = 3,
                FirstName = "David",
                LastName = "Mueller",
                PhoneNumber = 777
            };
            var contact4 = new Contact()
            {
                Id = 4,
                FirstName = "Jack",
                LastName = "Bawer",
                PhoneNumber = 666
            };
            Contacts.Add(contact1);
            Contacts.Add(contact2);
            Contacts.Add(contact3);
            Contacts.Add(contact4);
        }

        public void LoadContactGroups()
        {
            var contactGroup1 = new ContactGroup()
            {
               ContactGroupId = 1,
               ContactGroupName = "TestGroup1"
            };
            var contactGroup2 = new ContactGroup()
            {
                ContactGroupId = 2,
                ContactGroupName = "TestGroup2"
            };
            var contactGroup3 = new ContactGroup()
            {
                ContactGroupId = 3,
                ContactGroupName = "TestGroup3"
            };
            var contactGroup4 = new ContactGroup()
            {
                ContactGroupId = 1,
                ContactGroupName = "TestGroup3"

            };
            ContactGroups.Add(contactGroup1);
            ContactGroups.Add(contactGroup2);
            ContactGroups.Add(contactGroup3);
            ContactGroups.Add(contactGroup4);
        }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactGroup> ContactGroups { get; set; }
    }
}
