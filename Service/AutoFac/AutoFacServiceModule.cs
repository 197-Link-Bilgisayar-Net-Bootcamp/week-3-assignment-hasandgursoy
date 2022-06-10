using Module = Autofac.Module;
using Core.Services;
using Core.UnitOfWorks;
using Repository;
using Repository.Repositories;
using Service.Mapping;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Core.Repositories;
using Repository.UnitOfWorks;

namespace Service.AutoFac
{
    public class AutoFacServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWorks>().As<IUnitOfWorks>();


            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, serviceAssembly, repoAssembly).Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            // InstancePerLifeTimeScope => .Net de Scope'a denk geliyor. 
            // InstancePerDependency => Transient'e denk geliyor.

            builder.RegisterAssemblyTypes(apiAssembly, serviceAssembly, repoAssembly).Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();





            base.Load(builder);
        }

    }
}
