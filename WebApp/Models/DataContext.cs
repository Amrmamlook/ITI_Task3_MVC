using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data source=DESKTOP-5FHFHJ5\\SQLEXPRESS;Initial Catalog=ManageDB;Integrated Security=true; TrustServerCertificate=True");

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(e =>
            {
                e.Property(e=>e.DeparId).IsRequired(false);
            });
        }
    }
     
}
