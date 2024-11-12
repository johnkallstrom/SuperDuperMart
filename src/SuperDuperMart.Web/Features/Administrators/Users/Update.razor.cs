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
        public List<RoleModel> RoleOptions { get; set; } = new();

        protected override async Task OnParametersSetAsync()
        {
            await GetUser();
            await GetRoles();
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
            var user = await HttpService.GetAsync<UserModel>($"{Endpoints.Users}/{Id}");
            if (user != null)
            {
                Map(user);
                _loading = false;
            }
        }

        private async Task GetRoles()
        {
            var allRoles = await HttpService.GetAsync<IEnumerable<RoleModel>>(Endpoints.Roles);
            if (allRoles != null && allRoles.Count() > 0)
            {
                RoleOptions = allRoles.ToList();
            }
        }

        private void Map(UserModel user)
        {
            Model.Avatar = user.Avatar;
            Model.FirstName = user.FirstName;
            Model.LastName = user.LastName;
            Model.Username = user.Username;
            Model.Email = user.Email;
            Model.Location.StreetName = user.Location?.StreetName;
            Model.Location.ZipCode = user.Location?.ZipCode;
            Model.Location.City = user.Location?.City;
            Model.Roles = user.Roles;
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/users");
    }
}
