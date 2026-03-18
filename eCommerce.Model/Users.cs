using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace eCommerce.Model
{
    public class Users
    {

        public int UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string Username { get; set; } = null!;

        public bool? Status { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
    }
}
