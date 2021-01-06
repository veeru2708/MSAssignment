namespace Contacts.Data.Repositories.Interface
{
    public interface IRepositoryWrapper
    {
        IContactRepository contact { get; }
        
        void Save();
    }
}
