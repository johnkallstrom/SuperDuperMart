using Blazored.Toast;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Features.Components.Toasts;

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

            var parameters = new ToastParameters();
            parameters.Add(nameof(InfoToast.Message), "Saved new user");

            ToastService.ShowToast<InfoToast>(parameters);
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/users");
    }
}
