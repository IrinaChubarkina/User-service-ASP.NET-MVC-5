using MyBase.BLL.DTO;
using System;
using System.Collections.Generic;

namespace MyBase.WEB.Controllers.Api.Models
{
    public class Page
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((double)TotalItems / PageSize); }
        }
        public IEnumerable<UserDTO> Users { get; set; }
    }
}