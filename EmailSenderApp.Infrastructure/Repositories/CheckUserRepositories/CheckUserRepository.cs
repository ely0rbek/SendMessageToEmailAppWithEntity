using EmailSenderApp.Domain.Entites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Infrastructure.Repositories.CheckUserRepositories
{
    public class CheckUserRepository : ICheckUserRepository
    {
        private readonly ApplicationDbContext _context;

        public CheckUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async  Task<string> CheckUserAsync(CheckingModel checkingModel)
        {
            var user=await _context.checkingModels.FirstOrDefaultAsync(x=>x.Email==checkingModel.Email);
            if (user != null && user.SendedCode == checkingModel.SendedCode) return "You can access to project and welcome";
            else  return "you entered the wrong password.";
        }
    }
}
