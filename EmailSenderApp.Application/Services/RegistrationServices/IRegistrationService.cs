namespace EmailSenderApp.Application.Services.RegistrationServices
{
    public interface IRegistrationService
    {
        Task<string> Register(string useremail, string password);
        Task<bool> DoesExist(string useremail);

    }
}
