namespace EmailSenderApp.Application.Services.LoginServices
{
    public interface ILoginService
    {

        Task<bool> IsCorrect(string useremail, string password);
        Task<string> SendMessage(string useremail, string password);

    }
}
