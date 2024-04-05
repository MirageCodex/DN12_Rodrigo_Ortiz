﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOS.Accounts.Dto
{
    public class ProfileDto
    {
        public int Id { get; set; }

        [StringLength(15)]
        [Required]
        public string ProfileName { get; set; }

        public List<UserDto> Users { get; set; }

        public ProfileDto()
        {
            Users = new List<UserDto>();
        }
    }
}
