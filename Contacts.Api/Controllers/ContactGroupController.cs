using Contacts.Api.Models;
using Contacts.Api.Services.Interfaces;
using Contacts.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contacts.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactGroupController : ControllerBase
    {
        private readonly IContactGroupService _contactGroupService;
        private readonly ILogger<ContactGroupController> _logger;

        public ContactGroupController(IContactGroupService contactGroupService, ILogger<ContactGroupController> logger)
        {
            this._contactGroupService = contactGroupService;
            this._logger = logger;
        }
        // GET: api/<ContactGroupController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ContactGroupQueryParameters contactGroupQueryParameters)
        {
            var contactGroups = await _contactGroupService.GetContactGroups(contactGroupQueryParameters);
            var metadata = new
            {
                contactGroups.TotalCount,
                contactGroups.PageSize,
                contactGroups.CurrentPage,
                contactGroups.TotalPages,
                contactGroups.HasNext,
                contactGroups.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            _logger.LogInformation($"Returned {contactGroups.TotalCount} contacts from database.");

            return Ok(contactGroups);
        }

        // GET api/<ContactGroupController>/5
        [HttpGet("{contactGroupId}")]
        public string Get(int contactGroupId)
        {
            return "value";
        }

        // POST api/<ContactGroupController>
        [HttpPost]
        public void Post([FromBody] ContactGroup value)
        {
        }

        // PUT api/<ContactGroupController>/5
        [HttpPut("{contactGroupId}")]
        public void Put(int contactGroupId, [FromBody] ContactGroup value)
        {
        }

        // DELETE api/<ContactGroupController>/5
        [HttpDelete("{contactGroupId}")]
        public void Delete(int contactGroupId)
        {
        }


        [HttpPost]
        [Route("{ContactGroupId}/Contact/{ContactId}")]
        public void AddContactToContactGroup(int ContactId, int ContactGroupId)
        {

        }

        [HttpPost]
        [Route("{ContactGroupId}/Contact/{ContactId}")]
        public void RemoveContactToContactGroup(int ContactId, int ContactGroupId)
        {

        }

        [HttpPost]
        [Route("{ParentContactGroupId}/ContactGroup/{ChildContactGroupId}")]
        public void RemoveContactGroupToContactGroup(int ChildContactGroupId, int ParentContactGroupId)
        {

        }

    }
}
