using Contacts.Data.Repositories.Interface;

namespace Contacts.Data.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _repoContext;

        private IContactRepository _contact;

        private IContactGroupRepository _contactGroup;


        public IContactRepository contact
        {
            get
            {
                if (_contact == null)
                {
                    _contact = new ContactRepository(_repoContext);
                }

                return _contact;
            }
        }

        public IContactGroupRepository contactGroup
        {
            get
            {
                if (_contactGroup == null)
                {
                    _contactGroup = new ContactGroupRepository(_repoContext);
                }

                return _contactGroup;
            }
        }



        public RepositoryWrapper(ApplicationDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
