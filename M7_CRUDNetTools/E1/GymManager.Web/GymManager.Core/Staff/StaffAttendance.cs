using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Staff
{
    public class StaffAttendance
    {
        [Key]
        public int AttendanceId { get; set; }
        [Required]
        public string StaffName { get; set; }
        [Required]
        public int Monday { get; set; }
        [Required]
        public int Tuesday { get; set; }
        [Required]
        public int Wednesday { get; set; }
        [Required]
        public int Thursday { get; set; }
        [Required]
        public int Friday { get; set; }
        [Required]
        public int TotalAttendance { get; set; }

    }
}
