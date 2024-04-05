using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOS.Core.Accounts
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(15)]
        [Required]
        public string UserName { get; set; }

        public int IdEmployee { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
