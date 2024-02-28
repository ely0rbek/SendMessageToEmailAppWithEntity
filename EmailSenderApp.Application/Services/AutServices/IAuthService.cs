using EmailSenderApp.Domain.Entites.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Application.Services.AutServices
{
    public interface IAuthService
    {
        Task<string> GenerateToken(User user);
    }
}
