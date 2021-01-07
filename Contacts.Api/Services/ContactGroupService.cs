using AutoMapper;
using Contacts.Api.Domain;
using Contacts.Api.Models;
using Contacts.Api.Services.Interfaces;
using Contacts.Data.Models;
using Contacts.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Api.Services
{
    public class ContactGroupService : IContactGroupService
    {

        private IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public ContactGroupService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper)); ;
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }
        public async Task<bool> AddContactGroup(ContactGroupDomain contractGroup)
        {
            var _contactGroup = _mapper.Map<ContactGroup>(contractGroup);

            return await _repositoryWrapper.contactGroup.AddContactGroup(_contactGroup);
        }

        public async Task<bool> ContactGroupExists(ContactGroupDomain contact)
        {
            var contactExists = await _repositoryWrapper.contactGroup.GetContactGroup(contact.ContactGroupId);
            if (contactExists.ContactGroupId > 0)
            {
                return true;
            }
            return false;
        }

        public Task<bool> DeleteContactGroup(int contactId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditContactGroup(ContactGroupDomain contactGroup)
        {
            var _contactGroup = _mapper.Map<Contact>(contactGroup);
            return await _repositoryWrapper.contact.EditContact(_contactGroup);
        }

        public async Task<ContactGroupDomain> GetContactGroupById(int contactId)
        {
            var contactGroup = await _repositoryWrapper.contactGroup.GetContactGroupById(contactId);
            var contactGroupDomain = _mapper.Map<ContactGroupDomain>(contactGroup);
            return contactGroupDomain;
        }

        public async Task<PagedList<ContactGroup>> GetContactGroups(ContactGroupQueryParameters contactGroupQueryParameters)
        {
            var contact = await _repositoryWrapper.contactGroup.GetContactGroups(contactGroupQueryParameters);

            return contact;
        }

       
    }
}
