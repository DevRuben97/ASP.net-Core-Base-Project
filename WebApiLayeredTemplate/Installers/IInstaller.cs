using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace API.Installers
{
   internal  interface IInstaller
    {
        /// <summary>
        /// Registrar los servicios correspondientes necesarios para ejecución del api.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}
