using Contacts.Data.Models;
using Contacts.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories
{
    public class ContactGroupMembershipRepository : RepositoryBase<ContactGroupMembership>, IContactGroupMembershipRepository
    {
        public ContactGroupMembershipRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public Task<bool> AddContactToContactGroup(int contactId, int contactGroupId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveContactGroupToContactGroup(int ChildContactGroupId, int ParentContactGroupId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveContactToContactGroup(int ContactId, int ContactGroupId)
        {
            throw new NotImplementedException();
        }
    }
}
