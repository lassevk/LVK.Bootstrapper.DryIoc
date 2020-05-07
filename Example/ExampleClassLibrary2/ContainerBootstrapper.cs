using System;

using DryIoc;

using LVK.Bootstrapper.DryIoc;

namespace ExampleClassLibrary2
{
    public class ContainerBootstrapper : IContainerBootstrapper
    {
        public void Bootstrap(IContainer container)
        {
            // Notice that since the Service2 concrete type depends on services from the first class library
            // then we should bootstrap this as well so that we know that all services inside are properly registered.
            // Even though the application also bootstraps this first class library, the bootstrapper method inside
            // will only be called once, on the first bootstrap call for it.
            
            container.Bootstrap<ExampleClassLibrary1.ContainerBootstrapper>();
            
            container.Register<IExampleService2, ExampleService2>();
        }
    }
}