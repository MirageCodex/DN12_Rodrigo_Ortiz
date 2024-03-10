using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GymManager.Core
{
    public class Member
    {
        [Key]
        [Column("idmembers")]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        [Column("membername")]
        public string MemberName { get; set; }

        [Required]
        [StringLength(45)]
        [Column("memberphone")]
        public string MemberPhone { get; set; }

        [Required]
        [StringLength(255)]
        [Column("memberemail")]
        public string MemberEmail { get; set; }

        [Required]
        [Column("member_start")]
        public DateTime MemberStart { get; set; }

        [Required]
        [Column("member_end")]
        public DateTime MemberEnd { get; set; }

        [ForeignKey("City")]
        [Column("cities_idcities")]
        public int CityId { get; set; }
        public City City { get; set; }

        [ForeignKey("MembershipType")]
        [Column("idmembershiptype")]
        public int? MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}
