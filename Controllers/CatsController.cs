using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using CatsAPI.DTOs;
using CatsAPI.Services.CatsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatsAPI.Controllers
{
    [Route("api/[controller]")]
    public class CatsController : Controller
    {

        private readonly ICatsService _CatsService;

        public CatsController(ICatsService CatsService)
        {
            _CatsService = CatsService;
        }


        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<CatModel>>> GetAllCats()
        {
            return await _CatsService.GetAllCats();
        }


        // GET: api/Cats/id
        [HttpGet("{id}")]
        public async Task<ActionResult<CatModel>> GetCat(int id)
        {
            var result = await _CatsService.GetCat(id);
            if (result is null)
                return NotFound("Cat was not found");

            return Ok(result);
        }


         
        [HttpPost]
        public async Task<ActionResult<List<CatModel>>> AddCat([FromBody]CatCreateDto cat)
        {
            var result = await _CatsService.AddCat(cat);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<CatModel>>> UpdateCat(int id, [FromBody]CatModel request)
        {
            var result = await _CatsService.UpdateCat(id, request);
            if (result is null)
                return NotFound("Cat was not found");

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CatModel>>> DeleteCat(int id)
        {
            var result = await _CatsService.DeleteCat(id);
            if (result is null)
                return NotFound("Cat was not found");
            return Ok(result);
        }


    }
}

