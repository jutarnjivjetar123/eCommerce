using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public partial class Roles
    {
        public int RoleId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; } = new List<UserRoles>();
    }
}
