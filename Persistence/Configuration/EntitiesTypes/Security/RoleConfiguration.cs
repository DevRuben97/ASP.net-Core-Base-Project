using Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configuration.EntitiesTypes.Security
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasMany(e => e.UserRoles)
                .WithOne(e => e.Rol)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
        }
    }
}
