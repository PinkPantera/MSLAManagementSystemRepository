using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSLAManagementSystem.API.Validation;
using MSLAManagementSystem.Core.Models;
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

            var newPerson = await personService.Create(person);
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

            if (await personService.GetById(person.Id) == null)
            {
                return NotFound();
            }

            await personService.Update(person);
            var updatedPerson = await personService.GetById(person.Id);

            return Ok(updatedPerson);
        }

    }
}
