using System.ComponentModel.DataAnnotations;

namespace AbpCompanyName.AbpProjectName.WebMpa.Models.Account
{
    public class LoginViewModel
    {
        public string TenancyName { get; set; }

        [Required]
        public string UsernameOrEmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}