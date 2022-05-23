using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WitcherApp.Logic.Interfaces;

namespace WitcherApp.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IWitcherLogic logic;

        public StatController(IWitcherLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("{school}")]
        public double? AverageBountyPerSchool(string school)
        {
            return this.logic.GetAvarageBountyPerSchool(school);
        }
    }
}
