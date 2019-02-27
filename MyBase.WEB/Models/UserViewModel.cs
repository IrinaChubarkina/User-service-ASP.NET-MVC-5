using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBase.WEB.Models
{
    public class UserViewModel
    {
        //[HiddenInput(DisplayValue =false)]
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

        //[HiddenInput(DisplayValue = false)]
        public int ContactId { get; set; }

        public int PictureId { get; set; }
        //public string Name { get; set; }
        //[Required]
        public byte[] Image { get; set; }
    }
}