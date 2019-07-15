namespace Excelsior.API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PanNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long MobNo { get; set; }
        public string Email { get; set; }
    }
}