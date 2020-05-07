using System;

using ExampleClassLibrary1;

using JetBrains.Annotations;

namespace ExampleClassLibrary2
{
    internal class ExampleService2 : IExampleService2
    {
        private readonly IExampleService1 _Service1;

        public ExampleService2([NotNull] IExampleService1 service1)
        {
            _Service1 = service1 ?? throw new ArgumentNullException(nameof(service1));
        }
        public void Run()
        {
            Console.WriteLine("Example Service 2 running");
            _Service1.Run();
        }
    }
}