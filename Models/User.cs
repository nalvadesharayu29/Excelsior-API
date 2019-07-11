namespace Excelsior.API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int PanNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MobNo { get; set; }
        public string Email { get; set; }
    }
}