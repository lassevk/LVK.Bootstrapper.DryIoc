using DryIoc;

using JetBrains.Annotations;

namespace LVK.Bootstrapper.DryIoc
{
    public interface IContainerBootstrapper
    {
        void Bootstrap([NotNull] IContainer container);
    }
}