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
    public class User
    {
        [Key]
        [Column("idUsers")]
        public int Id { get; set; }

        [Required, StringLength(15)]
        [Column("username")]
        public string UserName { get; set; }

        [Required, StringLength(45)]
        [Column("useremail")]
        public string UserMail { get; set; }

        [Required, StringLength(45)]
        [Column("userpassword")]
        public string UserPassWord { get; set; }

        [Required, StringLength(10)]
        [Column("userphone")]
        public string UserPhone { get; set; }
    }
}
