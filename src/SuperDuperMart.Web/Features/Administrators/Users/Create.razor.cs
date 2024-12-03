﻿using SuperDuperMart.Web.Extensions;

namespace SuperDuperMart.Web.Features.Administrators.Users
{
    public partial class Create
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public UserCreateDto Model { get; set; } = new();

        public List<SelectOption> RoleOptions { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            await GetRoles();
        }

        private async Task Submit()
        {
            await HttpService.PostAsync($"{Endpoints.Users}", Model);
            NavigationManager.NavigateTo("/manage/users");
        }

        private async Task GetRoles()
        {
            var roles = await HttpService.GetAsync<IEnumerable<RoleDto>>(Endpoints.Roles);
            RoleOptions = roles is not null ? roles.ToSelectOptionList() : [];
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/users");
    }
}
