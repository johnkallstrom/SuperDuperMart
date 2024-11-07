using Blazored.Toast;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Features.Components.Toasts;

namespace SuperDuperMart.Web.Features.Administrators.Users
{
    public partial class Update
    {
        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter]
        public int Id { get; set; }

        private bool _loading = true;

        public UserUpdateModel Model { get; set; } = new();

        protected override async Task OnParametersSetAsync()
        {
            await GetUser();
        }

        private async Task Submit()
        {
            await HttpService.PutAsync($"{Endpoints.Users}/{Id}", Model);

            var parameters = new ToastParameters();
            parameters.Add(nameof(InfoToast.Message), $"Updated user");

            ToastService.ShowToast<InfoToast>(parameters);
        }

        private async Task GetUser()
        {
            var user = await HttpService.GetAsync<UserModel>($"{Endpoints.Users}/{Id}");
            if (user != null)
            {
                Map(user);
                _loading = false;
            }
        }

        private void Map(UserModel user)
        {
            Model.Avatar = user.Avatar;
            Model.FirstName = user.FirstName;
            Model.LastName = user.LastName;
            Model.Location.StreetName = user.Location?.StreetName;
            Model.Location.ZipCode = user.Location?.ZipCode;
            Model.Location.City = user.Location?.City;
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/users");
    }
}
