using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

namespace MyWebApi.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Collection<Employee> Employees { get; set; }
    }
}
