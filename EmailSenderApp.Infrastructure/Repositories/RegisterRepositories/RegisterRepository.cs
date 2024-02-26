using EmailSenderApp.Domain.Entites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Infrastructure.Repositories.RegisterRepositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly ApplicationDbContext _context;

        public RegisterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateUserAsync(RegisterModel registerModel)
        {
            try
            {
                 await _context.registerModels.AddAsync(registerModel);
                await _context.SaveChangesAsync();
                return "User was added to Database";
            }
            catch (Exception ex)
            {
                return $"There is error : {ex.Message}";
            }
        }

        public async Task<bool> IsUserValid(string userEmail)
            => await _context.registerModels.FirstOrDefaultAsync(x => x.Email == userEmail)==null?false : true;
    }
}
