using EmailSenderApp.Domain.Entites.Models;
using EmailSenderApp.Infrastructure.Repositories.RegisterRepositories;

namespace EmailSenderApp.Application.Services.RegisterServices
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _registerRepository;

        public RegisterService(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        public async Task<string> AddUserAsync(RegisterModel registerModel)
        {
            if (await _registerRepository.IsUserValid(registerModel.Email))
            {
                return "This user is already exists";
            }
            try
            {
                var result=await _registerRepository.CreateUserAsync(registerModel);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
