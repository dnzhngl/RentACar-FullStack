using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; } //binary
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
