using AutoMapper;
using Contacts.Api.Domain;
using Contacts.Api.Services.Interfaces;
using Contacts.Data.Models;
using Contacts.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Api.Services
{
    public class ContactService : IContactService
    {
        private IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public ContactService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper)); ;
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }
               
        public async Task<bool> AddContact(ContactDomain contact)
        {
            var _contact = _mapper.Map<Contact>(contact);

            return await _repositoryWrapper.contact.AddContact(_contact);
            
        }

        public async Task<bool> ContactExists(ContactDomain contact)
        {
            var contactExists = await _repositoryWrapper.contact.GetContact(x => x.FirstName == contact.FirstName
                                                                        && x.LastName == contact.LastName
                                                                        && x.PhoneNumber == contact.PhoneNumber);
            if (contactExists.Id > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> EditContact(ContactDomain contact)
        {
            var _contact = _mapper.Map<Contact>(contact);

            return await _repositoryWrapper.contact.EditContact(_contact);
        }

        public async Task<ContactDomain> GetContactById(int contactId)
        {
            var contact = await _repositoryWrapper.contact.GetContactById(contactId);
            var contactDomain = _mapper.Map<ContactDomain>(contact);
            return contactDomain;
        }

        public async Task<PagedList<Contact>> GetContacts(ContactQueryParameters contactQueryParameters)
        {
            var contact = await _repositoryWrapper.contact.GetContacts(contactQueryParameters);
            
            return contact;
        }

        public async Task<bool> DeleteContact(int contactId)
        {

            return await _repositoryWrapper.contact.DeleteContact(contactId) ;
        }
    }
}
