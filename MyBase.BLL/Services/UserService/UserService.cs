using MyBase.BLL.DataGen.Infrastructure;
using MyBase.BLL.DTO;
using MyBase.BLL.Infrastructure;
using MyBase.BLL.Mappers;
using MyBase.BLL.Services.UserService.Mappers;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MyBase.BLL.Services.UserService
{
    public class UserService : IUserService
    {
        IUnitOfWork _unitOfWork;
        IUserRepository<User> _userRepository;
        IRepository<Contact> _contactRepository;
        IRepository<Picture> _pictureRepository;
        IUserMapper<User, UserDTO> _userMapper;
        IMapper<UserDTO, Contact> _contactMapper;
        IMapper<UserDTO, Picture> _pictureMapper;

        public UserService(
            IUnitOfWork unitOfWork, 
            IUserRepository<User> userRepository,
            IRepository<Contact> contactRepository, 
            IRepository<Picture> pictureRepository,
            IUserMapper<User, UserDTO> userMapper,
            IMapper<UserDTO, Contact> contactMapper,
            IMapper<UserDTO, Picture> pictureMapper) 
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _contactRepository = contactRepository;
            _pictureRepository = pictureRepository;
            _userMapper = userMapper;
            _contactMapper = contactMapper;
            _pictureMapper = pictureMapper;
        }

        public async Task<List<UserDTO>> GetListAsync(int listSize, int pageNumber)
        {
            var startFrom = (pageNumber - 1) * listSize;

            var users = await _userRepository.GetListAsync(listSize, startFrom);
            var usersDto = _userMapper.Map(users);
            
            return usersDto;
        }

        public Task CreateAsync(UserDTO userDto)
        {
            new UserValidator().ValidateAndThrow(userDto);

            var contact = _contactMapper.Map(userDto);
            var picture = _pictureMapper.Map(userDto);
            var user = _userMapper.Map(userDto);

            user.Contact = contact;
            if (userDto.Image != null)
            {
                user.Picture = picture;
            }

            _userRepository.Create(user);

            return _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserDTO> GetUserAsync(int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            return _userMapper.Map(user);
        }

        public async Task EditAsync(UserDTO userDto)
        {
            new UserValidator().ValidateAndThrow(userDto);

            var user = _userMapper.Map(userDto);
            var contact = _contactMapper.Map(userDto);
            var picture = _pictureMapper.Map(userDto);

            //user.Contact = contact;

            if (userDto.Image != null)
            {
                _pictureRepository.Update(picture);
                user.Picture = picture;
            }

            _userRepository.Update(user);
            _contactRepository.Update(contact);
            //_userRepository.Create(user);
            //await _userRepository.DeleteAsync(userDto.Id);

            await _unitOfWork.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            return _userRepository.DeleteAsync(id);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Task<int> GetUsersCountAsync()
        {
            return _userRepository.GetUsersCountAsync();
        }

        public async Task FillStorageWithUsersAsync()
        {
            var recordsCount = 100 * 1000;

            var generator = new DataTableGenerator();
            var dataTables = new DataTable[] {
                generator.CreateUsersTable(recordsCount),
                generator.CreateContactsTable(recordsCount)
            };

            var connectionString = ConfigurationManager.ConnectionString();

            foreach (var dataTable in dataTables)
                using (var sqlBulk = new SqlBulkCopy(connectionString))
                {
                    sqlBulk.DestinationTableName = dataTable.TableName;

                    foreach (var column in dataTable.Columns)
                    {
                        sqlBulk.ColumnMappings.Add(column.ToString(), column.ToString());
                    }
                    await sqlBulk.WriteToServerAsync(dataTable);
                }
        }
    }
}
