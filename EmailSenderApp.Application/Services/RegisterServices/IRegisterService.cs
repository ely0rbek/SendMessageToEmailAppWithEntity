using EmailSenderApp.Domain.Entites.Models;

namespace EmailSenderApp.Application.Services.RegisterServices
{
    public interface IRegisterService
    {
        Task<string> AddUserAsync(RegisterModel registerModel);
    }
}
