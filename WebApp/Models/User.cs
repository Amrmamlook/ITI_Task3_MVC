using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3,ErrorMessage ="Invaild Name")]
        public string Name { get; set; }

        [ForeignKey("Department")]
         public int? DeparId { get; set; }
        
        public byte[]? Image { get; set; }
        [Range(10,90,ErrorMessage ="Age Must be Between 10:90")]
        [Required]
        public int Age { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        [NotMapped]
        public string CPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = " Invalid Email Format")]
        public string Email { get; set; }
        public virtual Department? Department { get; set; }

    }
}
