using System.Collections.ObjectModel;
using MyWebApi.Entities;

namespace MyWebApi.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}
