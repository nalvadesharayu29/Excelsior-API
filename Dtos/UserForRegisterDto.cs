using System.ComponentModel.DataAnnotations;

namespace Excelsior.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [StringLength(10)]
        public string PanNo { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public long MobNo { get; set; }
        [Required]
        [EmailAddress]
        public string EmailID { get; set; }
    }   
}