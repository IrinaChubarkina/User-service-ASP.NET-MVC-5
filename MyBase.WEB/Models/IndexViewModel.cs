using System.Collections.Generic;

namespace MyBase.WEB.Models
{
    public class IndexViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}