using FluentValidation;
using MSLAManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSLAManagementSystem.API.Validation
{
    public class PersonValidation : AbstractValidator<PersonEntity>
    {
        public PersonValidation()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.SecondName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.DateOfBirth)
                .NotEmpty();

            RuleFor(p => p.Email)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.Phone)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
