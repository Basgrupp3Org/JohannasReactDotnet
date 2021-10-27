using JohannasReactProject.Models.Entities;
using JohannasReactProject.Models.Web;
using JohannasReactProject.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JohannasReactProject.Controllers
{
    [Route("api/fixedcostcategory")]
    [ApiController]
    [Authorize]
    public class FixedCostCategoryController : ControllerBase
    {
        private readonly IFixedCostCategoryService _service;

        public FixedCostCategoryController(IFixedCostCategoryService service) => _service = service;
        // GET: api/<FixedCostCategoryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FixedCostCategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FixedCostCategoryController>
        [HttpPost]
        public async Task Post([FromBody] FixedCostsCategories fixedCostCategories)
        {
            await _service.Post(fixedCostCategories);
        }

        // PUT api/<FixedCostCategoryController>/5
        [HttpPut]
        public async Task Put([FromBody] EditFixedCostCategoryDTO editFixedCostCategoryDTO)
        {
            await _service.Edit(editFixedCostCategoryDTO);
        }

        // DELETE api/<FixedCostCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
