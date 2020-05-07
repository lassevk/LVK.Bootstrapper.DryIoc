using DryIoc;

using LVK.Bootstrapper.DryIoc;

namespace ExampleConsoleApplication
{
    static class Program
    {
        static void Main(string[] args)
            => new Container().Bootstrap<ContainerBootstrapper>().Finalize().Resolve<IExampleApplication>().Run(args);
    }
}