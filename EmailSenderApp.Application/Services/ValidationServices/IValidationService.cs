namespace EmailSenderApp.Application.Services.ValidationServices
{
    public interface IValidationService
    {

        Task<string> CheckAsync(string useremail, string password, string code);


    }
}
