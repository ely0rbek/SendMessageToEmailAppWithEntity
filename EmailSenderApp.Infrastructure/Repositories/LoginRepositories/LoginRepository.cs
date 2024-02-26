using EmailSenderApp.Domain.Entites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Infrastructure.Repositories.LoginRepositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;

        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateCheckingModel(CheckingModel checkingModel)
        {
            await _context.checkingModels.AddAsync(checkingModel);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUserAsync(string email)
            => await _context.checkingModels.FirstOrDefaultAsync(x => x.Email == email) == null ? false : true;

        public async Task UpdateCheckingModel(CheckingModel checkingModel)
        {
            var person = _context.checkingModels.FirstOrDefaultAsync(x => x.Email == checkingModel.Email);
            if (person != null)
            {
                person.Result.SendedCode = checkingModel.SendedCode;

                await _context.SaveChangesAsync();
            }
        }
            
    }
}
