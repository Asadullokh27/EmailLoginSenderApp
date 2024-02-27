using System.ComponentModel.DataAnnotations;

namespace EmailSenderApp.Domain.Entities.DTOs
{
    public class UserDTO
    {

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
