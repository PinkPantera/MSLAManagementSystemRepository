using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class AddressController : ControllerBase
    {
        public IAddressService addressService;
        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }


        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<AddressEntity>>> GetAllAddresses()
        {
            var persons = await addressService.GetAllAsync();
            return Ok(persons);
        }
    }
}
