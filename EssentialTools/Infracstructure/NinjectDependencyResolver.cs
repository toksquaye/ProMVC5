using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Infracstructure
{
    //IDependencyResolver interface is used by the MVC framework to get the objects it needs
    //MVC calls GetService or GetServices when it needs an instance of a class to service an incoming request
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        //Get the binding of a given interface as specified in the class.
        //Return null if no binding found
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        //for interfaces that have multiple bindings
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
        }
    }
}