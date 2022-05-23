using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WitcherApp.Logic.Classes;
using WitcherApp.Model;

namespace WitcherApp.Endpoint.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        IHumanLogic logic;
        public HumanController(IHumanLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Human> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Human Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Human value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Human value)
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
