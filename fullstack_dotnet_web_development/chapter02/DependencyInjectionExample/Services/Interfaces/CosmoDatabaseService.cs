using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionExample.Services.Interfaces
{
    public class CosmoDatabaseService : IDataService
    {
        public string GetData()
        {
            return "Data from Cosmo Database";
        }
    }
}