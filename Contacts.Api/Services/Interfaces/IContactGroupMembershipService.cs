using Contacts.Api.Domain;
using Contacts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Api.Services.Interfaces
{
    public interface IContactGroupMembershipService
    {
        Task<bool> AddContactToContactGroup(int ContactId, int ContactGroupId);

        Task<ContactGroupMembership> GetContactGroupMembership(int contactGroupId);

        Task<IQueryable<ContactGroupMembership>> GetContactGroupMembershipByParentContactGroupId(int parentContactGroupId);

        Task<ContactGroupMembershipDomain> GetContactGroupMembership(ContactGroupMembershipQueryParameters contactGroupMembershipQueryParameters);
    }
}
