using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthServer
{
    public class LoginUser
    {
        
        [Required(ErrorMessage = "Please enter your email address")]  
        [DataType(DataType.EmailAddress)]  
        [EmailAddress]
        [Display(Name = "Email address")]  
        [MaxLength(50)]  
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]  
        [StringLength(18, MinimumLength = 8)]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }



    }
}
