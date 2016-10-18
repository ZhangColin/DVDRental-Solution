using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using DVDRenatal.Infrastructure.IoC;

namespace DVDRenatal.Infrastructure.Mvc
{
    public class MvcResolver: IResolver {
        public object GetService(Type serviceType) {
            return DependencyResolver.Current.GetService(serviceType);
        }

        public TService GetService<TService>() {
            return DependencyResolver.Current.GetService<TService>();
        }

        public IEnumerable GetServices(Type serviceType) {
            return DependencyResolver.Current.GetServices(serviceType);
        }

        public IEnumerable<TService> GetServices<TService>() {
            return DependencyResolver.Current.GetServices<TService>();
        }
    }
}