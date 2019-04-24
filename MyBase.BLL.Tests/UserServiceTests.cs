using System;
using Xunit;
using MyBase.BLL.Services.UserService;
using System.Threading.Tasks;
using Moq;
using MyBase.DAL.UnitOfWork;
using MyBase.DAL.Entities;
using MyBase.BLL.Dto;
using AutoMapper;
using MyBase.BLL.Infrastructure;
using AutoFixture;
using MyBase.DAL.Repositories.Interfaces;

namespace MyBase.BLL.Tests
{
    public class UserServiceTests : IDisposable
    {
        readonly IUserService _service;

        readonly Mock<IUserRepository> _mockRepository;
        readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public UserServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockRepository = new Mock<IUserRepository>();

            _service = new UserService(_mockUnitOfWork.Object, _mockRepository.Object);

            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddProfile<AutoMapperProfile>();
            });
        }
        
        [Fact]
        public async Task GetUserByIdAsync_CorrectData_Success()
        {
            var id = new Fixture().Create<int>();
            var user = GetUser(id);

            _mockRepository
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(user);

            var expected = Mapper.Map<UserDto>(user);

            var actual = await _service.GetUserByIdAsync(id);

            _mockRepository.Verify(repo => repo.GetByIdAsync(It.Is<int>(x => x == id)));
            Assert.Equal(expected.Id, actual.Id);
        }

        [Fact]
        public async Task GetUserByIdAsync_RepositoryFailed_ThrowsException()
        {
            var expectedException = new Fixture().Create<Exception>();

            _mockRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ThrowsAsync(expectedException);

            var actualException = await Assert.ThrowsAsync<Exception>(() => _service.GetUserByIdAsync(It.IsAny<int>()));

            Assert.Equal(expectedException, actualException);

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

        [Fact]
        public async Task DeleteUserByIdAsync_Success()
        {
            var id = new Fixture().Create<int>();

            _mockRepository
                .Setup(x => x.GetByIdAsync(id));

            await _service.DeleteUserByIdAsync(id);

            _mockRepository.Verify(repo => repo.DeleteByIdAsync(It.Is<int>(x => x == id)), Times.Exactly(1));
            _mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }

        public void Dispose()
        {
            Mapper.Reset();
        }
    }
}