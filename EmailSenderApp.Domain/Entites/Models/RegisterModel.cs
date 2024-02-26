using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmailSenderApp.Domain.Entites.Models
{
    public class RegisterModel 
    {
        [JsonIgnore]
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
