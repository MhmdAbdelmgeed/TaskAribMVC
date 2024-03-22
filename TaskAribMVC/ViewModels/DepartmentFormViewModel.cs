using System.ComponentModel.DataAnnotations;

namespace TaskAribMVC.ViewModels
{
    public class DepartmentFormViewModel
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "Max length cannot be more than 5 chr.")]
        public string Name { get; set; } = null!;
    }
}
