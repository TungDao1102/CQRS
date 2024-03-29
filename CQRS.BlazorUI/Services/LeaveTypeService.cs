﻿using AutoMapper;
using Blazored.LocalStorage;
using CQRS.BlazorUI.InterfaceContracts;
using CQRS.BlazorUI.Models.LeaveType;
using CQRS.BlazorUI.Services.Base;

namespace CQRS.BlazorUI.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;

        public LeaveTypeService(IClient client, ILocalStorageService localStorageService, IMapper mapper) : base(client, localStorageService)
        {
            _mapper = mapper;
        }

        public async Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType)
        {
            try {
                await AddBearerToken();
                var createCommand = _mapper.Map<CreateLeaveTypeCommand>(leaveType);
                await _client.LeaveTypePOSTAsync(createCommand);
                return new Response<Guid>
                {
                    Success = true,
                };
            } catch(ApiException ex) {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteLeaveType(int id)
        {
            try
            {
                await AddBearerToken();
                await _client.LeaveTypeDELETEAsync(id);
                return new Response<Guid>
                {
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            await AddBearerToken();
            var leaveType = await _client.LeaveTypeGETAsync(id);
            return _mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
         //   await AddBearerToken();
            var leaveTypes = await _client.LeaveTypeAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        }

        public async Task<Response<Guid>> UpdateLeaveType(LeaveTypeVM leaveType)
        {
            try
            {
                await AddBearerToken();
                var updateCommand = _mapper.Map<UpdateLeaveTypeCommand>(leaveType);
                await _client.LeaveTypePUTAsync(updateCommand);
                return new Response<Guid>
                {
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
