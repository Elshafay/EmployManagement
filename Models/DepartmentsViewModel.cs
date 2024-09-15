using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    public class DepartmentsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Plase Inter Your Code")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Plase Inter Your Name")]
        public string Name { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.Now;
    }
}
