namespace Contacts.Data.Repositories.Interface
{
    public interface IRepositoryWrapper
    {
        IContactRepository contact { get; }

        IContactGroupRepository contactGroup { get; }

        IContactGroupMembershipRepository contactGroupMembership { get; }

        void Save();
    }
}
