using EmailSenderApp.Domain.Entites.Models;
using EmailSenderApp.Infrastructure.Repositories.CheckUserRepositories;

namespace EmailSenderApp.Application.Services.CheckEmailCodeServices
{
    public class CheckService : ICheckService
    {
        private readonly ICheckUserRepository _userRepository;

        public CheckService(ICheckUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> CheckUserAsync(CheckingModel checkingModel)
        {
            try
            {
                return await _userRepository.CheckUserAsync(checkingModel);
            }
            catch (Exception ex) { return ex.Message; }
        }
    }
}
