using DataAccess.GymManager.Core;
using GymManager.Core.EquipmentTypes;
using GymManager.Core.Members;
using GymManager.Core.MembershipType;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAccess
{
    public class GymManagerContext : IdentityDbContext
    {
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }
        /*
        public virtual DbSet<Inventory> Inventory { get; set; }*/
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MembershipType> MembershipType { get; set; }
        /*
        public virtual DbSet<MesureTypes> MesureTypes { get; set; }
        public virtual DbSet<ProductTypes> ProductTypes { get; set; }
        //public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        //public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<UserInRole> UserInRoles { get; set; }*/
        public GymManagerContext(DbContextOptions<GymManagerContext> options) : base(options)
        { 
        
        }
        
    }
}


