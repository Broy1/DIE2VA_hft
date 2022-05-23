using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WitcherApp.Logic.Interfaces;
using WitcherApp.Model;

namespace WitcherApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        ISchoolLogic logic;
        public SchoolController(ISchoolLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<School> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public School Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] School value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] School value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
