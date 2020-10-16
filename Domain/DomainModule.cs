using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Module = Autofac.Module;

namespace Domain
{
   public class DomainModule: Module
    {
        /// <summary>
        /// Registrar todos los servicios de este modulo.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var current = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(current)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
