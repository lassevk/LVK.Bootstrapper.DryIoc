using System;
using System.Collections.Generic;

using JetBrains.Annotations;

namespace LVK.Bootstrapper.DryIoc
{
    [UsedImplicitly]
    internal class BootstrapperRegistry : IBootstrapperRegistry
    {
        private readonly HashSet<Type> _AlreadyBootstrappedTypes = new HashSet<Type>();
        public bool AddBootstrapper(Type bootstrapperType) => _AlreadyBootstrappedTypes.Add(bootstrapperType);

        public bool IsContainerFinalized { get; set; }
    }
}