using System.ComponentModel.DataAnnotations;

namespace Excelsior.API.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        [StringLength(10)]
        public string PanNo { get; set; }

        [Required]
        public string Password { get; set; }
    }
}