using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;

namespace Bluevolt.POC.Business.Core
{
    public class UnityServiceResolver1
    {
        #region Declaration
        
        private readonly IUnityContainer _container; 

        #endregion

        #region Constructor
        
        public UnityServiceResolver1(IUnityContainer container)
        {
            _container = container;
        } 

        #endregion

        #region Implementation of IDependencyResolver

        public object GetService(Type serviceType)
        {
            if (_container.IsRegistered(serviceType))
                return _container.Resolve(serviceType);
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (_container.IsRegistered(serviceType))
                return _container.ResolveAll(serviceType);
            return new List<object>();
        }

        #endregion

        #region Methods
        
        public T Resolve<T>(string name)
        {
            return _container.Resolve<T>(name, new ResolverOverride[] { });
        } 

        #endregion
    }
}
