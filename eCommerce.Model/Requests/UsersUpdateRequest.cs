using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Model.Requests
{
    public class UsersUpdateRequest
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Password { get; set; }

        public string? PasswordConfirm { get; set; }

        public bool? Status { get; set; }
    }
}
