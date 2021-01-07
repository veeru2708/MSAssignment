using AutoMapper;
using Contacts.Api.Domain;
using Contacts.Data.Models;
using Contacts.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Api.Services.Interfaces
{
    public class ContactGroupMembershipService : IContactGroupMembershipService
    {

        private IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public ContactGroupMembershipService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper)); ;
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        public async Task<bool> AddContactToContactGroup(int contactId, int contactGroupId)
        {
            var contact = await _repositoryWrapper.contactGroupMembership.AddContactToContactGroup(contactId, contactGroupId);
            return contact;
        }

        public Task<ContactGroupMembership> GetContactGroupMembership(int contactGroupId)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<ContactGroupMembership>> GetContactGroupMembershipByParentContactGroupId(int parentContactGroupId)
        {
            var contactGrpMemberships = await _repositoryWrapper.contactGroupMembership.GetContactGroupMembershipByParentContactGroupId(parentContactGroupId);
            return contactGrpMemberships;
        }

        public async Task<ContactGroupMembershipDomain> GetContactGroupMembership(ContactGroupMembershipQueryParameters contactGroupMembershipQueryParameters)
        {
            var result = await _repositoryWrapper.contactGroupMembership.GetContactGroupMembership(contactGroupMembershipQueryParameters);
            var contactGroupMembershipDomain = new ContactGroupMembershipDomain();
            var contactGroups = result.Select(x =>  _repositoryWrapper.contactGroup.GetContactGroupById(x.ContactGroupId).Result);
            var contacts = result.Select(x => _repositoryWrapper.contact.GetContactById(x.ContactId).Result);

            
            contactGroupMembershipDomain.ContactGroupName = result.Select(x=> _repositoryWrapper.contactGroup.GetContactGroupById(x.ParentContactGroupId).Result.ContactGroupName).FirstOrDefault();
            
            return contactGroupMembershipDomain;
            
        }
    }
}
