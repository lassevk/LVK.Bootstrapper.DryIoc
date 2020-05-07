# LVK.Bootstrapper.DryIoc

DryIoc module bootstrapper system for easy application modularization

With this simple little system you can easily place internal classes into separate projects,
make the interfaces for them public, and bootstrap all the services into the container.

The bootstrap system allows you to call a bootstrap method once per module to register
your services.

See the example projects in the source for how to use it.
