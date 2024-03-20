using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.EquipmentTypes
{
    public class EquipmentType
    {
        [Key]
        [Column("idequipmenttypes")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Ingrese el nombre del tipo de equipo")]
        [StringLength(45)]
        [Column("equipmentname")]
        public string EquipmentName { get; set; }
    }
}
