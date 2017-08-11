using System.ComponentModel.DataAnnotations;

namespace UsersWebAPI.Data
{
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
