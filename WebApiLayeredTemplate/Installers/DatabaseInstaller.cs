using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Installers
{
    public class DatabaseInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            //Configuracion del DbContext:
            services.AddDbContext<AppDbContext>(s =>
            {
                string connection = configuration.GetConnectionString("Path");
                s.UseSqlServer(connection);
            });
        }
    }
}
