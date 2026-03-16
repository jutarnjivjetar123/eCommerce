using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public partial class UserRoles
    {
        public int UserRoleId { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Users User { get; set; } = null!;

        public virtual Roles Role { get; set; } = null!;
    }
}
