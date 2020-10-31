using Domain.Common;
using Domain.Entities.Security;
using Domain.Entities.System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration.EntitiesTypes.Security;
using System;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public  class AppDbContext: IdentityDbContext<
        User,
        Role, int,
        IdentityUserClaim<int>,
        UserRoles,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>, 
        IdentityUserToken<int>>
    {


        public DbSet<SystemModule> SystemModules { get; set; }

        public DbSet<SystemPage> SystemPages { get; set; }

        public DbSet<SystemPageAction> PageActions { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }

        public DbSet<PermisionPage> RolePermisionPages { get; set; }

        public DbSet<PermissonPageAction> RolePermissionPageActions { get; set; }


        public DbSet<SystemEntityStatus> SystemEntityStatuses { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Cargar toda la configuración
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;
                if (entry.State == EntityState.Deleted && entity is ISoftDelete)
                {
                    entry.State = EntityState.Modified;

                    entity.GetType().GetProperty(typeof(ISoftDelete).GetProperties()[0].Name).SetValue(entity, true);
                }
            }


            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
