using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.DbContexts;
using MyWebApi.Dtos;
using MyWebApi.Entities;
using MyWebApi.Helpers;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly IMapper _mapper;

        public PersonController(EmployeeDbContext employeeDbContext, IMapper _mapper)
        {
            _employeeDbContext = employeeDbContext;
            this._mapper = _mapper;
        }

        [HttpPost("SaveEmployee")]
        public ActionResult SaveEmployee(EmployeeDto employeeDto)
        {
            Department? department = _employeeDbContext.Find<Department>(employeeDto.DepartmentId);
            
            if (department == null)
            {
                return NotFound(new Result(isValid: true));
            }
            try
            {
                Employee employee = _mapper.Map<Employee>(employeeDto);
                _employeeDbContext.Employees.Add(employee);
                _employeeDbContext.SaveChanges();
                return Ok(new Result(isValid: true));
            }
            catch
            {
                return BadRequest(new Result(isValid: true));
            }
        }

        [HttpPost("SavePerson")]
        public ActionResult SavePerson(Person person)
        {
            try
            {
                _employeeDbContext.Persons.Add(person);
                _employeeDbContext.SaveChanges();
                return Ok(new Result(isValid: true));
            }
            catch
            {
                return BadRequest(new Result(isValid: true));
            }
        }

        [HttpGet("GetPersons")]
        public IEnumerable<Person> GetPersons()
        {
            return _employeeDbContext.Persons;
        }

        [HttpPost("LoginPerson")]
        public ActionResult TryToLogPerson(PersonLoginDto person)
        {
            var personFound = _employeeDbContext.Persons.FirstOrDefault(x => x.Name.Equals(person.Name) && x.Password.Equals(person.Password));

            if (personFound == null)
            {
                return NotFound("Bad login or password");
            }
            else return Ok("Successful logged");
        }
        
        [HttpPost("LoginEmployee")]
        public ActionResult TryToLogEmployee(PersonLoginDto employee)
        {
            var personFound = _employeeDbContext.Employees.FirstOrDefault(x => x.Name.Equals(employee.Name) && x.Password.Equals(employee.Password));

            if (personFound == null)
            {
                return NotFound("Bad login or password");
            }
            else return Ok("Successful logged");
        }
    }
}