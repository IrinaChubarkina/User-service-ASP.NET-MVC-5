using FluentValidation;
using MyBase.BLL.DTO;

namespace MyBase.BLL.Infrastructure
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(customer => customer.FirstName).NotEmpty();
            RuleFor(customer => customer.LastName).NotEmpty();
            RuleFor(customer => customer.Email).NotEmpty().EmailAddress();
            RuleFor(customer => customer.PhoneNumber).NotEmpty();
        }
    }

}
