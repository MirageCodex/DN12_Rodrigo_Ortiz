using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GymManager.Core
{
    public class EquipmentTypes
    {
        [Key]
        [Column("idequipmenttypes")]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        [Column("equipmentname")]
        public string EquipmentName { get; set; }
    }
}