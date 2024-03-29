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
using CQRS.BlazorUI.Models;

namespace CQRS.BlazorUI.Pages
{
    public partial class Login
    {
        public LoginVM Model { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthService AuthenticationService { get; set; }

        public Login()
        {
        }

        protected override void OnInitialized()
        {
            Model = new LoginVM();
        }

        protected async Task HandleLogin()
        {
            if (await AuthenticationService.LoginAsync(Model.Email, Model.Password))
            {
                NavigationManager.NavigateTo("/");
            }

            Message = "Username/password combination unknown";
        }
    }
}