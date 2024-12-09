using System.ComponentModel.DataAnnotations;


namespace WebApiDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]

       
        public string FirstName { get; set; }

        [Required]
        public string ?LastName { get; set; }

        [Required]
        public string? Role { get; set; }
        public string? DateOfJoining { get; set; } // Date as string (or you can use DateTime)
        public string? Manager { get; set; }
    }
}
