using FluentValidation.TestHelper;
using MyBase.BLL.Services.UserService.Validators;
using Xunit;

namespace MyBase.BLL.Tests
{
    public class UserDtoValidatorTests
    {
        private readonly UserDtoValidator _validator;

        public UserDtoValidatorTests()
        {
            _validator = new UserDtoValidator();
        }
        
        [Fact]
        public void Should_have_error_when_FirstName_is_null()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
        }

        [Fact]
        public void Should_not_have_error_when_FirstName_is_specified()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.FirstName, "Irina");
        }

        [Fact]
        public void Should_have_error_when_LastName_is_null()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
        }

        [Fact]
        public void Should_not_have_error_when_LastName_is_specified()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.LastName, "Chu");
        }

        //same tests
    }
}
