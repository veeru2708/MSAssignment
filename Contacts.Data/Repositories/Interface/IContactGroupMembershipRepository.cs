using System.Threading.Tasks;

namespace Contacts.Data.Repositories.Interface
{
    public interface IContactGroupMembershipRepository
    {
        Task<bool> AddContactToContactGroup(int contactId, int contactGroupId);
        Task<bool> RemoveContactToContactGroup(int ContactId, int ContactGroupId);
        Task<bool> RemoveContactGroupToContactGroup(int ChildContactGroupId, int ParentContactGroupId);
    }
}
