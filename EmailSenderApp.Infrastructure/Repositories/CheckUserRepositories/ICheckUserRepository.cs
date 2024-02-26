using EmailSenderApp.Domain.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Infrastructure.Repositories.CheckUserRepositories
{
    public interface ICheckUserRepository
    {
        Task<string> CheckUserAsync(CheckingModel checkingModel);

    }
}
