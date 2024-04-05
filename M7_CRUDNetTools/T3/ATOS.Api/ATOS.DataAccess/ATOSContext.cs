using ATOS.Core.Accounts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAccess
{
    public class ATOSContext : IdentityDbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Profile> Profiles { get; set; }

        public ATOSContext(DbContextOptions<ATOSContext> options): base(options) 
        {

        }
    }
}
