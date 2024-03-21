namespace TaskAribMVC.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string? ImageUrl { get; set; }
        public string ManagerName { get; set; }
        public int? DepartmentId { get; set; }

        public string? DepartmentName { get; set; }

    }

}
