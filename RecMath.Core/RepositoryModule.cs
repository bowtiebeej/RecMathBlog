using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using RecMath.Core.Objects;
using RecMath.Core.Mappings;
using NHibernate;
using NHibernate.Cache;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using NHibernate.Tool.hbm2ddl;

namespace RecMath.Core
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            /*Stack Overflow suggestion to find null lambda
            Bind<ISessionFactory>().ToMethod( e =>
                {
                    var x1 = Fluently.Configure();
                    var x2 = x1.Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("RecMathDbConnString")));
                    var x3 = x2.Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>());
                    var x4 = x3.Mappings(m => m.FluentMappings.AddFromAssemblyOf<PostMap>());
                    var x5 = x4;//.ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false));
                    var x6 = x5.BuildConfiguration();
                    x6.BuildSessionFactory();
                })
                .InSingletonScope();*/

            Bind<ISessionFactory>()
              .ToMethod(e => Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("RecMathDbConnString")))
              .Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>())
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Post>())
                  //.ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false))
              .BuildConfiguration()
              .BuildSessionFactory())
              .InSingletonScope();

            Bind<ISession>()
                .ToMethod((ctx) => ctx.Kernel.Get<ISessionFactory>().OpenSession())
                .InRequestScope();
        }
    }
}
