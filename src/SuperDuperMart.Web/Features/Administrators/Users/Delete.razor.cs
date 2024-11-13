using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Administrators.Users
{
    public partial class Delete
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter]
        public int Id { get; set; }

        private bool _loading = true;
        public UserDto? Model { get; set; } = default!;

        protected override async Task OnParametersSetAsync()
        {
            await GetUser();
        }

        private async Task GetUser()
        {
            Model = await HttpService.GetAsync<UserDto>($"{Endpoints.Users}/{Id}");
            _loading = false;
        }

        private async Task DeleteUser()
        {
            await HttpService.DeleteAsync($"{Endpoints.Users}/{Id}");
            NavigationManager.NavigateTo("/manage/users");
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/users");
    }
}
