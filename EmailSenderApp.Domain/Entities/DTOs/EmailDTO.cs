using System.ComponentModel.DataAnnotations;

namespace EmailSenderApp.Domain.Entities.DTOs
{
    public class EmailDTO
    {

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }

    }
}
