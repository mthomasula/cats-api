using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatsAPI.DTOs;
using CatsAPI.Services.AddressesService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatsAPI.Controllers
{
    [Route("api/[controller]")]
    public class AddressesController : Controller
    {
        private readonly IAddressesService _AddressesService;

        public AddressesController(IAddressesService AddressesService)
        {
            _AddressesService = AddressesService;
        }


        [HttpGet]
        public async Task<ActionResult<List<AddressModel>>> GetAllAddresses()
        {
            return await _AddressesService.GetAllAddresses();
        }


        [HttpPost]
        public async Task<ActionResult<List<AddressModel>>> AddAddress([FromBody] AddressCreateDto Address)
        {
            var result = await _AddressesService.AddAddress(Address);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<ActionResult<List<AddressModel>>> RemoveAddress(string id)
        {
            var result = await _AddressesService.DeleteAddress(id);

            if (result is null)
            {
                return NotFound("Address was not located.");
            }
            return Ok(result);
        }


        [HttpPut]
        public async Task<ActionResult<List<AddressModel>>> UpdateAddress(string streetAddress, [FromBody]AddressModel request)
        {
            var result = await _AddressesService.UpdateAddress(streetAddress, request);

            if (result is null)
                return NotFound("Address not located.");

                    return Ok(result);
        }
    }
}

