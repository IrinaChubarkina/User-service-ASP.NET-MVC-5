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
       // [HiddenInput(DisplayValue =false)]
        public int Id { get; set; }

       // [Display(Name = "Имя")]
        public string FirstName { get; set; }

       // [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        //[HiddenInput(DisplayValue = false)]
        public int ContactId { get; set; }
    }
}