using BriveDavinez.Models;
using Microsoft.EntityFrameworkCore;

namespace BriveDavinez.Context
{
    public class BriveDavinezContext : DbContext
    {
        public BriveDavinezContext(DbContextOptions<BriveDavinezContext> options) : base(options)
        {
        }

        public DbSet<Producto> Producto { get; set; }
    }
}
