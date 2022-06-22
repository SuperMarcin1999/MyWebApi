using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
