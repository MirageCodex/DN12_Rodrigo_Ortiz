using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Members
{
    public class Member
    {
        public int Id { get; set; }
        public string name { get; set; }

        public string lastName { get; set; }

        public DateTime birth { get; set; }

        public int cityId { get; set; }

        public string email { get; set; }

        public bool allowNewsLetter { get; set; }
    }
}
