using EmailSenderApp.Domain.Entites.Models;

namespace EmailSenderApp.Application.Services.CheckEmailCodeServices
{
    public interface ICheckService
    {
        Task<string> CheckUserAsync(CheckingModel checkingModel);
    }
}
