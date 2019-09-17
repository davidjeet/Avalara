using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;

public class UnityResolver : IDependencyResolver
{
    protected IUnityContainer container;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Potential Code Quality Issues", "RECS0163:Suggest the usage of the nameof operator", Justification = "<Pending>")]
    public UnityResolver(IUnityContainer container)
    {
        if (container == null)
        {
            throw new ArgumentNullException("container");
        }
        this.container = container;
    }

    public object GetService(Type serviceType)
    {
        try
        {
            return container.Resolve(serviceType);
        }
        catch (ResolutionFailedException)
        {
            return null;
        }
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
        try
        {
            return container.ResolveAll(serviceType);
        }
        catch (ResolutionFailedException)
        {
            return new List<object>();
        }
    }

    public IDependencyScope BeginScope()
    {
        var child = container.CreateChildContainer();
        return new UnityResolver(child);
    }

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        container.Dispose();
    }
}