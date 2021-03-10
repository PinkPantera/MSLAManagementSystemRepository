using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
