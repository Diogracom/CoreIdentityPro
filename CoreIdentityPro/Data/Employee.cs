using System.ComponentModel.DataAnnotations;

namespace CoreIdentityPro.Data
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
    }
}
