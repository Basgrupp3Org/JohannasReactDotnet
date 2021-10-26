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
    [Route("api/variablecostcategory")]
    [ApiController]
    [Authorize]
    public class VariableCostCategoryController : ControllerBase
    {
        private readonly IVariableCostCategoryService _service;

        public VariableCostCategoryController(IVariableCostCategoryService service) => _service = service;
        // GET: api/<VariableCostCategoryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VariableCostCategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VariableCostCategoryController>
        [HttpPost]
        public void Post([FromBody] VariableCostsCategories variableCostsCategories)
        {
            _service.Post(variableCostsCategories);
        }

        // PUT api/<VariableCostCategoryController>/5
        [HttpPut]
        public void Put( [FromBody] EditVariableCostCategoryDTO editVariableCostCategoryDTO)
        {
            _service.Edit(editVariableCostCategoryDTO);
        }

        // DELETE api/<VariableCostCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
