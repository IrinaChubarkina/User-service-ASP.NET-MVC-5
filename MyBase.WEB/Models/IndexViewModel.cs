using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBase.WEB.Models
{
    public class IndexViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}