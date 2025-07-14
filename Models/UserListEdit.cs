
using System.ComponentModel.DataAnnotations;

namespace Practice2.Models
{
    public class UserListEdit
    {

        public int UserId { get; set; }
        
        [Display(Name ="Name")]
        [Required(ErrorMessage = "Please , Enter your FullName")]
        public string UserName { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please, Enter your Password.")]
        public string UserPassword { get; set; } = null!;


        [Display(Name = "Email-Address")]
        [Required(ErrorMessage = "Please, Enter your Email-Address.")]
        public string EmailAddress { get; set; } = null!;

      
        public string UserProfile { get; set; } = null!;

        public string UserAddress { get; set; } = null!;

        public string UserRole { get; set; } = null!;

        public bool UserStatus { get; set; }

        public string EncId { get; set; } = string.Empty;

       [DataType(DataType.Upload)]
       public IFormFile? UserFile { get; set; }
    }
}
