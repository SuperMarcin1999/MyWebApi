using Microsoft.EntityFrameworkCore;
using MyWebApi.Entities;

namespace MyWebApi.DbContexts
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }

        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Departments");
            modelBuilder.Entity<Department>()
                .Property(d => d.Id).IsRequired();
            modelBuilder.Entity<Department>()
                .Property(d => d.Name).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Employee>().ToTable("Employees");
                //.HasIndex(e => new { e.Name, e.SurName, e.Password, e.DepartmentId}).IsUnique();
            modelBuilder.Entity<Employee>()
                .Property(e => e.Id).IsRequired();
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Employee>()
                .Property(e => e.SurName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Password).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>()
                .Property(e => e.PhoneNumber).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>()
                .Property(e => e.DepartmentId).IsRequired();

            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Employee>()
                .Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Employee>()
                .Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Employee>()
                .Property(p => p.SurName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Employee>()
                .Property(p => p.Password).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Employee>()
                .Property(p => p.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>()
                .Property(p => p.PhoneNumber).IsRequired().HasMaxLength(50);

            modelBuilder.InitializeDbData();
            base.OnModelCreating(modelBuilder);
        }
    }
}
