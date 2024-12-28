using Certificates2024.Models;

namespace Certificates2024.Data.ViewModels
{
    public class UserWithRoleViewModel
    {
        public ApplicationUser User { get; set; }
        public string Role { get; set; }
    }
}
