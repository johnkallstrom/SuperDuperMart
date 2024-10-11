using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models.Users;

namespace SuperDuperMart.Web.Features.Administrators.Users
{
    public partial class Edit
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Parameter]
        public int Id { get; set; }

        public UserUpdateModel Model { get; set; } = new();

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }

        private async Task Submit()
        {
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/users");
    }
}
