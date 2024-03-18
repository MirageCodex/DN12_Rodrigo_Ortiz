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
    public class ProductTypes
    {
        [Key]
        [Column("idproducttypes")]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        [Column("producttypename")]
        public string ProductTypeName { get; set; }

        [Required]
        [StringLength(45)]
        [Column("productdescription")]
        public string ProductDescription { get; set; }

        [Required]
        [Column("productcost")]
        public double Cost { get; set; }

        public List<Inventory> Inventories { get; set; }
        public List<Sales> Sales { get; set; }

        public ProductTypes()
        {
            Inventories = new List<Inventory>();
            Sales = new List<Sales>();
        }
    }
}

