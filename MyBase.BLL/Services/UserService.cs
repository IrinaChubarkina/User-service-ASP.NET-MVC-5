using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace MyBase.BLL.Services
{
    public class UserService : IUserService
    {       
        IUnitOfWork unitOfWork;
        IUserRepository<User> userRepository;
        IRepository<Contact> contactRepository;
        IRepository<Picture> pictureRepository;
        IMapper<UserDTO, User> userMapper;
        IMapper<UserDTO, Contact> contactMapper;
        IMapper<UserDTO, Picture> pictureMapper;
        IUserValidator userValidator;

        public UserService(IUnitOfWork uow, IMapper<UserDTO, User> um, IMapper<UserDTO, Contact> cm,
            IMapper<UserDTO, Picture> pm, IUserRepository<User> ur,
            IRepository<Contact> cr, IRepository<Picture> pr, IUserValidator uv)
        {
            unitOfWork = uow;
            userMapper = um;
            contactMapper = cm;
            pictureMapper = pm;
            userRepository = ur;
            contactRepository = cr;
            pictureRepository = pr;
            userValidator = uv;
        }

        public IEnumerable<UserDTO> GetList(int listSize, int pageNumber)
        {
            var startFrom = (pageNumber - 1) * listSize;

            var usersDto = new List<UserDTO>();
            var users = userRepository.GetList(listSize, startFrom);
            foreach (var u in users)
            {
                usersDto.Add(userMapper.Convert(u));
            }

            return usersDto;
        }

        public void Create(UserDTO userDto)
        {
            if (userValidator.Check(userDto))
            {
                var user = userMapper.Convert(userDto);
                var contact = contactMapper.Convert(userDto);
                var picture = pictureMapper.Convert(userDto);

                userRepository.Create(user);
                contactRepository.Create(contact);
                pictureRepository.Create(picture);

                unitOfWork.Save();
            }
            else
            {
                throw new Exception("Не все поля заполнены");
            }
        }

        public UserDTO GetUser(int id)
        {
            return userMapper.Convert(userRepository.GetUser(id));
        }

        public void Edit(UserDTO userDto)
        {
            if (userValidator.Check(userDto))
            {
                var user = userMapper.Convert(userDto);
                var contact = contactMapper.Convert(userDto);
                var picture = pictureMapper.Convert(userDto);

                userRepository.Update(user);
                contactRepository.Update(contact);
                pictureRepository.Update(picture);

                unitOfWork.Save();
            }
            else
            {
                throw new Exception("Не все поля заполнены");
            }
        }

        public void Delete(int id)
        {
            var user = userRepository.GetUser(id);
            userRepository.Delete(id);
            contactRepository.Delete(user.ContactId);
            pictureRepository.Delete(user.PictureId);

            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public int GetUsersCount()
        {
            return userRepository.GetUsersCount();
        }
    }
}
