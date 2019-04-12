using AutoMapper;
using FluentValidation;
using MyBase.BLL.DataGen.Infrastructure;
using MyBase.BLL.DTO;
using MyBase.BLL.Infrastructure;
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

        public UserService(
            IUnitOfWork unitOfWork,
            IUserRepository<User> userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<List<UserDTO>> GetListOfUsersAsync(int listSize, int pageNumber)
        {
            var startFrom = (pageNumber - 1) * listSize;

            var users = await _userRepository.GetListOfUsersAsync(listSize, startFrom);
            var usersDto = Mapper.Map<List<UserDTO>>(users);

            return usersDto;
        }

        public Task CreateUserAsync(UserDTO userDto)
        {
            new UserValidator().ValidateAndThrow(userDto);

            var user = Mapper.Map<User>(userDto);
            _userRepository.Create(user);

            return _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserDTO> GetUserAsync(int id)
        {
            var user = await _userRepository.GetUserAsync(id);

            return Mapper.Map<UserDTO>(user);
        }

        public async Task UpdateUserAsync(UserDTO userDto)
        {
            new UserValidator().ValidateAndThrow(userDto);

            var user = Mapper.Map<User>(userDto);
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
