using EmailSenderApp.Domain.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Infrastructure.Repositories.RegisterRepositories
{
    public interface IRegisterRepository
    {
        Task<bool> IsUserValid(string userEmail);
        Task<string> CreateUserAsync(RegisterModel registerModel);
    }
}
