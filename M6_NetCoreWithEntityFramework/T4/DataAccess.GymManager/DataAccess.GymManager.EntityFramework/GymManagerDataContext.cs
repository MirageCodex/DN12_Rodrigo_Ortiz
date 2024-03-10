using DataAccess.GymManager.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GymManager.EntityFramework
{
    public class GymManagerDataContext : DbContext
    {
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<EquipmentTypes> EquipmentTypes { get; set;}
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MembershipType> MembershipTypes { get; set; }
        public virtual DbSet<MesureTypes> MesureTypes { get; set;}
        public virtual DbSet<ProductTypes> ProductTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInRole> UserInRoles { get; set; }
        public GymManagerDataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInRole>().HasKey(vi => new { vi.IdRoles, vi.IdUsers });
        }
    }
   
}
