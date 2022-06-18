using Microsoft.EntityFrameworkCore;
using MyWebApi.Entities;

namespace MyWebApi.DbContexts
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Department>()
                .Property(d => d.Id).IsRequired();
            modelBuilder.Entity<Department>()
                .Property(d => d.Name).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Employee>().ToTable("Employees")
                .HasIndex(e => new { e.Name, e.Surname, e.DepartmentId}).IsUnique();
            modelBuilder.Entity<Employee>()
                .Property(e => e.Id).IsRequired();
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Surname).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary);
            modelBuilder.Entity<Employee>()
                .Property(e => e.DepartmentId).IsRequired();

            modelBuilder.InitializeDbData();
            base.OnModelCreating(modelBuilder);
        }
    }
}
