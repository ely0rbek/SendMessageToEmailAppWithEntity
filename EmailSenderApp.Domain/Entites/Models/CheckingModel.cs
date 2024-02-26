using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmailSenderApp.Domain.Entites.Models
{
    public class CheckingModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string SendedCode { get; set; }
    }
}
