using System.ComponentModel.DataAnnotations;

namespace EFCoreDemo.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string  Email { get; set; }
    }
}