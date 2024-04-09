using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Members
{
    public class City
    {
        [Key]
        [Column("idcities")]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        [Column("cityname")]
        public string CityName { get; set; }

        public List<Member> Members { get; set; }
        public City()
        {
            Members = new List<Member>();
        }
    }
}
