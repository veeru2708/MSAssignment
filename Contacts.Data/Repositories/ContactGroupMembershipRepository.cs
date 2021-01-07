using Contacts.Data.Models;
using Contacts.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IQueryable<ContactGroupMembership>> GetContactGroupMembership()
        {
            return FindAll();
        }

        public async Task<PagedList<ContactGroupMembership>> GetContactGroupMembership(ContactGroupMembershipQueryParameters contactGroupMembershipQueryParameters)
        {
            var result = FindAll();

            var contactGroup = RepositoryContext.ContactGroups.Where(x => x.ContactGroupName == contactGroupMembershipQueryParameters.ContactGroupName).FirstOrDefault();
            result = result.Where(x => x.ParentContactGroupId == contactGroup.ContactGroupId);
            return PagedList<ContactGroupMembership>.ToPagedList(FindAll(),
                     contactGroupMembershipQueryParameters.PageNumber,
                     contactGroupMembershipQueryParameters.PageSize);
        }

        public async Task<IQueryable<ContactGroupMembership>> GetContactGroupMembershipByParentContactGroupId(int parentContactGroupId)
        {
            return FindByCondition(contactGroup => contactGroup.ParentContactGroupId.Equals(parentContactGroupId));
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
