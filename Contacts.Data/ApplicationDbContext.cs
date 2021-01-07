using Contacts.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Contacts.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {
            LoadContacts();
            LoadContactGroups();
            LoadContactGroupMembership();
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
                ContactGroupId = 4,
                ContactGroupName = "TestGroup3"

            };
            ContactGroups.Add(contactGroup1);
            ContactGroups.Add(contactGroup2);
            ContactGroups.Add(contactGroup3);
            ContactGroups.Add(contactGroup4);
        }

        public void LoadContactGroupMembership()
        {
            var contactGroupMembership1 = new ContactGroupMembership();
            contactGroupMembership1.ContactId = 1;
            contactGroupMembership1.ContactGroupId = 0;
            contactGroupMembership1.MemberShipType = "Contact";
            contactGroupMembership1.ContactGroupMembershipId = 1;
            contactGroupMembership1.ParentContactGroupId = 1;

            var contactGroupMembership2 = new ContactGroupMembership();
            contactGroupMembership2.ContactId = 2;
            contactGroupMembership2.ContactGroupId = 0;
            contactGroupMembership2.MemberShipType = "Contact";
            contactGroupMembership2.ContactGroupMembershipId = 2;
            contactGroupMembership2.ParentContactGroupId = 1;

            var contactGroupMembership3 = new ContactGroupMembership();
            contactGroupMembership3.ContactId = 0;
            contactGroupMembership3.ContactGroupId = 1;
            contactGroupMembership3.MemberShipType = "ContactGroup";
            contactGroupMembership3.ContactGroupMembershipId = 3;
            contactGroupMembership3.ParentContactGroupId = 1;

            var contactGroupMembership4 = new ContactGroupMembership();
            contactGroupMembership4.ContactId = 2;
            contactGroupMembership4.ContactGroupId = 0;
            contactGroupMembership4.MemberShipType = "Contact";
            contactGroupMembership4.ContactGroupMembershipId = 4;
            contactGroupMembership4.ParentContactGroupId = 2;

            var contactGroupMembership5 = new ContactGroupMembership();
            contactGroupMembership5.ContactId = 0;
            contactGroupMembership5.ContactGroupId = 2;
            contactGroupMembership5.MemberShipType = "ContactGroup";
            contactGroupMembership5.ContactGroupMembershipId = 5;
            contactGroupMembership5.ParentContactGroupId = 2;

            var contactGroupMembership6 = new ContactGroupMembership();
            contactGroupMembership6.ContactId = 3;
            contactGroupMembership6.ContactGroupId = 0;
            contactGroupMembership6.MemberShipType = "ContactGroup";
            contactGroupMembership6.ContactGroupMembershipId = 6;
            contactGroupMembership6.ParentContactGroupId = 2;

            ContactGroupMemberships.Add(contactGroupMembership1);
            ContactGroupMemberships.Add(contactGroupMembership2);
            ContactGroupMemberships.Add(contactGroupMembership3);
            ContactGroupMemberships.Add(contactGroupMembership4);
            ContactGroupMemberships.Add(contactGroupMembership5);
            ContactGroupMemberships.Add(contactGroupMembership6);



        }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactGroup> ContactGroups { get; set; }

        public DbSet<ContactGroupMembership> ContactGroupMemberships { get; set; }
    }
}
