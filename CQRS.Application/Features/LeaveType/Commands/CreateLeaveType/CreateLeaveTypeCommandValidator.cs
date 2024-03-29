﻿using CQRS.Application.InterfaceContracts.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
    {
        public CreateLeaveTypeCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required").NotNull().MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.DefaultDays)
           .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
           .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");

            //RuleFor(q => q.Name)
            //.MustAsync()
            //.WithMessage("Leave type already exists");
        }
    }  
}
