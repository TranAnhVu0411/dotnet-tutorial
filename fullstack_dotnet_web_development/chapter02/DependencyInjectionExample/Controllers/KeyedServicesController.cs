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
    public class KeyedServicesController : ControllerBase
    {
        [HttpGet("sql")]
        public ActionResult GetSqlData([FromKeyedServices("sqlDatabaseService")] IDataService dataService) => Content(dataService.GetData());
        [HttpGet("cosmo")]
        public ActionResult GetCosmoData([FromKeyedServices("cosmoDatabaseService")] IDataService dataService) => Content(dataService.GetData());
    }
}