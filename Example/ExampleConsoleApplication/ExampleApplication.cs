using System;

using ExampleClassLibrary1;

using ExampleClassLibrary2;

using JetBrains.Annotations;

namespace ExampleConsoleApplication
{
    internal class ExampleApplication : IExampleApplication
    {
        private readonly IExampleService1 _Service1;
        private readonly IExampleService2 _Service2;

        public ExampleApplication([NotNull] IExampleService1 service1, [NotNull] IExampleService2 service2)
        {
            _Service1 = service1 ?? throw new ArgumentNullException(nameof(service1));
            _Service2 = service2 ?? throw new ArgumentNullException(nameof(service2));
        }
        public void Run(string[] args)
        {
            Console.WriteLine($"Example application running with args: {String.Join(", ", args)}");
            
            // Notice that only the bootstrapper type and the interface is publicly available from each class library
            // The concrete implementations of the services are internal to the respective projects

            _Service1.Run();
            _Service2.Run();
        }
    }
}