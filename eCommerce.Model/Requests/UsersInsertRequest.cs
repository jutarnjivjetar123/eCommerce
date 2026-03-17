using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Model.Requests
{
    public class UsersInsertRequest
    {

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

        public bool? Status { get; set; }
    }
}
