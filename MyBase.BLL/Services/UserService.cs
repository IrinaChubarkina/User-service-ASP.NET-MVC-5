using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.BLL.Mappers;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork unitOfWork;
        IMapper<UserDTO, User> userMapper;
        IMapper<UserDTO, Contact> contactMapper;

        public UserService(IUnitOfWork uow, IMapper<UserDTO, User> um, IMapper<UserDTO, Contact> cm)
        {
            unitOfWork = uow;
            userMapper = um;
            contactMapper = cm;
        }

        public IEnumerable<UserDTO> GetList()
        {
            List<UserDTO> usersDto = new List<UserDTO>();
            var users = unitOfWork.Users.GetList();
            foreach (var u in users)
            {
                usersDto.Add(userMapper.ConvertToUpLayer(u));
            }
            return usersDto;
        }

        public void Add(UserDTO userDto)
        {
            var user = userMapper.ConvertToDownLayer(userDto);
            var contact = contactMapper.ConvertToDownLayer(userDto);
            unitOfWork.Users.Add(user);
            unitOfWork.Contacts.Add(contact);
            unitOfWork.Save();
        }

        public UserDTO Get(int id)
        {
            return userMapper.ConvertToUpLayer(unitOfWork.Users.Get(id));
        }

        public void Edit(UserDTO userDto)
        {
            var user = userMapper.ConvertToDownLayer(userDto);
            var contact = contactMapper.ConvertToDownLayer(userDto);
            unitOfWork.Users.Add(user);
            unitOfWork.Contacts.Add(contact);
            unitOfWork.Save();
        }

        public void Delete(int id)
        {
            unitOfWork.Users.Delete(id);
            unitOfWork.Contacts.Delete(id);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
