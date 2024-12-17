using Blazored.Toast;
using Blazored.Toast.Services;
using SuperDuperMart.Web.Extensions;
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

        public UserCreateDto Dto { get; set; } = new();

        public List<SelectOption> RoleOptions { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            await GetRoles();
        }

        private async Task Submit()
        {
            int? userId = await HttpService.PostAndRetrieveIntAsync(Endpoints.Users, Dto);
            if (userId.HasValue && userId.Value > 0)
            {
                await HttpService.PostAsync(Endpoints.Carts, new CartCreateDto 
                { 
                    Purchased = false, 
                    UserId = userId.Value 
                });

                NavigationManager.NavigateTo("/manage/users");
            }
            else
            {
                var parameters = new ToastParameters();
                parameters.Add(nameof(ErrorToast.Message), "Something went wrong");

                ToastService.ShowToast<ErrorToast>(parameters);
            }
        }

        private async Task GetRoles()
        {
            var roles = await HttpService.GetAsync<IEnumerable<RoleDto>>(Endpoints.Roles);
            RoleOptions = roles is not null ? roles.ToSelectOptionList() : [];
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/users");
    }
}
