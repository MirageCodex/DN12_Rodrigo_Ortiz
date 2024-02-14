using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.MembershipType
{
    public class MembershipType
    {
        public int idMembership {  get; set; }

        [Required(ErrorMessage ="Ingrese el nombre de la membresia")]
        [StringLength(100)]
        public string name { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Ingrese el costo de la membresia")]
        [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser mayor o igual a 0")]
        public double cost { get; set; }

        public DateTime createdOn { get; set; }= DateTime.Now;

        [Range(1,12)]
        [Required(ErrorMessage ="Ingrese la duracion de la membresia")]
        public int duration { get; set; }
    }
}
