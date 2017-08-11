using System.ComponentModel.DataAnnotations;

namespace DepartmentsWebApi.Data
{
    public class Department
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
