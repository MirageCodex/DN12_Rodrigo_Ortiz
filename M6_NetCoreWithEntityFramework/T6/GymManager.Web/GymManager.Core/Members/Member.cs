using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Core.Members
{
    public class Member
    {
        [Key]
        [Column("idmembers")]
        public int Id { get; set; }

        [StringLength(45)]
        [Column("membername")]
        [Required(ErrorMessage = "Debe ingresar el nombre del miembro")]
        public string MemberName { get; set; }

        [Required(ErrorMessage = "Debe ingresar el teléfono del miembro")]
        [StringLength(45)]
        [Column("memberphone")]
        public string MemberPhone { get; set; }

        [Required(ErrorMessage = "Debe ingresar el correo electrónico del miembro")]
        [StringLength(255)]
        [Column("memberemail")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string MemberEmail { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Column("member_start")]
        public DateTime MemberStart { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Column("member_end")]
        public DateTime MemberEnd { get; set; }

        [Range(1, 100)]
        [ForeignKey("City")]
        [Column("cities_idcities")]
        public int CityId { get; set; }
        


    }
}
