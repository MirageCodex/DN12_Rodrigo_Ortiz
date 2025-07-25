﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Example.Core
{
    public class Make
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string MakeName { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        public List<Vehicles> Vehicles { get; set; }

        public Make()
        {
            Vehicles = new List<Vehicles>();
        }
    }
}
