using FluentValidation;
using MyBase.BLL.Dto;
using MyBase.BLL.Infrastructure;
using MyBase.BLL.Services.UserService.TableGenerators;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using MyBase.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MyBase.BLL.Services.UserService
{
    public class UserService : IUserService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IUserRepository _userRepository;

        public UserService(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetUsersAsync(int listSize, int pageNumber)
        {
            var startFrom = (pageNumber - 1) * listSize;

            var users = await _userRepository.GetAllAsync(listSize, startFrom);
            var userList = users.Map<List<UserDto>>();

            return userList;
        }

        public async Task<int> CreateUserAsync(UserDto userDto)
        {
            new UserDtoValidator().ValidateAndThrow(userDto);

            var user = userDto.Map<User>();
            _userRepository.Create(user);

            await _unitOfWork.SaveChangesAsync();
            return user.Id;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            
            return user.Map<UserDto>();
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            new UserDtoValidator().ValidateAndThrow(userDto);

            var user = userDto.Map<User>();
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
            return _userRepository.CountAsync();
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
