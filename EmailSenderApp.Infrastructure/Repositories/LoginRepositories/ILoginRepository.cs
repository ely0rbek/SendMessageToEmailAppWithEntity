using EmailSenderApp.Domain.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Infrastructure.Repositories.LoginRepositories
{
    public interface ILoginRepository
    {
        Task<bool> IsUserAsync(string email);
        Task UpdateCheckingModel(CheckingModel checkingModel);
        Task CreateCheckingModel(CheckingModel checkingModel);
    }
}
