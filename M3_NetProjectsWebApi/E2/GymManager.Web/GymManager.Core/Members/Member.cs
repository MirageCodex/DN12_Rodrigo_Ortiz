using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Core.Members
{
    public class Member
    {
        public int Id { get; set; }

        [StringLength(15)] 
        [Required(ErrorMessage ="Debe ingresar el nombre del miembro")]
        public string name { get; set; }
        [Required]
        [StringLength(20)]
        public string lastName { get; set; }

        [BindProperty, DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime birth { get; set; }

        [Range(1,100)]
        public int cityId { get; set; }

        [EmailAddress]
        [Required]
        public string email { get; set; }

        public bool allowNewsLetter { get; set; }
    }
}
