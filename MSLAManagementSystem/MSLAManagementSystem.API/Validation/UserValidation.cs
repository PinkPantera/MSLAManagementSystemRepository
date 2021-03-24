using FluentValidation;
using MSLAManagementSystem.Core.Models;

namespace MSLAManagementSystem.API.Validation
{
    public class UserValidation : AbstractValidator<UserModel>
    {
        public UserValidation()
        {
            RuleFor(p => p.FirstName)
              .NotEmpty()
              .MaximumLength(50);

            RuleFor(p => p.LastNAme)
              .NotEmpty()
              .MaximumLength(50);

            RuleFor(p => p.UserName)
              .NotEmpty()
              .MaximumLength(50);
        }
    }
}
