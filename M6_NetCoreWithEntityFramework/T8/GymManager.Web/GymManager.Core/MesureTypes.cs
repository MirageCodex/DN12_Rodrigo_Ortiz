using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.GymManager.Core
{
    public class MesureTypes
    {
        [Key]
        [Column("idmesuretypes")]
        public int Id { get; set; }

        [Required]
        [StringLength(5)]
        [Column("type")]
        public string Type { get; set; }

        public List<Inventory> Inventories { get; set; }
        public List<Sales> Sales { get; set; }

        public MesureTypes()
        {
            Inventories = new List<Inventory>();
            Sales = new List<Sales>();
        }
    }
}
