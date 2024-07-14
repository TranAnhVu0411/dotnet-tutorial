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
    public class LifetimeController :  ControllerBase
    {
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        // private readonly ITransientService _transientService;
        private readonly ISingletonService _singletonService;
        
        // // With transient service in constructor
        // public LifetimeController(IScopedService scopedService1, IScopedService scopedService2, ITransientService transientService, ISingletonService singletonService)
        // {
        //     _scopedService1 = scopedService1;
        //     _scopedService2 = scopedService2;
        //     _transientService = transientService;
        //     _singletonService = singletonService;
        // }
        
        // [HttpGet]
        // public ActionResult Get()
        // {
        //     // scoped service messages is the same in same request
        //     // transient service messages is different in same request
        //     // singleton service messages is the same in same/different request
        //     var scopedServiceMessage1 = _scopedService1.SayHello();
        //     var scopedServiceMessage2 = _scopedService2.SayHello();
        //     var transientServiceMessage = _transientService.SayHello();
        //     var singletonServiceMessage = _singletonService.SayHello();
        //     return Content(
        //         $"{scopedServiceMessage1}{Environment.NewLine}{scopedServiceMessage2}{Environment.NewLine}{transientServiceMessage}{Environment.NewLine}{singletonServiceMessage}"
        //     );
        // }

        // Without transient service in constructor
        public LifetimeController(IScopedService scopedService1, IScopedService scopedService2, ISingletonService singletonService)
        {
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService = singletonService;
        }

        [HttpGet]
        public ActionResult Get([FromServices] ITransientService transientService)
        {
            var scopedServiceMessage1 = _scopedService1.SayHello();
            var scopedServiceMessage2 = _scopedService2.SayHello();
            var transientServiceMessage = transientService.SayHello();
            var singletonServiceMessage = _singletonService.SayHello();
            return Content(
                $"{scopedServiceMessage1}{Environment.NewLine}{scopedServiceMessage2}{Environment.NewLine}{transientServiceMessage}{Environment.NewLine}{singletonServiceMessage}"
            );
        }
    }
}