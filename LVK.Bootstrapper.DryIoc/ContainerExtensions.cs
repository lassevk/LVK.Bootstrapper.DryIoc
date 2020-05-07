using System;
using System.Collections.Generic;

using DryIoc;

using JetBrains.Annotations;

namespace LVK.Bootstrapper.DryIoc
{
    public static class ContainerExtensions
    {
        public static IContainer Bootstrap<T>([NotNull] this IContainer container)
            where T: IContainerBootstrapper
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            IBootstrapperRegistry registry = GetRegistry(container);

            if (registry.AddBootstrapper(typeof(T)))
                container.New<T>().Bootstrap(container);

            return container;
        }

        [NotNull]
        private static IBootstrapperRegistry GetRegistry([NotNull] IContainer container)
        {
            IBootstrapperRegistry registry = container.Resolve<IBootstrapperRegistry>(IfUnresolved.ReturnDefault);
            if (registry is null)
            {
                registry = container.New<BootstrapperRegistry>();
                container.RegisterInstance(registry);
            }

            return registry;
        }

        [NotNull]
        public static IContainer Finalize([NotNull] this IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            IBootstrapperRegistry registry = GetRegistry(container);
            if (registry.IsContainerFinalized)
                return container;

            registry.IsContainerFinalized = true;

            foreach (IContainerFinalizer finalizer in container.Resolve<IEnumerable<IContainerFinalizer>>())
                finalizer.Finalize(container);

            return container;
        }
    }
}