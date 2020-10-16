using API.Extensions;
using Autofac;
using Common;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using Repository;
using Repository.Implementations;
using Repository.Interfaces;
using Services;

namespace WebApiLayeredTemplate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServices(Configuration);
        }
        /// <summary>
        /// Configuracion del contenedor de AutoFact
        /// Este metodo registra todos los servicios que tengan los modules del proyecto, el cual 
        /// estaran disponibles para injectar las dependencias.
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureDiContainer(ContainerBuilder builder)
        {

            builder.RegisterModule<DomainModule>();
            builder.RegisterModule<PersistenceModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServicesModule>();
            builder.RegisterModule<CommonModule>();

            // Registrar el UnitOfWork:
            builder.RegisterType<IUnitOfWork>().As<UnitOfWork>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseCors("All");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
