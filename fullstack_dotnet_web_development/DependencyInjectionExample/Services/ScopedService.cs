using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionExample.Services.Interfaces;

namespace DependencyInjectionExample.Services
{
    public class ScopedService : IScopedService
    {
        private readonly Guid _serviceId;
        private readonly DateTime _createdAt;
        private readonly ITransientService _transientService;
        private readonly ISingletonService _singletonService;
        public ScopedService(ITransientService transientService, ISingletonService singletonService)
        {
            _transientService = transientService;
            _singletonService = singletonService;
            _serviceId = Guid.NewGuid();
            _createdAt = DateTime.Now;
        }
        public string Name => nameof(ScopedService);
        public string SayHello()
        {
            var transientServiceMessage = $"{_transientService.SayHello()} I am from {Name}.";
            var singletonServiceMessage = $"{_singletonService.SayHello()} I am from {Name}.";
            var scopedServiceMessage = $"Hello! I am {Name}. My Id is {_serviceId}. I was created at {_createdAt:yyyy-MM-dd HH:mm:ss}";
            return $"{scopedServiceMessage}{Environment.NewLine}{transientServiceMessage}{Environment.NewLine}{singletonServiceMessage}";

        }
    }
}