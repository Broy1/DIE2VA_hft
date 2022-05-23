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
    public class WitcherController : ControllerBase
    {

        IWitcherLogic logic;

        public WitcherController(IWitcherLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Witcher> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Witcher Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Witcher value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Witcher value)
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
