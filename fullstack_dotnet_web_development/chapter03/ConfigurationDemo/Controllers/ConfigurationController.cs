using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController(IConfiguration configuration) : ControllerBase
    {
        [HttpGet]
        [Route("my-key")]
        public ActionResult GetMyKey()
        {
            var myKey = configuration["MyKey"];
            return Ok(myKey);
        }

        [HttpGet]
        [Route("database-configuration")]
        public ActionResult GetDbConfiguration()
        {
            var type = configuration["Database:Type"];
            var connectionString = configuration["Database:ConnectionString"];
            return Ok(new {Type = type, ConnectionString = connectionString});
        }

        [HttpGet]
        [Route("database-configuration-with-bind")]
        public ActionResult GetDbConfigurationWithBind()
        {
            var databaseOption = new DatabaseOption();
            // // The SectionName is defined in the DatabaseOption class, 
            // // which shows the section name in the appsettings.json
            // // (The 2 commands below are achieving the same result) 
            // configuration.GetSection(DatabaseOption.SectionName);
            configuration.Bind(DatabaseOption.SectionName, databaseOption);
            return Ok(new {databaseOption.Type, databaseOption.ConnectionString});
        }

        [HttpGet]
        [Route("database-configuration-with-generic-type")]
        public ActionResult GetDbConfigurationWithGenericType()
        {
            var databaseOption = configuration.GetSection(DatabaseOption.SectionName).Get<DatabaseOption>();
            return Ok(new {databaseOption.Type, databaseOption.ConnectionString});
        }

        [HttpGet]
        [Route("database-configuration-with-ioptions")]
        public ActionResult GetDbConfigurationWithIOptions([FromServices] IOptions<DatabaseOption> options)
        {
            var databaseOption = options.Value;
            return Ok(new {databaseOption.Type, databaseOption.ConnectionString});
        }

        [HttpGet]
        [Route("database-configuration-with-ioptions-snapshot")]
        public ActionResult GetDbConfigurationWithIOptionsSnapshot([FromServices] IOptionsSnapshot<DatabaseOption> options)
        {
            var databaseOption = options.Value;
            return Ok(new {databaseOption.Type, databaseOption.ConnectionString});
        }

        [HttpGet]
        [Route("database-configuration-with-ioptions-monitor")]
        public ActionResult GetDbConfigurationWithIOptionsMonitor([FromServices] IOptionsMonitor<DatabaseOption> options)
        {
            var databaseOption = options.CurrentValue;
            return Ok(new {databaseOption.Type, databaseOption.ConnectionString});
        }

        [HttpGet]
        [Route("database-configuration-with-named-options")]
        public ActionResult GetDbConfigurationWithNamedOptions([FromServices] IOptionsSnapshot<DatabaseOption> options)
        {
            var systemDatabaseOption = options.Get(DatabaseOption.SystemDatabaseSectionName);
            var businessDatabaseOption = options.Get(DatabaseOption.BusinessDatabaseSectionName);

            return Ok(new {SystemDatabaseOption = systemDatabaseOption, BusinessDatabaseOption = businessDatabaseOption});
        }
    }
}