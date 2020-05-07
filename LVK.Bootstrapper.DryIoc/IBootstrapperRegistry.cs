using System;

using JetBrains.Annotations;

namespace LVK.Bootstrapper.DryIoc
{
    internal interface IBootstrapperRegistry
    {
        bool AddBootstrapper([NotNull] Type bootstrapperType);

        bool IsContainerFinalized { get; set; }
    }
}