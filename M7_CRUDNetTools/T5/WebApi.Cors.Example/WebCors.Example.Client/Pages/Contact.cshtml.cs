using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebCors.Example.Client.Pages
{
    public class ContactModel : PageModel
    {
        [Required(ErrorMessage = "NameRequired")]
        public string Name { get; set; }
        [EmailAddress (ErrorMessage = "EmailFormat")]
        [Required (ErrorMessage = "EmailRequired")]
        public string Email { get; set; }
        [Required(ErrorMessage = "MessageRequired")]
        public string Message { get; set; }
        public void OnGet()
        {
        }
    }
}
