using System;

using DryIoc;

using LVK.Bootstrapper.DryIoc;

namespace ExampleClassLibrary1
{
    public class ContainerBootstrapper : IContainerBootstrapper
    {
        public void Bootstrap(IContainer container)
        {
            container.Register<IExampleService1, ExampleService1>();
        }
    }
}