using FluentValidation;
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
        IRepository<Picture> _pictureRepository;
        IUserMapper<User, UserDTO> _userMapper;
        IMapper<UserDTO, Picture> _pictureMapper;

        public UserService(
            IUnitOfWork unitOfWork,
            IUserRepository<User> userRepository,
            IRepository<Picture> pictureRepository,
            IUserMapper<User, UserDTO> userMapper,
            IMapper<UserDTO, Picture> pictureMapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _pictureRepository = pictureRepository;
            _userMapper = userMapper;
            _pictureMapper = pictureMapper;
        }

        public async Task<List<UserDTO>> GetListOfUsersAsync(int listSize, int pageNumber)
        {
            var startFrom = (pageNumber - 1) * listSize;

            var users = await _userRepository.GetListOfUsersAsync(listSize, startFrom);
            var usersDto = _userMapper.Map(users);

            return usersDto;
        }

        public Task CreateUserAsync(UserDTO userDto)
        {
            new UserValidator().ValidateAndThrow(userDto);

            var user = _userMapper.Map(userDto);

            if (userDto.Image != null)
            {
                var picture = _pictureMapper.Map(userDto);
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

        public async Task UpdateUserAsync(UserDTO userDto)
        {
            new UserValidator().ValidateAndThrow(userDto);

            var user = _userMapper.Map(userDto);

            if (userDto.Image != null)
            {
                var picture = _pictureMapper.Map(userDto);
                _pictureRepository.Create(picture);
                user.Picture = picture;
            }

            _userRepository.Update(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Task<int> GetCountOfUsersAsync()
        {
            return _userRepository.GetCountOfUsersAsync();
        }

        public async Task FillStorageWithUsersAsync()
        {
            var recordsCount = 100 * 1000;

            var generator = new DataTableGenerator();
            var dataTables = new DataTable[] {
                generator.CreateUsersTable(recordsCount),
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
