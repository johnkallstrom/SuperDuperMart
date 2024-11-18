using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Operators.Users
{
    public partial class Create
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public UserCreateDto Model { get; set; } = new();

        private async Task Submit()
        {
            await HttpService.PostAsync($"{Endpoints.Users}", Model);
            NavigationManager.NavigateTo("/manage/users");
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/users");
    }
}
