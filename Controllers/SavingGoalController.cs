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
    [Route("api/savinggoal")]
    [ApiController]
    [Authorize]
    public class SavingGoalController : ControllerBase
    {
        private readonly ISavingGoalService _service;

        public SavingGoalController(ISavingGoalService service) => _service = service;
        // GET: api/<SavingGoalController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SavingGoalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SavingGoalController>
        [HttpPost]
        public void Post([FromBody] SavingGoal savingGoal)
        {
            _service.Post(savingGoal);
        }

        // PUT api/<SavingGoalController>/5
        [HttpPut]
        public void Put([FromBody] EditSavingGoalDTO editSavingGoalDTO)
        {
            _service.Edit(editSavingGoalDTO);
        }

        // DELETE api/<SavingGoalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
