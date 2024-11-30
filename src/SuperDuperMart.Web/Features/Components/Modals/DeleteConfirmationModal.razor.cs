using Blazored.Modal;
using Blazored.Modal.Services;

namespace SuperDuperMart.Web.Features.Components.Modals
{
    public partial class DeleteConfirmationModal
    {
        [CascadingParameter]
        public BlazoredModalInstance ModalInstance { get; set; } = default!;

        [Parameter]
        public string? Message { get; set; }

        private async Task Confirm() => await ModalInstance.CloseAsync(ModalResult.Ok());

        private async Task Cancel() => await ModalInstance.CancelAsync();
    }
}
