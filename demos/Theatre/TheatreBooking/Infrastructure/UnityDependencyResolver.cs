using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using SignalR;

namespace TheatreBooking.Infrastructure
{
public class UnityDependencyResolver : DefaultDependencyResolver
{
    private readonly IUnityContainer _container;

    public UnityDependencyResolver(IUnityContainer container)
    {
        _container = container;
    }

        
    public override object GetService(Type serviceType)
    {
        if (_container.IsRegistered(serviceType))
        {
            return _container.Resolve(serviceType);
        }
        return base.GetService(serviceType);
    }

    public override IEnumerable<object> GetServices(Type serviceType)
    {
        if (_container.IsRegistered(serviceType))
        {
            return _container.ResolveAll(serviceType);
        }
        return base.GetServices(serviceType);
    }        
}
}