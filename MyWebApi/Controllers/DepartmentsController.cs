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
    public class DepartmentsController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly IMapper _mapper;
        public DepartmentsController(EmployeeDbContext employeeDbContext, IMapper mapper)
        {
            _employeeDbContext = employeeDbContext;
            _mapper = mapper;
        }

        [HttpGet("GetDepartmentsWithEmployee")]
        public async Task<IEnumerable<DepartmentDto>> GetAll()
        {
            var departments = await _employeeDbContext.Departments
                .Include(d => d.Employees)
                .ToListAsync();

            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }
    }
}
