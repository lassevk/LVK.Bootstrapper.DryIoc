using System;

using DryIoc;

using NSubstitute;

using NUnit.Framework;

// ReSharper disable AssignNullToNotNullAttribute

namespace LVK.Bootstrapper.DryIoc.Tests
{
    [TestFixture]
    public class ContainerExtensionsTests
    {
        [SetUp]
        public void SetUp()
        {
            Bootstrapper.CallCounter = 0;
        }

        [Test]
        public void Bootstrap_NullContainer_ThrowsArgumentNullException()
        {
            IContainer container = null;
            Assert.Throws<ArgumentNullException>(() => container.Bootstrap<Bootstrapper>());
        }

        [Test]
        public void Finalize_NullContainer_ThrowsArgumentNullException()
        {
            IContainer container = null;
            Assert.Throws<ArgumentNullException>(() => container.Finalize());
        }

        [Test]
        public void Bootstrap_CalledOnce_CallsBootstrapperMethodOnce()
        {
            var container = new Container();

            container.Bootstrap<Bootstrapper>();

            Assert.That(Bootstrapper.CallCounter, Is.EqualTo(1));
        }

        [Test]
        public void Bootstrap_CalledTwice_CallsBootstrapperMethodOnce()
        {
            var container = new Container();

            container.Bootstrap<Bootstrapper>();
            container.Bootstrap<Bootstrapper>();

            Assert.That(Bootstrapper.CallCounter, Is.EqualTo(1));
        }

        [Test]
        public void Finalize_CalledOnce_CallsAllContainerFinalizersOnce()
        {
            var container = new Container();
            IContainerFinalizer finalizer = Substitute.For<IContainerFinalizer>();

            container.RegisterInstance(finalizer);
            container.Finalize();

            finalizer.Received(1).Finalize(container);
        }

        [Test]
        public void Finalize_CalledTwice_CallsAllContainerFinalizersOnce()
        {
            var container = new Container();
            IContainerFinalizer finalizer = Substitute.For<IContainerFinalizer>();

            container.RegisterInstance(finalizer);
            container.Finalize();
            container.Finalize();

            finalizer.Received(1).Finalize(container);
        }
    }

    public class Bootstrapper : IContainerBootstrapper
    {
        public static int CallCounter { get; set; }

        public void Bootstrap(IContainer container)
        {
            CallCounter++;
        }
    }
}