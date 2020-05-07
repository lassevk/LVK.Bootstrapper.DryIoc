using DryIoc;

using JetBrains.Annotations;

namespace LVK.Bootstrapper.DryIoc
{
    public interface IContainerFinalizer
    {
        void Finalize([NotNull] IContainer container);
    }
}