using EmailSenderApp.Domain.Entites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Infrastructure
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
            => Database.Migrate();
        public DbSet<RegisterModel> registerModels { get; set; }
        public DbSet<CheckingModel> checkingModels { get; set; }
    }
}
