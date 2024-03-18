using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GymManager.Core
{
    public class Inventory
    {
        [Key]
        [Column("idinventory")]
        public int Id { get; set; }

        [Required]
        public int Stock { get; set; }

        /*[ForeignKey("MesureTypes")]
        [Column("mesuretypes_idmesuretypes")]
        public int MesureTypeId { get; set; }*/
        public MesureTypes Mesure { get; set; }

        /*[ForeignKey("ProductTypes")]
        [Column("producttypes_idproducttypes")]
        public int ProductTypeId { get; set; }*/
        public ProductTypes Product { get; set; }

        public List<Sales> Sales { get; set; }

        public Inventory()
        {
            Sales = new List<Sales>();
        }
    }
}
