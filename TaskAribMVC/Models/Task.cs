namespace TaskAribMVC.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public string Status { get; set; }

        // Navigation Property
        public Employee Employee { get; set; }
    }

}
