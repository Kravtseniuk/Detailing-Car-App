using Microsoft.JSInterop;

namespace ClientLibrary.Helpers
{
    public class UtilityService(IJSRuntime _js) : IUtilityService
    {
        public async ValueTask ShowErrorMassage(string Message)
        {
            await ShowMassage("Помилка", Message, "error");
        }

        public async ValueTask ShowMassage(string title, string message, string icon)
        {
            await _js.InvokeVoidAsync("Swal.fire", title, message, icon);
        }

        public async ValueTask ShowSuccessMassage(string Message)
        {
            await ShowMassage("Success", Message, "success");
        }
    }
}