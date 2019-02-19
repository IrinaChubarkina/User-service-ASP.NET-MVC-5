using MyBase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // нужен ли класс ContactDTO/ могу ли тут ссылаться на DAL? вроде могу
        public int ContactId { get; set; }
        //public Contact Contact { get; set; } //без этого можно обойтись?
    }
}
