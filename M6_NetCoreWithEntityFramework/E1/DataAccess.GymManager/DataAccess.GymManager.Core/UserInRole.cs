using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.GymManager.Core
{
    public class UserInRole
    {
        [Key, Column(Order = 0)]
        public int IdRoles { get; set; }

        [Key, Column(Order = 1)]
        public int IdUsers { get; set; }

        [ForeignKey("IdRoles")]
        public Role Role { get; set; }

        [ForeignKey("IdUsers")]
        public User User { get; set; }
    }
}

