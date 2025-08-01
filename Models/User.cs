// File: Models/User.cs
using System;

namespace FitnessApp.Models
{
    public class User
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } // This will store the hashed password
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public string Remark { get; set; }
        public DateTime? DateRegistered { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? LastFailedLogin { get; set; }
        public bool IsLocked { get; set; }

    }
}