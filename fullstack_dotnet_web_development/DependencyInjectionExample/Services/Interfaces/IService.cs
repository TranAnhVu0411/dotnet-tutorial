using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionExample.Services.Interfaces
{
    public interface IService
    {
        string Name { get; }
        string SayHello();
    }
}