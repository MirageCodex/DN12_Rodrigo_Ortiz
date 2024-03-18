using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.GymManager.Core
{
    public class Sales
    {
        [Key]
        [Column("idsales")] 
        public int Id { get; set; }

        [Required]
        public int Cuantity { get; set; }

        [Required]
        [Column("salesdate")] 
        public DateTime SalesDate { get; set; }

        
        /*[ForeignKey("Inventory")]
        [Column("inventory_idinventory")] 
        public int InventoryId { get; set; }*/
        public Inventory Inventory { get; set; }

       
        /*[ForeignKey("MesureTypes")]
        [Column("inventory_mesuretypes_idmesuretypes")] 
        public int MesureTypeId { get; set; }*/
        public MesureTypes MesureTypes { get; set; }

        
        /*[ForeignKey("ProductTypes")]
        [Column("inventory_producttypes_idproducttypes")]
        public int ProductTypeId { get; set; }*/
        public ProductTypes ProductTypes { get; set; }
    }
}

