using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Certificates2024.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]
        public string? FullName { get; set; }
    }
}