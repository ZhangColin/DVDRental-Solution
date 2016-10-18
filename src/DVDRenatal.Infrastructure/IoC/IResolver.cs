using System;
using System.Collections;
using System.Collections.Generic;

namespace DVDRenatal.Infrastructure.IoC
{
    public interface IResolver {
        object GetService(Type serviceType);
        TService GetService<TService>();

        IEnumerable GetServices(Type serviceType);
        IEnumerable<TService> GetServices<TService>();
    }
}