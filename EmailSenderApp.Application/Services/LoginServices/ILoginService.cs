using EmailSenderApp.Domain.Entites.Models;

namespace EmailSenderApp.Application.Services.LoginServices
{
    public interface ILoginService
    {
        Task<string> LoginAsync(BaseEmailModel baseModel);
    }
}
