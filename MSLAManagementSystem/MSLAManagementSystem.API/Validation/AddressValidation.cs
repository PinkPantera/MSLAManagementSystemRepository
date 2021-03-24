using FluentValidation;
using MSLAManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSLAManagementSystem.API.Validation
{
    public class AddressValidation : AbstractValidator<AddressEntity>
    {
        public AddressValidation()
        {
            RuleFor(p => p.ShortAddress)
                .NotEmpty()
                .MaximumLength(140);

            RuleFor(p => p.Region)
                .MaximumLength(50);

            RuleFor(p => p.Town)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.Country)
                .NotEmpty()
                .MaximumLength(40);

            RuleFor(p => p.CityCode)
                .NotEmpty()
                .MaximumLength(10);
        }
    }
}