using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WitcherApp.Endpoint.Services;
using WitcherApp.Logic.Interfaces;
using WitcherApp.Model;

namespace WitcherApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        IMonsterLogic logic;
        IHubContext<SignalRHub> hub;

        public MonsterController(IMonsterLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Monster> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Monster Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Monster value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("MonsterCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Monster value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("MonsterUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var monsterToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("MonsterDeleted", monsterToDelete);
        }
    }
}
