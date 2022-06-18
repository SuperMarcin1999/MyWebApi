using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.DbContexts;
using MyWebApi.Entities;
using MyWebApi.Helpers;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly EmployeeDbContext _employeeDbContext;

        //private static List<Person> _persons;

        public PersonController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _employeeDbContext.Employees.ToListAsync();
            return employees;
        }

        [HttpPost]
        public void SaveEmployees(List<Employee> employees)
        {
            _employeeDbContext.AddRange(employees);
            _employeeDbContext.SaveChangesAsync();
        }

        [HttpGet("")]
        public async Task<IEnumerable<AverageSalaryForEachDepartmentDto>> GetAverageSalaryForEachDepartment()
        {
            var items = from d in _employeeDbContext.Departments
                join e in _employeeDbContext.Employees on d.Id equals e.DepartmentId into employeeTmp
                from empl in employeeTmp.DefaultIfEmpty()
                group empl by d.Name into g
                    select
                        new AverageSalaryForEachDepartmentDto(
                        g.Key,
                        g.Average(r => r.Salary));
            
            return await items.ToListAsync();
        }




        //[HttpGet]
        //public List<Department> GetAllDepartments()
        //{
        //    var result = _employeeDbContext.Departments.ToList();
        //    return result;
        //}

        //[HttpPost]
        //public ActionResult SaveDepartments(List<Department> departments)
        //{
        //    try
        //    {
        //        _employeeDbContext.Departments.AddRange(departments);
        //        _employeeDbContext.SaveChanges();
        //        return Ok();
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}


        //[HttpGet(Name = "GetPersons")]
        //public IEnumerable<Person> GetPersons()
        //{
        //    return _persons;
        //}

        ////[HttpGet(Name = "GetPerson/${index}")]
        ////public Person GetPerson(int index)
        ////{
        ////    return _persons[index];
        ////}

        //[HttpPost(Name = "AddPerson")]
        //public ActionResult AddPerson(Person person)
        //{
        //    if (_persons == null)
        //    {
        //        _persons = new List<Person>();
        //    }
        //    Console.WriteLine("Odebrano: " + person.Name + ", " + person.Password);
        //    try
        //    {
        //        _persons.Add(person);
        //        return Ok(new Result(true));
        //    }
        //    catch
        //    {
        //        return BadRequest(new Result(true));
        //    }
        //}
    }
}