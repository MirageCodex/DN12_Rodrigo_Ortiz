using GymManager.Core.EquipmentTypes;
using GymManager.Core.Members;
using GymManager.Core.MembershipType;
using GymManager.Core.Staff;
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
        public virtual DbSet<StaffAttendance> StaffAttendances { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MembershipType> MembershipType { get; set; }
        public GymManagerContext(DbContextOptions<GymManagerContext> options) : base(options)
        { 
        
        }
        
    }
}


