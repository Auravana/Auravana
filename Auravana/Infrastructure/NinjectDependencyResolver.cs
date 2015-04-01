using Auravana.Domain.Abstract;
using Auravana.Domain.Concrete;
using Auravana.Infrastructure.Abstract;
using Auravana.Infrastructure.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auravana.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            if (kernel == null)
                throw new ArgumentNullException("kernel");

            _kernel = kernel;

            AddBindings();
        }

        private void AddBindings()
        {
            _kernel.Bind<IPersonRepository>().To<EfPersonRepository>();
            _kernel.Bind<IIssueProcessor>().To<IssueProcessor>();
            _kernel.Bind<IIssueRepository>().To<EfIssueRepository>();
            _kernel.Bind<IAuthProvider>().To<HardCodedAuthProvider>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}