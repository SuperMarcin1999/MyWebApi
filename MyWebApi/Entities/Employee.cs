using System.Collections.ObjectModel;

namespace MyWebApi.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
