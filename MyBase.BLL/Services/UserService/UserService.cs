using FluentValidation;
using MyBase.BLL.Infrastructure;
using MyBase.BLL.Services.UserService.Dto;
using MyBase.BLL.Services.UserService.TableGenerators;
using MyBase.BLL.Services.UserService.Validators;
using MyBase.DAL.Entities;
using MyBase.DAL.FileStorage;
using MyBase.DAL.Repositories.Interfaces;
using MyBase.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MyBase.BLL.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorage _fileStorage;
        private readonly IUserRepository _userRepository;

        public UserService(
            IUnitOfWork unitOfWork,
            IFileStorage fileStorage,
            IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _fileStorage = fileStorage;
        }

        public async Task<List<UserDto>> GetUsersAsync(int listSize, int pageNumber)
        {
            var startFrom = (pageNumber - 1) * listSize;

            var users = await _userRepository.GetAllNotDeletedUsersAsync(listSize, startFrom);
            var userList = users.Map<List<UserDto>>();

            return userList;
        }

        /// <exception cref="ValidationException">Смотреть UserDtoValidator</exception>
        public async Task<int> CreateUserAsync(UserDto userDto)
        {
            new UserDtoValidator().ValidateAndThrow(userDto);

            var user = userDto.Map<User>();

            var url = _fileStorage.SaveFile(userDto.Stream, userDto.FileName);

            user.ImageUrl = url.Value;
            _userRepository.Create(user);

            await _unitOfWork.SaveChangesAsync();
            return user.Id;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user.IsDeleted)
            {
                return null;
            }

            return user.Map<UserDto>();
        }

        /// <exception cref="ValidationException">Смотреть UserDtoValidator</exception>
        public async Task UpdateUserAsync(UserDto userDto)
        {
            new UserDtoValidator().ValidateAndThrow(userDto);

            var user = userDto.Map<User>();

            var url = _fileStorage.SaveFile(userDto.Stream, userDto.FileName);

            user.ImageUrl = url.Value;
            _userRepository.Update(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUserByIdAsync(int id)
        {
            await _userRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<int> GetUsersCountAsync()
        {
            return _userRepository.NotDeletedUsersCountAsync();
        }

        public async Task FillStorageWithFakeUsersAsync()
        {
            const int recordsCount = 100_000;
            var dataTable = DataTableGenerator.CreateUsersTable(recordsCount);

            var connectionString = ConfigurationManager.ConnectionString();

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
