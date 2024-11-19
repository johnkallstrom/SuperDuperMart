﻿using Blazored.Toast;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Features.Components.Toasts;

namespace SuperDuperMart.Web.Features.Operators.Users
{
    public partial class Details
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; } = default!;

        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter]
        public int Id { get; set; }

        public bool IsCurrentUserBeingUpdated { get; set; } = false;

        private bool _loading = true;

        public UserUpdateDto Model { get; set; } = new();
        public IEnumerable<RoleDto> Roles { get; set; } = [];

        protected override async Task OnParametersSetAsync()
        {
            await GetUser();
            await GetRoles();
            await DetermineIfCurrentUserIsBeingUpdated();
        }

        private async Task DetermineIfCurrentUserIsBeingUpdated()
        {
            int userToUpdateId = Id;

            var currentUser = await AuthenticationService.GetCurrentUserAsync();
            int? currentUserId = currentUser.FindUserIdentifier();

            if (currentUserId.HasValue)
            {
                IsCurrentUserBeingUpdated = userToUpdateId.Equals(currentUserId.Value);
            }
        }

        private async Task Submit()
        {
            await HttpService.PutAsync($"{Endpoints.Users}/{Id}", Model);

            var parameters = new ToastParameters();
            parameters.Add(nameof(InfoToast.Message), $"Saved");

            ToastService.ShowToast<InfoToast>(parameters);
        }

        private async Task GetUser()
        {
            var user = await HttpService.GetAsync<UserDto>($"{Endpoints.Users}/{Id}");
            if (user != null)
            {
                Model.Avatar = user.Avatar;
                Model.FirstName = user.FirstName;
                Model.LastName = user.LastName;
                Model.Username = user.Username;
                Model.Email = user.Email;
                Model.RoleId = user.Role.Id;
                Model.Location = user.Location;

                _loading = false;
            }
        }

        private async Task GetRoles()
        {
            var data = await HttpService.GetAsync<IEnumerable<RoleDto>>(Endpoints.Roles);
            if (data != null && data.Count() > 0)
            {
                Roles = data;
            }
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/users");
    }
}