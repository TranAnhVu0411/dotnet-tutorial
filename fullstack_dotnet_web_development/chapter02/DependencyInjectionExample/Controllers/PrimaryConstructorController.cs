using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionExample.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// Using primary constructor
// (Allow us to declare the constructor parameters directly in the class declaration, 
// instead of using a seperate constructor method )
// Warning: parameter passed to the class declaration cannot be used as properties/members
namespace DependencyInjectionExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimaryConstructorController(IDemoService demoService) : ControllerBase
    {
        [HttpGet]
        public ActionResult Get(){
            return Content(demoService.SayHello());
        }
    }
}