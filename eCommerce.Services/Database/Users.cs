using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace eCommerce.Services.Database
{

    public partial class Users
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string PasswordSalt { get; set; } = null!;

        public bool? Status { get; set; }

        public virtual ICollection<Sales> Sales { get; } = new List<Sales>();

        public virtual ICollection<UserRoles> UserRoles { get; } = new List<UserRoles>();

        public virtual ICollection<PurchaseEntries> PurchaseEntries { get; } = new List<PurchaseEntries>();
    }

}
