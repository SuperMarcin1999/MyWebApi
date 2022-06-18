using Microsoft.EntityFrameworkCore;
using MyWebApi.Entities;

namespace MyWebApi.DbContexts
{
    public static class InitialDbData
    {
        private static readonly Department[] departments = new Department[]
        {
            new Department {Id = 1, Name = "IT"},
            new Department {Id = 2, Name = "Handel"},
            new Department {Id = 3, Name = "Logistyka"}
        };

        private static readonly Employee[] employees = new Employee[]
        {
            new Employee {Id = 1, Name = "Adam", Surname = "Nowak", DepartmentId = 1, Salary = 5100},
            new Employee {Id = 2, Name = "Janusz", Surname = "Lewandowski", DepartmentId = 2, Salary = 2500},
            new Employee {Id = 3, Name = "Janina", Surname = "Browar", DepartmentId = 3, Salary = 3300},
            new Employee {Id = 4, Name = "Aleksandra", Surname = "Ślązak", DepartmentId = 2, Salary = 5200},
            new Employee {Id = 5, Name = "Paweł", Surname = "Płot", DepartmentId = 2, Salary = 5100},
            new Employee {Id = 6, Name = "Piotr", Surname = "Karolak", DepartmentId = 1, Salary = 10200},
            new Employee {Id = 7, Name = "Andrzej", Surname = "Wieglota", DepartmentId = 1, Salary = 5000},
            new Employee {Id = 8, Name = "Łukasz", Surname = "Cygan", DepartmentId = 1, Salary = 8500},
            new Employee {Id = 9, Name = "Radek", Surname = "Oleksy", DepartmentId = 3, Salary = 2100},
            new Employee {Id = 10, Name = "Wiesław", Surname = "Kiełbasa", DepartmentId = 1, Salary = 11000},
        };

        public static void InitializeDbData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(departments);
            modelBuilder.Entity<Employee>().HasData(employees);
        }
    }
}
