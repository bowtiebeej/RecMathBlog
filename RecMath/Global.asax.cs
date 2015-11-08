using Ninject;
using Ninject.Web.Common;
using RecMath.Controllers;
using RecMath.Core;
using RecMath.Core.Objects;
using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RecMath
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(new RepositoryModule());
            kernel.Bind<IBlogRepository>().To<BlogRepository>();

            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundle(BundleTable.Bundles);
            base.OnApplicationStarted();
        }
    }
}