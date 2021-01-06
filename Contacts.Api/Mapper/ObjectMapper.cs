using AutoMapper;
using Contacts.Api.Domain;
using Contacts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Api.Mapper
{
    public class ObjectMapper : Profile
    {
        public ObjectMapper()
        {
            CreateMap<ContactDomain, Contact>();
            CreateMap<Contact, ContactDomain>();
            CreateMap<PagedList<Contact>, PagedList<ContactDomain>>();
            CreateMap<PagedList<ContactDomain>, PagedList<Contact>>();
        }
    }
}
