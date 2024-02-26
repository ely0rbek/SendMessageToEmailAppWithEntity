using System.ComponentModel.DataAnnotations;

namespace EmailSenderApp.Domain.Entites.Models
{
    public class BaseEmailModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
