namespace TaskAribMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<Employee> Employees { get; set; }
    }

}
