using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionExample.Services.Interfaces;

namespace DependencyInjectionExample.Services
{
    public class SqlDatabaseService : IDataService
    {
        public string GetData()
        {
            return "Data from SQL Database";
        }
    }
}