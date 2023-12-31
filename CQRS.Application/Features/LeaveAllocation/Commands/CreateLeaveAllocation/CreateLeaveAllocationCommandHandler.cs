﻿using AutoMapper;
using CQRS.Application.Exceptions;
using CQRS.Application.Features.LeaveType.Commands.CreateLeaveType;
using CQRS.Application.InterfaceContracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateLeaveAllocationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data
            // convert dTO to object
            // add to db and return
            var validator = new CreateLeaveAllocationCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any()) throw new BadRequestException("Invalid LeaveType", validationResult);
            var leaveTypeCreate = _mapper.Map<Domain.Models.LeaveType>(request);
            await _unitOfWork.LeaveTypeRepo.AddAsync(leaveTypeCreate);
            return leaveTypeCreate.Id;
        }
    }
}
