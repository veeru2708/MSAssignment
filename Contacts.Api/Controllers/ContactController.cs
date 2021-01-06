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
    public class ContactController : ControllerBase
    {

        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;

        public ContactController(ILogger<ContactController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }
        // GET: api/<ContactController>
        /// <summary>
        /// Returns the paged contacts
        /// </summary>
        /// <param name="contactQueryParameters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ContactQueryParameters contactQueryParameters)
        {
            var contacts = await _contactService.GetContacts(contactQueryParameters);

           
            var metadata = new
            {
                contacts.TotalCount,
                contacts.PageSize,
                contacts.CurrentPage,
                contacts.TotalPages,
                contacts.HasNext,
                contacts.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            _logger.LogInformation($"Returned {contacts.TotalCount} owners from database.");

            return Ok(contacts);
        }


        [HttpGet("{contactId}")]
        public async Task<IActionResult> Get(int contactId)
        {
            var contact = await _contactService.GetContactById(contactId);

            if (contact == null)
            {
                _logger.LogError($"Contact with id: {contactId}, hasn't been found in db.");
                return NotFound();
            }

            return Ok(contact);
        }

      
        // POST api/<ContactController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ContactDomain contact)
        {
            try
            {

                if (contact == null)
                {
                    _logger.LogError("Contact object sent from client is null.");
                    return BadRequest("Contact object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Contact object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var contactExists = await _contactService.ContactExists(contact);
                if (contactExists)
                {
                    return StatusCode(409, new { message = $"Contact with name {contact.FirstName} {contact.LastName} and phone number {contact.PhoneNumber} already exists." });

                }

                var result = await _contactService.AddContact(contact);
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

        // PUT api/<ContactController>/5
        [HttpPut("{contactId}")]
        public async Task<IActionResult> Edit(int contactId, ContactDomain contact)
        {

            if (contact == null)
            {
                _logger.LogError("contact object sent from client is null.");
                return BadRequest("contact object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid contact object sent from client.");
                return BadRequest("Invalid model object");
            }

            var dbContact = await _contactService.GetContactById(contactId);
            if (dbContact == null)
            {
                _logger.LogError($"Contact with id: {contactId}, hasn't been found in db.");
                return NotFound();
            }

            var result = await _contactService.EditContact(contact);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{contactId}")]
        public async Task<IActionResult> Delete(int contactId)
        {
            var contact = await  _contactService.GetContactById(contactId);
            if (contact.Id> 0)
            {
                _logger.LogError($"Contact with id: {contactId}, hasn't been found in db.");
                return NotFound();
            }

            await _contactService.DeleteContact(contact.Id);

            return NoContent();
        }

        
    }
    
}
