using Microsoft.EntityFrameworkCore;
using StudentCrudAPI.Entities;

namespace StudentCrudAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //for Studnet Table
            modelBuilder.Entity<Student>().HasKey(s => s.Id);

            modelBuilder.Entity<Student>().HasIndex(s => s.Email).IsUnique();

            //for gender table
            modelBuilder.Entity<Gender>().HasKey(g => g.Id);

            modelBuilder.Entity<Gender>().HasIndex(g => g.GenderName).IsUnique();

            //for department table
            modelBuilder.Entity<Department>().HasKey(a => a.Id);

            modelBuilder.Entity<Department>().HasIndex(a => a.DepartmentName).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}

