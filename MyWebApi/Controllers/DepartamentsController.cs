using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.DbContexts;
using MyWebApi.Dtos;
using MyWebApi.Entities;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentsController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly IMapper _mapper;
        public DepartamentsController(EmployeeDbContext employeeDbContext, IMapper mapper)
        {
            _employeeDbContext = employeeDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DepartmentDto>> GetAll()
        {
            var departments = await _employeeDbContext.Departments
                .Include(d => d.Employees)
                .ToListAsync();
            
            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);

            //return departments.Select(d => new DepartmentDto
            //{
            //    Id = d.Id,
            //    Name = d.Name,
            //    Employees = d.Employees.Select(e => new EmployeeDto
            //    {
            //        Id = e.Id,
            //        Name = e.Name,
            //        Salary = e.Salary,
            //        Surname = e.Surname
            //    })
            //});
        }
    }
}
