using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Installers
{
    public class CorsInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {

            //Configuracion de los Cors:

            services.AddCors(options =>
            {
                options.AddPolicy("All", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
        }
    }
}
