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
        IUserRepository<User> userRepository;
        IRepository<Contact> contactRepository;
        IRepository<Picture> pictureRepository;
        IMapper<UserDTO, User> userMapper;
        IMapper<UserDTO, Contact> contactMapper;
        IMapper<UserDTO, Picture> pictureMapper;
        IUserValidator userValidator;
        IDataGenerator dataGenerator;

        public UserService(IUnitOfWork uow, IMapper<UserDTO, User> um, IMapper<UserDTO, Contact> cm,
            IMapper<UserDTO, Picture> pm, IUserRepository<User> ur,
            IRepository<Contact> cr, IRepository<Picture> pr, IUserValidator uv, IDataGenerator dg)
        {
            unitOfWork = uow;
            userMapper = um;
            contactMapper = cm;
            pictureMapper = pm;
            userRepository = ur;
            contactRepository = cr;
            pictureRepository = pr;
            userValidator = uv;
            dataGenerator = dg;
        }

        public IEnumerable<UserDTO> GetList()
        {
            List<UserDTO> usersDto = new List<UserDTO>();
            var users = userRepository.GetList();
            foreach (var u in users)
            {
                usersDto.Add(userMapper.Convert(u));
            }
            return usersDto;
        }

        public void Add(UserDTO userDto)
        {
            if (userValidator.Check(userDto))
            {
                var user = userMapper.Convert(userDto);
                var contact = contactMapper.Convert(userDto);
                var picture = pictureMapper.Convert(userDto);
                userRepository.Add(user);
                contactRepository.Add(contact);
                pictureRepository.Add(picture);
                unitOfWork.Save();
            }
            else
            {
                throw new Exception("Не все поля заполнены");
            }
        }

        public UserDTO Get(int id)
        {
            return userMapper.Convert(userRepository.Get(id));
        }

        public void Edit(UserDTO userDto)
        {
            if (userValidator.Check(userDto))
            {
                var user = userMapper.Convert(userDto);
                var contact = contactMapper.Convert(userDto);
                var picture = pictureMapper.Convert(userDto);
                userRepository.Edit(user);
                contactRepository.Edit(contact);
                pictureRepository.Edit(picture);
                unitOfWork.Save();
            }
            else
            {
                throw new Exception("Не все поля заполнены");
            }
        }

        public void Delete(int id)
        {
            var user = userRepository.Get(id);
            userRepository.Delete(id);
            contactRepository.Delete(user.ContactId);
            pictureRepository.Delete(user.PictureId);
            unitOfWork.Save();
        }

        public void InsertFakeData(int number)
        {
            int contactCount = contactRepository.Count();
            int pictureCount = pictureRepository.Count();
            //int userCount = userRepository.Count();
            IEnumerable<User> source = dataGenerator.GenerateData(number, contactCount, pictureCount);
            userRepository.InsertFakeData(source);
            contactRepository.InsertFakeData(source);
            pictureRepository.InsertFakeData(source);
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
