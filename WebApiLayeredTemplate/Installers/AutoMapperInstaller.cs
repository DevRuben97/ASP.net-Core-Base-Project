using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Installers
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {

            //Configuracion del AutoMapper:

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
