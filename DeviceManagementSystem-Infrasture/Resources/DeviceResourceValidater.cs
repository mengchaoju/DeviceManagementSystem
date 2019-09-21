using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagementSystem_Infrasture.Resources
{
    public class DeviceResourceValidater: AbstractValidator<DeviceResource>

    {
        public DeviceResourceValidater()
        {
            RuleFor(x => x.Owner)
                .NotNull()
                .WithName("Owner")
                .WithMessage("Required")
                .MaximumLength(50)
                .WithMessage("Maximum Length is 50");

            RuleFor(x => x.Name)
    .NotNull()
    .WithName("Device Name")
    .WithMessage("Required")
    .MaximumLength(50)
    .WithMessage("Maximum Length is 50");

            RuleFor(x => x.Description)
    .NotNull()
    .WithName("Description")
    .WithMessage("Required")
    .MaximumLength(500)
    .WithMessage("Maximum Length is 500");
        }
    }
}
