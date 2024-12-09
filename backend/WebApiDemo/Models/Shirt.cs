using System.ComponentModel.DataAnnotations;
using WebApiDemo.Models.Validations;

namespace WebApiDemo.Models
{
    public class Shirt
    {
        public int ShirtId { get; set; }

        [Required]
        public string? Brand { get; set;}

        [Required]
        [Shirt_EnsureCorrectSizing]
        public string?Color { get; set;}
        
        [Required]
        public int? Size { get; set;}

        [Required]
        public string? Gender { get; set;}

        [Required]
        public double? Price { get; set;}
    }
}
