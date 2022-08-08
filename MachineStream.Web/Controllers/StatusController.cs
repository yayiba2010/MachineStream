using MachineStream.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineStream.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private IMachineStatusService _machineStatusService;
        public StatusController(IMachineStatusService machineStatusService)
        {
            _machineStatusService = machineStatusService;
        }
        [HttpGet]
        public JsonResult List()
        {
           var list = _machineStatusService.GetMachineStatusList();
            return new JsonResult(list);
        }
    }
}
