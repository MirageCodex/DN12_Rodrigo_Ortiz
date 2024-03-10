using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GymManager.Core
{
    public class MembershipType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string NameMembership { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public double Precio { get; set; }

        public List<Member> Members { get; set; }

        public MembershipType()
        {
            Members = new List<Member>();
        }
    }
}
