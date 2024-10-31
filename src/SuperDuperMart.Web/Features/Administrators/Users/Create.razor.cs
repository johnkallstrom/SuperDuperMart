using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Administrators.Users
{
    public partial class Create
    {
        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public UserCreateModel Model { get; set; } = new();

        private async Task Submit()
        {
            await HttpService.PostAsync($"{Endpoints.Users}", Model);
            ToastService.ShowWarning("Created");
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/users");
    }
}
