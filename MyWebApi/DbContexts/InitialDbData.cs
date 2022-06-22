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
            new Employee {Id = 1, Name = "Adam", SurName = "Nowak", DepartmentId = 1, Email = "adam@gmail.com", Password = "Paweł", PhoneNumber = "443563334"},
            new Employee {Id = 2, Name = "Janusz", SurName = "Lewandowski", DepartmentId = 2, Email = "janusz@gmail.com", Password = "Piotr", PhoneNumber = "400566334" },
            new Employee {Id = 3, Name = "Janina", SurName = "Browar", DepartmentId = 3, Email = "janina@gmail.com", Password = "Adam", PhoneNumber = "443111114"},
            new Employee {Id = 4, Name = "Aleksandra", SurName = "Ślązak", DepartmentId = 2, Email = "aleksandra@gmail.com", Password = "Radek", PhoneNumber = "440000334"},
            new Employee {Id = 5, Name = "Paweł", SurName = "Płot", DepartmentId = 2, Email = "pawel@gmail.com", Password = "Łukasz", PhoneNumber = "443500000"},
            new Employee {Id = 6, Name = "Piotr", SurName = "Karolak", DepartmentId = 1, Email = "piotr@gmail.com", Password = "Jacek", PhoneNumber = "443511111"},
            new Employee {Id = 7, Name = "Andrzej", SurName = "Wieglota", DepartmentId = 1, Email = "andrzej@gmail.com", Password = "Piotr", PhoneNumber = "440006334"},
            new Employee {Id = 8, Name = "Łukasz", SurName = "Cygan", DepartmentId = 1, Email = "lukasz@gmail.com", Password = "Łukasz", PhoneNumber = "443555555"},
            new Employee {Id = 9, Name = "Radek", SurName = "Oleksy", DepartmentId = 3, Email = "radek@gmail.com", Password = "Jacek", PhoneNumber = "443501010"},
            new Employee {Id = 10, Name = "Wiesław", SurName = "Kiełbasa", DepartmentId = 1, Email = "wiesław@gmail.com", Password = "Adrian", PhoneNumber = "443020534"},
        };

        private static readonly Person[] persons = new Person[]
        {
            new Person
            {
                Id = 1, Name = "Piotr", SurName = "Wasal", Email = "wasal@gmail.com", Password = "Paweł",
                PhoneNumber = "449999334"
            },
            new Person
            {
                Id = 2, Name = "Andrej", SurName = "Duda", Email = "dudas@gmail.com", Password = "Ivanow",
                PhoneNumber = "400566159",
            },
        };

        public static void InitializeDbData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(departments);
            modelBuilder.Entity<Employee>().HasData(employees);
            modelBuilder.Entity<Person>().HasData(persons);
        }
    }
}
