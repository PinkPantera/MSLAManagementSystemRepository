using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSLAManagementSystem.API.Validation;
using MSLAManagementSystem.Core.Entities;
using MSLAManagementSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSLAManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PersonEntity>>> GetAllPersons()
        {
            var persons = await personService.GetAllWithAddressAsync();
            return Ok(persons);
        }

        [HttpPost("")]
        public async Task<ActionResult<PersonEntity>> AddPerson(PersonEntity person)
        {
            var personValidation = new PersonValidation();
            var resultPerson = await personValidation.ValidateAsync(person);
            var addressValidation = new AddressValidation();

            var resultAddress = await addressValidation.ValidateAsync(person.Address);

            if (!resultPerson.IsValid || !resultAddress.IsValid)
            {
                var error = $"{resultPerson.ToString("\n")}\n{resultAddress.ToString("\n")}";
                return BadRequest(error);
            }

            var newPerson = await personService.CreateAsync(person);
            return Ok(newPerson);
        }

        [HttpPut("")]
        public async Task<ActionResult<PersonEntity>> UpdatePerson(PersonEntity person)
        {
            var personValidation = new PersonValidation();
            var resultPerson = await personValidation.ValidateAsync(person);
            var addressValidation = new AddressValidation();

            var resultAddress = await addressValidation.ValidateAsync(person.Address);

            if (!resultPerson.IsValid || !resultAddress.IsValid)
            {
                var error = $"{resultPerson.ToString("\n")}\n{resultAddress.ToString("\n")}";
                return BadRequest(error);
            }

            if (await personService.GetByIdAsync(person.Id) == null)
            {
                return NotFound();
            }

            await personService.UpdateAsync(person);
            var updatedPerson = await personService.GetByIdAsync(person.Id);

            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            var personToDesactivate = await personService.GetByIdAsync(id);

            if (personToDesactivate== null)
            {
                return BadRequest("Person does not exist");  
            }

            await personService.DeactivatePerson(id);
            return NoContent();
        }

    }
}
