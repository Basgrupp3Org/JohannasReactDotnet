using JohannasReactProject.Models;
using JohannasReactProject.Models.Entities;
using JohannasReactProject.Models.Web;
using JohannasReactProject.Repositories.Abstract;
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
    [Route("api/budget")]
    [ApiController]
    [Authorize]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _service;

        public BudgetController(IBudgetService service) => _service = service;
        // GET: api/<BudgetController>
        [HttpGet]
        public IEnumerable<BudgetDTO> Get(ApplicationUser user)
        {
            return _service.Get(user);
        }

        // GET api/<BudgetController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BudgetController>
        [HttpPost]
        public async Task Post([FromBody] Budget budget)
        {
            await _service.Post(budget);
        }

        // PUT api/<BudgetController>/5
        [HttpPut]
        public async Task Put([FromBody] EditBudgetDTO  editBudget)
        {
            await _service.Edit(editBudget);
        }

        // DELETE api/<BudgetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
