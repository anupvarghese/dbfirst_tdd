using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SimpleIoCApp
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("SimpleIoCApp.Repository"))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
            builder.RegisterType<SimpleIoCApp.Repositories.UserRepository>().As<SimpleIoCApp.Repositories.IUserRepository>().InstancePerLifetimeScope();

        }
    }
}