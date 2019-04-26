using AutoFixture;
using FluentValidation;
using MyBase.BLL.Dto;
using MyBase.BLL.Services.UserService.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyBase.BLL.Tests
{
    public class UserDtoValidatorTests
    {
        readonly UserDtoValidator _userDtoValidator;

        public UserDtoValidatorTests()
        {
            _userDtoValidator = new UserDtoValidator();
        }

        [Fact]
        public void ValidateAndThrow_UserFirstNameIsNull_ShouldThrowException()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var userDto = GetCorrectUserDto(id);
            userDto.FirstName = null;

            // Act & Assert
            Assert.Throws<ValidationException>(() => _userDtoValidator.ValidateAndThrow(userDto));
        }

        [Fact]
        public void ValidateAndThrow_CorrectProperties_SuccessValidation()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var userDto = GetCorrectUserDto(id);

            // Act & Assert
            _userDtoValidator.ValidateAndThrow(userDto);
        }

        [Fact]
        public void ValidateAndThrow_EmailIsNotValid_ShouldThrowException()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var userDto = GetCorrectUserDto(id);
            userDto.Email = "asd";

            // Act & Assert
            Assert.Throws<ValidationException>(() => _userDtoValidator.ValidateAndThrow(userDto));
        }

        [Fact]
        public void ValidateAndThrow_UserLastNameContainsNumbers_ShouldThrowException()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var userDto = GetCorrectUserDto(id);
            userDto.LastName += "12";

            // Act & Assert
            Assert.Throws<ValidationException>(() => _userDtoValidator.ValidateAndThrow(userDto));

        }

        private static UserDto GetCorrectUserDto(int id)
        {
            return new UserDto
            {
                Id = id,
                FirstName = "Irina",
                LastName = "Chu",
                Email = "dd@mail.ru",
                PhoneNumber = "1111111111",
                Image = null
            };
        }
    }
}
