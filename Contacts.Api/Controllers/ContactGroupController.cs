using Contacts.Api.Domain;
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

            _logger.LogInformation($"Returned {contactGroups.TotalCount} contact Groups from database.");

            return Ok(contactGroups);
        }

        // GET api/<ContactGroupController>/5
        [HttpGet("{contactGroupId}")]
        public async Task<IActionResult> Get(int contactGroupId)
        {
            var contactGroup = await _contactGroupService.GetContactGroupById(contactGroupId);

            if (contactGroup == null)
            {
                _logger.LogError($"Contact Group with id: {contactGroupId}, hasn't been found in db.");
                return NotFound();
            }

            return Ok(contactGroup);
        }

        // POST api/<ContactGroupController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ContactGroupDomain contactGroup)
        {
            try
            {
                if (contactGroup == null)
                {
                    _logger.LogError("Contact Group object sent from client is null.");
                    return BadRequest("Contact Group object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Contact Group object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var contactExists = await _contactGroupService.ContactGroupExists(contactGroup);
                if (contactExists)
                {
                    return StatusCode(409, new { message = $"Contact Group with name {contactGroup.ContactGroupName}  already exists." });

                }

                var result = await _contactGroupService.AddContactGroup(contactGroup);
                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // PUT api/<ContactGroupController>/5
        [HttpPut("{contactGroupId}")]
        public async Task<IActionResult> Put(int contactGroupId, [FromBody] ContactGroupDomain contactGroup)
        {
            if (contactGroup == null)
            {
                _logger.LogError("contact Group object sent from client is null.");
                return BadRequest("contact Group object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid contact object sent from client.");
                return BadRequest("Invalid model object");
            }

            var dbContact = await _contactGroupService.GetContactGroupById(contactGroupId);
            if (dbContact == null)
            {
                _logger.LogError($"Contact Group with id: {contactGroupId}, hasn't been found in db.");
                return NotFound();
            }

            var result = await _contactGroupService.EditContactGroup(contactGroup);
            if (result)
                return Ok();
            else
                return BadRequest();

        }

        // DELETE api/<ContactGroupController>/5
        [HttpDelete("{contactGroupId}")]
        public async Task<IActionResult> Delete(int contactGroupId)
        {
            var contactGroup = await _contactGroupService.GetContactGroupById(contactGroupId);
            if (contactGroup.ContactGroupId > 0)
            {
                _logger.LogError($"Contact with id: {contactGroupId}, hasn't been found in db.");
                return NotFound();
            }

            await _contactGroupService.DeleteContactGroup(contactGroup.ContactGroupId);

            return NoContent();
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
