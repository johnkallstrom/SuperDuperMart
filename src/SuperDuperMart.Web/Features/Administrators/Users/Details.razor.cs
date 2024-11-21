using Blazored.Toast;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Features.Components.Toasts;

namespace SuperDuperMart.Web.Features.Administrators.Users
{
    public partial class Details
    {
        [Inject]
        public IMapper Mapper { get; set; } = default!;

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

        private bool Loading = true;

        public UserUpdateDto Model { get; set; } = new();
        public IEnumerable<RoleDto> Roles { get; set; } = [];

        protected override async Task OnParametersSetAsync()
        {
            await GetUser();
            await GetRoles();
            await DetermineIfCurrentUserIsBeingUpdated();
        }

        private async Task GetUser()
        {
            var userDto = await HttpService.GetAsync<UserDto>($"{Endpoints.Users}/{Id}");
            if (userDto != null)
            {
                Model = Mapper.Map<UserUpdateDto>(userDto);
                Loading = false;
            }
        }

        private async Task UpdateUser()
        {
            await HttpService.PutAsync($"{Endpoints.Users}/{Id}", Model);

            var parameters = new ToastParameters();
            parameters.Add(nameof(InfoToast.Message), $"Saved");

            ToastService.ShowToast<InfoToast>(parameters);
        }

        private async Task DeleteUser()
        {
            await HttpService.DeleteAsync($"{Endpoints.Users}/{Id}");
            NavigationManager.NavigateTo("/manage/users");
        }

        private async Task GetRoles()
        {
            var roleDtos = await HttpService.GetAsync<IEnumerable<RoleDto>>(Endpoints.Roles);
            if (roleDtos != null && roleDtos.Count() > 0)
            {
                Roles = roleDtos;
            }
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

        private void Cancel() => NavigationManager.NavigateTo("/manage/users");
    }
}
