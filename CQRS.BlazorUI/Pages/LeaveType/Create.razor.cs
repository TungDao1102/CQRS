using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using global::Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using CQRS.BlazorUI;
using CQRS.BlazorUI.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using CQRS.BlazorUI.InterfaceContracts;
using CQRS.BlazorUI.Models.LeaveType;

namespace CQRS.BlazorUI.Pages.LeaveType
{
    public partial class Create
    {
        [Inject]
        NavigationManager _navManager { get; set; }

        [Inject]
        ILeaveTypeService _client { get; set; }

      //  [Inject]
      //  IToastService toastService { get; set; }
        public string Message { get; private set; }

        LeaveTypeVM leaveType = new LeaveTypeVM();
        async Task CreateLeaveType()
        {
            var response = await _client.CreateLeaveType(leaveType);
            if (response.Success)
            {
            //   toastService.ShowSuccess("Leave Type created Successfully");
             //   toastService.ShowToast(ToastLevel.Info, "Test");
                _navManager.NavigateTo("/leavetype/");
            }

            Message = response.Message;
        }
    }
}