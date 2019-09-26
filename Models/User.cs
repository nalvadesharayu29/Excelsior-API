using System;

namespace Excelsior.API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PanNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime DateOfBirth{ get; set; }
        public long MobNo { get; set; }
        public string Email { get; set; }
        public string AadharNo { get; set; }
        public string AadharEnrolID { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }

    }
}