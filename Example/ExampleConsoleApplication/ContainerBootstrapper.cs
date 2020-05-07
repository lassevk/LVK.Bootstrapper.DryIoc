using System;

using DryIoc;

using LVK.Bootstrapper.DryIoc;

namespace ExampleConsoleApplication
{
    internal class ContainerBootstrapper : IContainerBootstrapper
    {
        public void Bootstrap(IContainer container)
        {
            container.Bootstrap<ExampleClassLibrary1.ContainerBootstrapper>();
            container.Bootstrap<ExampleClassLibrary2.ContainerBootstrapper>();

            container.Register<IExampleApplication, ExampleApplication>();
        }
    }
}