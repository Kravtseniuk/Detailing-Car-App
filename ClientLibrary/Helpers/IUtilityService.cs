namespace ClientLibrary.Helpers
{
    public interface IUtilityService
    {
        ValueTask ShowMassage(string title, string message, string icon);
        ValueTask ShowSuccessMassage(string Message);
        ValueTask ShowErrorMassage(string Message);
    }
}