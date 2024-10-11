using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models.Users;

namespace SuperDuperMart.Web.Features.Administrators.Users
{
    public partial class Create
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public UserCreateModel Model { get; set; } = new();

        private async Task Submit()
        {
            await HttpService.PostAsync($"{Endpoints.Users}", Model);
            NavigationManager.NavigateTo("/manage/users");
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/users");
    }
}
