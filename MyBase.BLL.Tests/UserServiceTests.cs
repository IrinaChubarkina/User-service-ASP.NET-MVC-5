using AutoFixture;
using AutoMapper;
using Moq;
using MyBase.BLL.Infrastructure;
using MyBase.BLL.Services.UserService;
using MyBase.BLL.Services.UserService.Dto;
using MyBase.DAL.Entities;
using MyBase.DAL.Repositories.Interfaces;
using MyBase.DAL.UnitOfWork;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MyBase.BLL.Tests
{
    public class UserServiceTests : IDisposable
    {
        readonly IUserService _userService;

        readonly Mock<IUserRepository> _userRepositoryMock;
        readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public UserServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _userRepositoryMock = new Mock<IUserRepository>();

            _userService = new UserService(_unitOfWorkMock.Object, _userRepositoryMock.Object);

            Mapper.Initialize(config =>
            {
                config.AddProfile<AutoMapperProfile>();
            });
        }

        public void Dispose() => Mapper.Reset();

        [Fact]
        public async Task GetUserByIdAsync_UserIsNotEmptyAndNotDeleted_ShouldMapCorrectly()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var user = GetUser(id);

            _userRepositoryMock
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(user);

            var expectedUserDto = Mapper.Map<UserDto>(user);

            // Act
            var actualUserDto = await _userService.GetUserByIdAsync(id);

            // Assert
            Assert.Equal(expectedUserDto.Id, actualUserDto.Id);
            Assert.Equal(expectedUserDto.FirstName, actualUserDto.FirstName);
            Assert.Equal(expectedUserDto.LastName, actualUserDto.LastName);
            Assert.Equal(expectedUserDto.Email, actualUserDto.Email);
            Assert.Equal(expectedUserDto.PhoneNumber, actualUserDto.PhoneNumber);
            Assert.Equal(expectedUserDto.Image, actualUserDto.Image);
        }

        [Fact]
        public async Task GetUserByIdAsync_UserIsDeleted_ShouldReturnNull()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var user = GetUser(id);
            user.IsDeleted = true;

            _userRepositoryMock
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(user);

            UserDto expectedUserDto = null;

            // Act 
            var actualUserDto = await _userService.GetUserByIdAsync(id);

            // Assert
            Assert.Equal(expectedUserDto, actualUserDto);
        }

        [Fact]
        public async Task DeleteUserByIdAsync_WithoutConditions_ShouldInvokeDeleteAndSaveChanges()
        {
            // Arrange
            var id = new Fixture().Create<int>();

            _userRepositoryMock
                .Setup(x => x.GetByIdAsync(id));

            // Act
            await _userService.DeleteUserByIdAsync(id);

            // Assert
            _userRepositoryMock.Verify(repo => repo.DeleteByIdAsync(It.Is<int>(x => x == id)), Times.Once());
            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once());
        }

        private static User GetUser(int id)
        {
            return new User
            {
                Id = id,
                FirstName = "Irina",
                LastName = "Chu",
                Email = "dd@mail.ru",
                IsDeleted = false,
                PhoneNumber = "1111111111",
                Image = null
            };
        }
    }
}