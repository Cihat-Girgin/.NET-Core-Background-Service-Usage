using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SendMailBackgroundService.Models
{
    public class UserMail
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        [DisplayName("Email Address")]
        public string Email { get; set; }
    }
}