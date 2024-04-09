using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.MembershipType
{
    public class MembershipType
    {
        [Key]
        [Column("idmembershiptype")]
        public int idMembership {  get; set; }

        [Required(ErrorMessage ="Ingrese el nombre de la membresia")]
        [StringLength(45)]
        [Column("namemembership")]
        public string name { get; set; }

        [Required(ErrorMessage = "Ingrese la descripcion de la membresia")]
        [StringLength(255)]
        [Column("description")]
        public string description { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Ingrese el costo de la membresia")]
        [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser mayor o igual a 0")]
        [Column("precio")]
        public double cost { get; set; }

    }
}
