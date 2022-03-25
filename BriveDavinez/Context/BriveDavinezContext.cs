using BriveDavinez.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BriveDavinez.Context
{
    public class BriveDavinezContext : DbContext
    {
        public BriveDavinezContext(DbContextOptions<BriveDavinezContext> options) : base(options)
        {
        }

        public DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Filtra registros que tengan un soft delete           
            builder.Entity<Producto>().Property<bool>("Activo");
            builder.Entity<Producto>().HasQueryFilter(m => EF.Property<bool>(m, "Activo") == true);

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
