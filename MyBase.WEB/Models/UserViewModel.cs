using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MyBase.WEB.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public byte[] Image { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}