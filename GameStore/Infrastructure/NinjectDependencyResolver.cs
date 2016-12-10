using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Moq;
using GameStore.Abstract;
using GameStore.Models;
using System.Web.Mvc;
using GameStore.Infrastructure;

namespace GameStore.Infrastructure
{   /// <summary>
    /// Klasa implementuje intefejs IDependencyResolver, który pomaga powiązać deklarację metod w interfejsie z jego implementacją i usunąć powiązanie pomiędzy nim
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernal;

        public NinjectDependencyResolver(IKernel kernalParam)
        {
            kernal = kernalParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernal.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernal.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernal.Bind<IGameRepository>().To<GameRepository>();
            kernal.Bind<IShippingRepository>().To<ShippingInformationRepository>();
            kernal.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}