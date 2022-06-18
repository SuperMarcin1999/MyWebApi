namespace MyWebApi
{
    public class Person
    {
        public String Name  { get; set; }
        public String Password { get; set; }

        public Person() { }
        public Person(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}