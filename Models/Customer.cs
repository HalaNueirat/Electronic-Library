using System.ComponentModel.DataAnnotations;

namespace Electronic_Library1.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Please Enter Your ID")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
