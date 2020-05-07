using System;

namespace ExampleClassLibrary1
{
    internal class ExampleService1 : IExampleService1
    {
        public void Run()
        {
            Console.WriteLine("Example Service 1 running (twice, once from application, once from service 2)");
        }
    }
}