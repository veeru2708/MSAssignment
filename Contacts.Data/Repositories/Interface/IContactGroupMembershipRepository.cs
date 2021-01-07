using Contacts.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories.Interface
{
    public interface IContactGroupMembershipRepository
    {
        Task<bool> AddContactToContactGroup(int contactId, int contactGroupId);
        Task<bool> RemoveContactToContactGroup(int contactId, int contactGroupId);
        Task<bool> RemoveContactGroupToContactGroup(int childContactGroupId, int parentContactGroupId);

        Task<IQueryable<ContactGroupMembership>> GetContactGroupMembershipByParentContactGroupId(int parentContactGroupId);

        Task<PagedList<ContactGroupMembership>> GetContactGroupMembership(ContactGroupMembershipQueryParameters contactGroupMembershipQueryParameters);
    }
}
