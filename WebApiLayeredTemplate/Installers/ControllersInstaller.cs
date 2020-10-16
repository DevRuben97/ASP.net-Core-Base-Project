using API.Filters;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiLayeredTemplate;

namespace API.Installers
{
    public class ControllersInstaller : IInstaller
    {
        /// <summary>
        /// Instalar todos los servicios de la aplicación.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Configuracion de los controladores API::
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }
            )
                .AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                )
                .AddFluentValidation(configuation => configuation.RegisterValidatorsFromAssemblyContaining<Startup>());
        }
    }
}
