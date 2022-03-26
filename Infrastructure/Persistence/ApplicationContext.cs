using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Sucursal> Sucursal { get; set; }

        public DbSet<Stock> Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Filtra registros que tengan un soft delete           
            builder.Entity<Producto>().Property<bool>("Activo");
            builder.Entity<Producto>().HasQueryFilter(m => EF.Property<bool>(m, "Activo") == true);

            builder.Entity<Sucursal>().Property<bool>("Activo");
            builder.Entity<Sucursal>().HasQueryFilter(m => EF.Property<bool>(m, "Activo") == true);

            builder.Entity<Stock>().Property<bool>("Activo");
            builder.Entity<Stock>().HasQueryFilter(m => EF.Property<bool>(m, "Activo") == true)
                .HasKey(a => new { a.SucursalID, a.ProductoID });

            // Si se requiere acceder a registros con soft delete, utilizar IgnoreQueryFilters
        }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        // Intercepta queries de Agregar o Delete para actualizar valor de Activo y con ello permitir un Soft Delete
        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["Activo"] = true;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["Activo"] = false;
                        break;
                }
            }
        }
    }
}
