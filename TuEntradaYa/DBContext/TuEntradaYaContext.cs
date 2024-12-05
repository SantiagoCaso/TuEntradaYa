using Microsoft.EntityFrameworkCore;
using TuEntradaYa.Models.Entities;

namespace TuEntradaYa.DBContext
{
    public class TuEntradaYaContext : DbContext
    {
        public TuEntradaYaContext(DbContextOptions<TuEntradaYaContext> options) : base(options) { }


        public DbSet<Users> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }  
        public DbSet<Tickets> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }



    }
}
