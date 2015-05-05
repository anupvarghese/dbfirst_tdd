﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SimpleIoCApp
{
    public class ServiceModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            //builder.RegisterAssemblyTypes(Assembly.Load("SimpleIoCApp.Service"))
            //          .Where(t => t.Name.EndsWith("Service"))
            //          .AsImplementedInterfaces()
            //          .InstancePerLifetimeScope();
            builder.RegisterType<SimpleIoCApp.UserService>().As<SimpleIoCApp.IUserService>().InstancePerLifetimeScope();
        }
    }
}