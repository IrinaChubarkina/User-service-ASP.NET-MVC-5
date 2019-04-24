using FluentValidation;
using MyBase.BLL.Dto;

namespace MyBase.BLL.Services.UserService.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(1,20);
            RuleFor(x => x.LastName).NotEmpty().Length(1,20);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.PhoneNumber).NotEmpty();
        }
    }

}
