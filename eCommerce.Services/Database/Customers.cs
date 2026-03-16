using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public partial class Customers
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime RegistrationDate { get; set; }

        public string Email { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string PasswordSalt { get; set; } = null!;

        public bool IsActive { get; set; }

        public virtual ICollection<Orders> Orders { get; } = new List<Orders>();

        public virtual ICollection<Reviews> Reviews { get; } = new List<Reviews>();
    }
}
