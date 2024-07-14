using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionExample.Services.Interfaces;

namespace DependencyInjectionExample.Services
{
    public class DemoService : IDemoService
    {
        private readonly Guid _serviceId;
        private readonly DateTime _createdAt;
        public DemoService()
        {
            _serviceId = Guid.NewGuid();
            _createdAt = DateTime.Now;
        }
        public string SayHello()
        {
            return $"Hello, My Id is {_serviceId}. I was created at {_createdAt}";
        }
    }
}