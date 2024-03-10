using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.GymManager.Core
{
    public class Role
    {
        [Key]
        [Column("idroles")] 
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        [Column("rolename")] 
        public string RoleName { get; set; }
    }
}
