using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionExample.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly IDemoService _demoService;
        public DemoController(IDemoService demoService)
        {
            _demoService = demoService;
        }
        [HttpGet]
        public ActionResult Get(){
            return Content(_demoService.SayHello());
        }
    }
}